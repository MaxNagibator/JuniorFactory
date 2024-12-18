namespace Domiki.Web.Business.Core
{
    public class CalculatorTick
    {
        private DomikManager _domikManager;

        public CalculatorTick(DomikManager domikManager)
        {
            _domikManager = domikManager;
        }

        public bool Calculate(DateTime date, CalculateInfo calcInfo)
        {
            switch (calcInfo.Type)
            {
                case CalculateTypes.Domiks:
                    return _domikManager.FinishDomik(date, calcInfo);
                case CalculateTypes.Manufacture:
                    return _domikManager.FinishManufacture(date, calcInfo);
            }
            return false;
        }
    }
}
