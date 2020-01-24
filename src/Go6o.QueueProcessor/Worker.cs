using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

        private readonly string _eventQueueUrl = "https://sqs.eu-west-1.amazonaws.com/777530757256/abtesting-queue";

        public Worker(ILogger<Worker> logger, IAmazonSQS sqs)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _sqs = sqs ?? throw new ArgumentNullException(nameof(sqs));
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
                    if(result.Messages.Any())
                    {
                        foreach (var message in result.Messages)
                        {
                            // Some Processing code would live here
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
