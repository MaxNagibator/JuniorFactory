using Domiki.Web.Business.Core;
using System.Timers;

namespace Domiki.Web.Business
{
    public class CalculatorBackgroundService : BackgroundService
    {
        private IServiceProvider _serviceProvider;
        private ICalculator _calculator;

        public CalculatorBackgroundService(IServiceProvider serviceProvider, ICalculator calculator)
        {
            _serviceProvider = serviceProvider;
            _calculator = calculator;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _calculator.CheckInit();
            return Task.FromResult(0);
        }
    }
}
