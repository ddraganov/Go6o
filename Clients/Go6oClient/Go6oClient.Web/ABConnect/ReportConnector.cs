using Go6oClient.Web.Models;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Go6oClient.Web.ABConnect
{
    public class ReportConnector : IReportConnector
    {
        private readonly string eventQueueUrl = @"https://sqs.eu-west-1.amazonaws.com/777530757256/abtesting-queue";
        private readonly IAmazonSQS sqs;

        public ReportConnector(IAmazonSQS sqs)
        {
            this.sqs = sqs;
        }

        public void Send(Report report)
        {
            sqs.SendMessageAsync(new SendMessageRequest(eventQueueUrl, report.ToString())).GetAwaiter().GetResult();
        }
    }
}
