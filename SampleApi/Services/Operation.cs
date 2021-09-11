using SampleApi.Services.Interfaces;
using System;

namespace SampleApi.Services
{
    public class Operation : IOperationScoped, IOperationTransient, IOperationSingleton
    {
        public string OperationId {get;}
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^6..];
        }
    }
}