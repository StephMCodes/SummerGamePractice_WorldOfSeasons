using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    internal class Magic
    {
        public string spellName;
        public string spellSeason;
        public int spellCost;
        public int spellPower;
        public int spellHit;
        public int spellTurns;
        //spell effect?

        public Magic winterShroud = new Magic("Winter Shroud", "Winter", 5, 5, 101, 5); //should always hit
        public Magic coldWind = new Magic("Cold Wind", "Winter", 2, 4, 95, 1); //slows down enemy

        public Magic(string spellName, string spellSeason, int spellCost, int spellPower, int spellHit, int spellTurns)
        {
            this.spellName = spellName;
            this.spellSeason = spellSeason;
            this.spellCost = spellCost;
            this.spellPower = spellPower;
            this.spellHit = spellHit;
            this.spellTurns = spellTurns;
        }
    }
}
