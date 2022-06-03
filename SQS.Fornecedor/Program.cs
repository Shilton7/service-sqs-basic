using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading.Tasks;
namespace SQS.Fornecedor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new AmazonSQSClient(RegionEndpoint.USEast1);
            var request = new SendMessageRequest
            {
                QueueUrl = "[url]",
                MessageBody = "Test Shilton"
            };

            try
            {
                await client.SendMessageAsync(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever mensagem: {ex}");
            }

        }
    }
}
