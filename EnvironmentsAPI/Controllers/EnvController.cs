using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EnvironmentsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvController : ControllerBase
    {

        private readonly IOptions<Env> _env;
        public EnvController(IOptions<Env> env)
        {
            _env = env;
        }

        [HttpGet]
        public Env Get()
        {
            return _env.Value;
        }
    }
}
