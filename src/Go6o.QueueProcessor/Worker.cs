using Amazon.SQS;
using Amazon.SQS.Model;
using Go6o.Core.Application.Events.SimpleCounting;
using Go6o.Core.Application.Events.SuccessFail;
using Go6o.Core.Application.TestEvaluators;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Go6o.QueueProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IAmazonSQS _sqs;
        private readonly IMediator _mediator;

        private readonly string _eventQueueUrl = "https://sqs.eu-west-1.amazonaws.com/777530757256/abtesting-queue";
        private readonly string _responseEventQueueUrl = "https://sqs.eu-west-1.amazonaws.com/777530757256/abtesting_response_queue";

        public Worker(ILogger<Worker> logger, IAmazonSQS sqs, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _sqs = sqs ?? throw new ArgumentNullException(nameof(sqs));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            ABTestEvaluatorFactory.GetEvaluator("Burgas");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var request = new ReceiveMessageRequest
                    {
                        QueueUrl = _eventQueueUrl,
                        MaxNumberOfMessages = 10,
                        WaitTimeSeconds = 5
                    };

                    var result = await _sqs.ReceiveMessageAsync(request);

                    if (result.Messages.Any())
                    {
                        foreach (var message in result.Messages)
                        {
                            // Some Processing code would live here
                            await _mediator.Publish(new SimpleCountingEvent() { TestId = "simple"});

                            var value = ABTestEvaluatorFactory.GetEvaluator("simple").GetValue();

                            var deleteResult = await _sqs.DeleteMessageAsync(_eventQueueUrl, message.ReceiptHandle);
                            _logger.LogInformation("Processing Message: {message} | {time}", message.Body, DateTimeOffset.Now);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.InnerException.ToString());
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
        }
    }
}
