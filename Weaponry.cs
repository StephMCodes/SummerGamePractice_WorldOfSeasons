using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    internal class Weapon
    {
        public string name;
        public string type;
        public double power;
        public int hitChance;
        public string ability;
        public bool isMagic;
        public int worth;

        public static Weapon Unarmed = new Weapon("fists", "fists", 0.5, 95, "none", false, 5); //make less strong???
        public static Weapon IronSword = new Weapon ("iron sword", "sword", 0.5, 85, "none", false, 5);



        public Weapon(string name, string type, double power, int hitChance, string ability, bool isMagic, int worth)
        {
            this.name = name;
            this.type = type;
            this.power = power;
            this.hitChance = hitChance;
            this.ability = ability;
            this.isMagic = isMagic;
            this.worth = worth;
        }

        
    }
}
