using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using OrderStorage.Models;
using OrderStorage.Repositories;
using System;

namespace OrderStorage
{
    public static class HttpGET
    {
        [FunctionName("HttpGETTrigger")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "order/{id}")]HttpRequestMessage req, string id, [Table("Orders", Connection = "OrderStorage")]CloudTable table, TraceWriter log)
        {            
            try
            {                                
                OrderRepository rep = new OrderRepository();
                ClientOrder order = rep.Find(id, table);

                if (order != null)
                {
                    log.Info($"[Azure Function] Order is found");
                    return req.CreateResponse(HttpStatusCode.OK, order);
                }
                else
                {
                    log.Info($"[Azure Function] Order is not found");
                    return req.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                log.Error($"[Azure Function] Exception: " + ex.Message);

                return req.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}