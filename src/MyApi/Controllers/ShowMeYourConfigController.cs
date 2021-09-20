using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

using MyApi.Contracts;

namespace MyApi.Controllers
{
    [Route("config")]
    [ApiController]
    public class ShowMeYourConfigController : ControllerBase
    {
        private readonly ConfigurationDataContract _configurationDataContract;

        public ShowMeYourConfigController(ConfigurationDataContract configurationDataContract)
        {
            _configurationDataContract = configurationDataContract;
        }

        [HttpGet]
        public Task<ConfigurationDataContract> Get()
        {
            return Task.FromResult(_configurationDataContract);
        }
    }
}
