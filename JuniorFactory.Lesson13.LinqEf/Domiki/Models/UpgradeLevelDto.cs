using Domiki.Web.Business.Models;

namespace Domiki.Web.Models
{
    public class UpgradeLevelDto
    {
        /// <summary>
        /// Значение уровня.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Сколько нужно ресурсов для перехода на этот уровень.
        /// </summary>
        public ResourceDto[] Resources { get; set; }

        /// <summary>
        /// Что нам даёт этот уровень.
        /// </summary>
        public ModificatorDto[] Modificators { get; set; }

        /// <summary>
        /// Что можно производить в постройке.
        /// </summary>
        public int[] ReceiptIds { get; set; }
    }
}