using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using RestSharp;

namespace restCoockies.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            RestClient restClient = new RestClient("http://api.olhovivo.sptrans.com.br/v2.1"){
                CookieContainer = new CookieContainer()
            };
            
            RestRequest request = new RestRequest("Login/Autenticar?token=6f76933e898283a0bbf03b5aa3ee0a4e22f7b8dcb47abfeef4cd9f4300690a92", Method.POST);
            RestResponse resp = (RestResponse)restClient.ExecuteAsPost(request, "POST");
            var content = resp.Content;

            request = new RestRequest("Linha/Buscar?termosBusca=8700", Method.GET);
            resp = (RestResponse)restClient.ExecuteAsGet(request, "GET");
            content = resp.Content;
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
