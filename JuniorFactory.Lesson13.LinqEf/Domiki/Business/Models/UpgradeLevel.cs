namespace Domiki.Web.Business.Models
{
    public class UpgradeLevel
    {
        /// <summary>
        /// Значение уровня.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Сколько нужно секунд для перехода на этот уровень.
        /// </summary>
        public int UpgradeSeconds { get; set; }

        /// <summary>
        /// Сколько нужно ресурсов для перехода на этот уровень.
        /// </summary>
        public Resource[] Resources { get; set; }

        /// <summary>
        /// Что нам даёт данная постройка.
        /// </summary>
        public Modificator[] Modificators { get; set; }

        /// <summary>
        /// Что можно производить в постройке.
        /// </summary>
        public Receipt[] Receipts { get; set; } = new Receipt[0];

        /// <summary>
        /// Сколько одновременно производств можно запустить в постройке.
        /// </summary>
        public int MaxManufactureCount { get; set; }
    }
}