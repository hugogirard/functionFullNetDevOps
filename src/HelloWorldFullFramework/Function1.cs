using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace HelloWorldFullFramework
{
    public static class Function1
    {
        [FunctionName("HelloWorld")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
                
            dynamic data = await req.Content.ReadAsAsync<object>();
            string name = data?.name;
            

            return name == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }
    }
}
