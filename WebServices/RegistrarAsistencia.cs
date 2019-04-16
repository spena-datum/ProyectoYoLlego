namespace WebServices
{
    using ClasesLibrary;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public static class RegistrarAsistencia
    {
        [FunctionName("RegistrarAsistencia")]
        
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var json = await req.ReadAsStringAsync();
            var estudiante = JsonConvert.DeserializeObject<Estudiante>(json);

            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:YoLlegoDB");
            string o;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                using (var command = new SqlCommand("MarcarAsistencia", conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UsuarioId", estudiante.UsuarioId);
                    command.Parameters.AddWithValue("@ClaseId", 2);
                    conn.Open();


                    var c = command.ExecuteReader();
                    o = c.RecordsAffected.ToString();
                  
                }
            }

            

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;



            Response resp = new Response();
            resp.IsSuccess = true;
            resp.Message = o;

            string output = JsonConvert.SerializeObject(resp); 
            return output != null


                ? (ActionResult)new OkObjectResult(output)
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
