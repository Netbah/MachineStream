namespace MachineStream.Services
{
    using AutoMapper;
    using Configuration;
    using Domain.Model;
    using Handlers.Command;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;
    using Websocket.Client;

    public class WebSocketConnectionService : BackgroundService
    {
        private readonly ILogger<WebSocketConnectionService> _logger;
        private readonly IOptions<MachineStreamConfiguration> _config;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ManualResetEvent ExitEvent = new(false);
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public WebSocketConnectionService(
            ILogger<WebSocketConnectionService> logger,
            IOptions<MachineStreamConfiguration> config,
            IMapper mapper,
            IMediator mediator,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _config = config;
            _mapper = mapper;
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Connect(_config.Value.ConnectionString, _config.Value.ReconnectTimeoutSeconds,
                _config.Value.KeepAliveInterval);
        }

        private async Task Connect(string endpoint, int reconnectTimeoutSeconds, int keepAliveInterval)
        {
            var factory = new Func<ClientWebSocket>(() => new ClientWebSocket
            {
                Options = { KeepAliveInterval = TimeSpan.FromSeconds(keepAliveInterval) }
            });


            Task.Run(async () =>
            {
                var url = new Uri(endpoint);
                using var client = new WebsocketClient(url, factory);
                client.ReconnectTimeout = TimeSpan.FromSeconds(reconnectTimeoutSeconds);
                client.ReconnectionHappened.Subscribe(type => _logger.LogTrace($"Reconnection happened, type: {type}"));
                client.DisconnectionHappened.Subscribe(type =>
                    _logger.LogWarning($"Disconnection happened, type: {type}"));

                client.MessageReceived.Subscribe(async message =>
                {
                    try
                    {
                        var machineEvent = (MachineEventModel)JsonConvert.DeserializeObject(message.ToString(), typeof(MachineEventModel));
                        _logger.LogWarning($"Event from machine: {machineEvent.Payload.MachineId}");
                        var command = new CreateOrUpdateMachineCommand()
                        {
                            MachineEventModel = machineEvent
                        };
                        
                        var scope = _serviceScopeFactory.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        await mediator.Send(command);
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError("Error while processing message.", exception);
                    }
                });

                await client.StartOrFail();
                ExitEvent.WaitOne();
            });
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogWarning($"Close connection");
            ExitEvent.Set();

            return Task.CompletedTask;
        }
    }
}