using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNNetCoreMVC
{
    public class CalculatorFactory
    {

        private readonly ILogger _logger;

        public CalculatorFactory(ILogger logger)
        {
            _logger = logger;
        }

        public ICalculator CreateCalculator()
        {
            return LoggingAdvice<ICalculator>.Create(
                new Calculator(),
                s => _logger.LogInformation("Info:" + s),
                s => _logger.LogInformation("Error:" + s),
                o => o?.ToString());
        }

    }
}
