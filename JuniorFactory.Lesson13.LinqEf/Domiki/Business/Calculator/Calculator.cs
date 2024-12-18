using Domiki.Web.Business.Core;
using Domiki.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Timers;

namespace Domiki.Web.Business
{
    public class Calculator : ICalculator
    {
        private IServiceProvider _serviceProvider;
        private ILogger<Calculator> _logger;
        private List<CalculateInfo> _datas;
        private DateTime? _minDate;
        private System.Timers.Timer t;
        private bool _isInit;
        private int _errorCount = 0;

        public Calculator(IServiceProvider serviceProvider, ILogger<Calculator> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public void Insert(CalculateInfo cData)
        {
            if (_datas == null)
            {
                Init();
            }
            _logger.LogInformation("Calculator - add data: " + cData.PlayerId + " - " + cData.ObjectId + " - " + cData.Type);
            var index = _datas.FindIndex(x => x.Date > cData.Date);
            if (index == -1)
            {
                _datas.Add(cData);
            }
            else
            {
                _datas.Insert(index, cData);
            }
            _minDate = _datas[0].Date;
        }

        public void Remove(int playerId, long objectId, CalculateTypes type)
        {
            if (_datas == null)
            {
                Init();
            }
            var index = _datas.FindIndex(x => x.ObjectId == objectId && x.Type == type && x.PlayerId == playerId);
            if (index == -1)
            {
                return;
            }
            _logger.LogInformation("Calculator - remove data: " + playerId + " - " + objectId + " - " + type);
            _datas.RemoveAt(index);
            if (index == 0)
            {
                _minDate = _datas[0].Date;
            }
        }

        public void CheckInit()
        {
            //_isInit = true;
            if (_datas == null && _isInit == false)
            {
                _isInit = true;
                Init();
                if (_datas.Count > 0)
                {
                    _minDate = _datas[0].Date;
                }
                _logger.LogInformation("Calculator - init: count = " + _datas.Count + " , min date = " + _minDate);
            }
        }

        private void Init()
        {
            _datas = GetCalculateDates();

            var th = new Thread(Execute);
            th.Start();
        }

        private void Execute()
        {
            t = new System.Timers.Timer();
            t.Interval = 25;
            t.Elapsed += Tick;
            t.Start();
        }

        private void Tick(object sender, ElapsedEventArgs e)
        {
            if (_minDate != null)
            {
                var date = DateTimeHelper.GetNowDate();
                if (_minDate <= date)
                {
                    t.Stop();
                    var calcDate = _datas[0];
                    try
                    {
                        var startDate = DateTime.Now;
                        using (IServiceScope scope = _serviceProvider.CreateScope())
                        {
                            CalculatorTick calculatorTick = scope.ServiceProvider.GetRequiredService<CalculatorTick>();
                            UnitOfWork uow = scope.ServiceProvider.GetRequiredService<UnitOfWork>();
                            var result = calculatorTick.Calculate(date, calcDate);
                            uow.Context.SaveChanges();
                            uow.Commit();

                            var time = (DateTime.Now - startDate).TotalMilliseconds;
                            _logger.LogInformation("Calculator - tick success: " + calcDate.PlayerId + " - " + calcDate.ObjectId + " - " + calcDate.Type + " " + time + "ms");
                            if (result)
                            {
                                // todo посмотреть дату следующего, и если она наступила, тоже обработать и так далее. так как за одну секунду менее 1000/25=40 событий можно обработать
                                _datas.Remove(calcDate);
                                _minDate = _datas.Count > 0 ? (DateTime?)_datas[0].Date : null;
                                _logger.LogInformation("Calculator - tick remove data: " + calcDate.PlayerId + " - " + calcDate.ObjectId + " - " + calcDate.Type);
                            }
                        }
                        _errorCount = 0;
                    }
                    catch (Exception ex)
                    {
                        _errorCount++;
                        _logger.LogError(ex, "Calculator - tick trable: " + calcDate.PlayerId + " - " + calcDate.ObjectId + " - " + calcDate.Type + " | message: " + ex.Message);
                    }

                    if (_errorCount < 10)
                    {
                        t.Start();
                    }
                }
            }
        }


        private List<CalculateInfo> GetCalculateDates()
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                CalculatorTick vasv = scope.ServiceProvider.GetRequiredService<CalculatorTick>();
                UnitOfWork uow = scope.ServiceProvider.GetRequiredService<UnitOfWork>();
                var dates = new List<CalculateInfo>();
                var dbDomiks = uow.Context.Domiks.Where(s => s.UpgradeSeconds != null).ToList();
                foreach (var dbStorage in dbDomiks)
                {
                    var compliteDate = ((DateTime)dbStorage.UpgradeCalculateDate).AddSeconds((double)dbStorage.UpgradeSeconds);
                    dates.Add(new CalculateInfo
                    {
                        PlayerId = dbStorage.PlayerId,
                        ObjectId = dbStorage.Id,
                        Date = compliteDate,
                        Type = CalculateTypes.Domiks,
                    });
                }

                var dbManufactures = uow.Context.Manufactures.ToList();
                foreach (var dbManufacture in dbManufactures)
                {
                    dates.Add(new CalculateInfo
                    {
                        PlayerId = dbManufacture.DomikPlayerId,
                        ObjectId = dbManufacture.Id,
                        Date = dbManufacture.FinishDate,
                        Type = CalculateTypes.Manufacture,
                    });
                }

                dates = dates.OrderBy(x => x.Date).ToList();
                return dates;
            }
        }
    }
}
