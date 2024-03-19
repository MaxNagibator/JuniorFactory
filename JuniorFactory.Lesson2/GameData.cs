using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorFactory.Lesson2
{
    public class GameData
    {
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }

        private int _staminaPoints;
        public int StaminaPoints
        {
            get
            {
                return _staminaPoints;
            }
            set
            {
                if(value > 100)
                {
                    value = 100;
                }
                _staminaPoints = value;
            }
        }
    }
}
