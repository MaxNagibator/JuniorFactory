namespace Domiki.Web.Models
{
    public class DomikTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogicName { get; set; }
        public int MaxCount { get; internal set; }
        public int MaxLevel { get; internal set; }

        public UpgradeLevelDto[] Levels { get; set; }
    }
}