using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading.Tasks;

namespace SQS.Consumidor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new AmazonSQSClient(RegionEndpoint.USEast1);
            var request = new ReceiveMessageRequest
            {
                QueueUrl = "[url]"
            };

            while(true)
            {
                try
                {
                    var response = await client.ReceiveMessageAsync(request);

                    foreach (var message in response.Messages)
                    {
                        Console.WriteLine(message.Body);

                        var deleteRequest = new DeleteMessageRequest
                        {
                            QueueUrl = "[url]",
                            ReceiptHandle = message.ReceiptHandle
                        };

                        await client.DeleteMessageAsync(deleteRequest);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao consumir mensagem: {ex}");
                }
            }
        }
    }
}
