using Microsoft.Extensions.Logging;
using SampleApi.Services.Interfaces;

namespace SampleApi.Services
{
    public class FirstService
    {
        private readonly ILogger<FirstService> _logger;
        private readonly IOperationTransient _transientOp;
        private readonly IOperationScoped _scopedOp;
        private readonly IOperationSingleton _singletonOp;


        public FirstService( 
            IOperationSingleton singletonOp,
            IOperationTransient transientOp,
            IOperationScoped scopedOp,
            ILogger<FirstService> logger)
        {
            _logger = logger;
            _transientOp = transientOp;
            _scopedOp = scopedOp;
            _singletonOp = singletonOp;
        }

        public void GenerateResult()
        {
            _logger.LogInformation($"FirstService - Transient: {_transientOp.OperationId}");
            _logger.LogInformation($"FirstService - Scoped: {_scopedOp.OperationId}");
            _logger.LogInformation($"FirstService - Singleton: {_singletonOp.OperationId}");
        }
    }
}