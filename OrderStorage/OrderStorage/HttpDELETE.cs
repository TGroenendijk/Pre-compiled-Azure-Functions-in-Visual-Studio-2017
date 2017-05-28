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
    public static class HttpDELETE
    {
        [FunctionName("HttpDELETETrigger")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "order/{id}")]HttpRequestMessage req, string id, [Table("Orders", Connection = "OrderStorage")]CloudTable table, TraceWriter log)
        {
            
            try
            {
                OrderRepository rep = new OrderRepository();
                bool deleted = rep.Remove(ref table, id);

                if (deleted == true)
                {
                    log.Info($"[Azure Function] Order is deleted");
                    return req.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    log.Info($"[Azure Function] Order is not deleted");
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