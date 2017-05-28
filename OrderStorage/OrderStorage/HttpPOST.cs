using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using OrderStorage.Models;
using OrderStorage.Repositories;

namespace OrderStorage
{
    public static class HttpPOST
    {
        [FunctionName("HttpPOSTTrigger")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "order")]HttpRequestMessage req, [Table("Orders", Connection = "OrderStorage")]ICollector<TableOrder> outTable, TraceWriter log)
        {
            ClientOrder order = await req.Content.ReadAsAsync<ClientOrder>();

            try
            {
                OrderRepository rep = new OrderRepository();
                rep.Add(ref outTable, order);

                log.Info($"[Azure Function] Order is processed");

                return req.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                log.Error($"[Azure Function] Exception: " + ex.Message);

                return req.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}