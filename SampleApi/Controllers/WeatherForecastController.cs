using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApi.Services;
using SampleApi.Services.Interfaces;

namespace SampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOperationTransient _transientOp;
        private readonly IOperationScoped _scopedOp;
        private readonly IOperationSingleton _singletonOp;
        private readonly FirstService _firstService;

        public WeatherForecastController(
            IOperationSingleton singletonOp,
            IOperationTransient transientOp,
            IOperationScoped scopedOp,
            FirstService firstService,
            ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _transientOp = transientOp;
            _scopedOp = scopedOp;
            _singletonOp = singletonOp;
            _firstService = firstService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Hello from logger");
            _logger.LogInformation($"Transient: {_transientOp.OperationId}");
            _logger.LogInformation($"Scoped: {_scopedOp.OperationId}");
            _logger.LogInformation($"Singleton: {_singletonOp.OperationId}");

            _firstService.GenerateResult();
           return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Hello from logger");
            _logger.LogInformation($"Transient: {_transientOp.OperationId}");
            _logger.LogInformation($"Scoped: {_scopedOp.OperationId}");
            _logger.LogInformation($"Singleton: {_singletonOp.OperationId}");

            _firstService.GenerateResult();
           return Ok();
        }
    }
}
