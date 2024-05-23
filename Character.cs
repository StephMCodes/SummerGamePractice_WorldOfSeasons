using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    internal class Character
    {
        public string name;
        public string season;
        public int level = 1;
        public int hp;
        public int hpMax;
        public int speed;
        public int speedMax;
        public int attack;
        public int attackMax;
        public int magic;
        public int magicMax;    
        public int mana = 10; //will increase different amounts based on mag
        public int manaMax = 10;
        public bool isOpponent;
        public Weapon weapon;
        public bool isDown;



        public Character(string name, string season, int level, int hp, int hpMax, int speed, int speedMax, int attack, int attackMax, int magic, int magicMax, int mana, int manaMax, bool isOpponent, Weapon weapon, bool isDown)
        {
            this.name = name;
            this.season = season;
            this.level = level;
            this.hp = hp;
            this.hpMax = hpMax;
            this.speed = speed;
            this.speedMax = speedMax;
            this.attack = attack;
            this.attackMax = attackMax;
            this.magic = magic;
            this.magicMax = magicMax;
            this.mana = mana;
            this.manaMax = manaMax;
            this.isOpponent = isOpponent;
            this.weapon = weapon;
            this.isDown = isDown;
        }
    }

   
   
}
