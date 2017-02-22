using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SFApp.Domain;

namespace ApiGateway.Controllers
{
    [RoutePrefix("v1/values")]
    [ServiceRequestActionFilter]
    public class ValuesController : ApiController
    {
        private IServiceProxyFactory _svcProxyFactory;

        public ValuesController()
        {
            _svcProxyFactory = new ServiceProxyFactory();

        }
        // GET api/values 
        [HttpGet]
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok($"POST value: {value}");
        }

        // PUT api/values/5 
        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok($"PUT value: {value}");
        }

        // DELETE api/values/5 
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            return Ok($"DELETE id: {id}");
        }

        /// <summary>
        /// Get list of cities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("cities")]
        public async Task<IHttpActionResult> GetListOfCities()
        {
            var client = _svcProxyFactory.GetMyStatelessService();

            var result = await client.GetListOfCities();
            return Ok(result);
        }
    }
}
