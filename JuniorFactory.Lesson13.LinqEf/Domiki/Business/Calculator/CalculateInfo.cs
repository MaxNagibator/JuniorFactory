using Domiki.Web.Business.Core;
using Domiki.Web.Data;
using System.Timers;

namespace Domiki.Web.Business
{
    public class CalculateInfo
    {
        public int PlayerId { get; set; }
        public int ObjectId { get; set; }

        /// <summary>
        /// дата когда событие должно выполнится
        /// </summary>
        public DateTime Date { get; set; }
        public CalculateTypes Type { get; set; }
    }
}
