using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public bool isAOE;
        public string statusEffect;
        

        public static Magic winterShroud = new Magic("Winter Shroud", "Winter", 5, 5, 101, 5, true, ""); //should always hit
        public static Magic coldWind = new Magic("Cold Wind", "Winter", 2, 4, 95, 1, true, ""); //AOE ATTACK
        public static Magic freeze = new Magic("Freeze", "Winter", 3, 5, 80, 3, false, "speed");                                                                                    //slows down enemy

        public Magic(string spellName, string spellSeason, int spellCost, int spellPower, int spellHit, int spellTurns, bool isAOE, string statusEffect)
        {
            this.spellName = spellName;
            this.spellSeason = spellSeason;
            this.spellCost = spellCost;
            this.spellPower = spellPower;
            this.spellHit = spellHit;
            this.spellTurns = spellTurns;
            this.isAOE = isAOE;
            this.statusEffect = statusEffect;
        }

        public static void DamageSpell(Character character, double amount, Magic spell)
        {
            if (spell.isAOE == true)
            {
                foreach (Character person in Combat.charactersInCombat)
                {
                    if (person.isOpponent == true)
                    {
                        person.hp -= Convert.ToInt32(character.magic * amount);
                        if (person.hp <= 0)
                        {
                            Console.WriteLine("Opponent defeated!"); //SPECIFY
                        }
                    }
                }
            } else
            {
                //hit current target
            }
        }

        public static void HealSpell(Character character, double amount, Magic spell)
        {
            if (spell.isAOE == true)
            {
                foreach (Character person in Combat.charactersInCombat)
            {
                if (person.isOpponent == false)
                {
                    person.hp += Convert.ToInt32(character.magic * amount);
                    if (person.hp < person.hpMax)
                    {
                        person.hp = person.hpMax;
                    }
                }
            }
            }
            else
            {
                //hit current target
            }
        }

        public static void StatusSpell(Character character, double amount, Magic spell, string target)
        {
            if (spell.isAOE == true)
            {
                foreach (Character person in Combat.charactersInCombat)
                {
                    if (person.isOpponent == true)
                    {
                        if (spell.statusEffect == "speed")
                        {
                            person.speed -= Convert.ToInt32(amount);
                        }
                    }
                }
            }
            else
            {
                //hit current target
            }
        }

        public static void CastSpell(string spell, Character character)
        {
            switch (spell) //do rnd hit chance
            {
                case "winter shroud":
                    Console.WriteLine(character.name + " cast Winter Shroud, healing the party for " + character.magic*0.5 + " health points.");
                    DamageSpell(character, 0.5, winterShroud);
                    break;

                case "cold wind":
                    Console.WriteLine(character.name + " cast Cold Wind, damaging the enemy party for " + character.magic * 0.5 + " health points.");
                    HealSpell(character, 0.5, coldWind);
                    break;

                case "freeze": //maybe a save to unfreeze?
                    Console.WriteLine(character.name + " cast Freeze, reducing enemy speed for " + freeze.spellPower + " points for its next three turns.");
                    ASKTARGET: Console.WriteLine("Who will you target?");
                    Combat.target = Console.ReadLine();
                    
                    foreach (Character person in Combat.charactersInCombat)
                    {
                        if (person.isOpponent == true && Combat.target == person.name)
                        {
                            StatusSpell(character, freeze.spellPower, freeze, Combat.target);
                        }
                        else
                        {
                            Console.WriteLine("Re-enter a valid option.");
                            goto ASKTARGET;
                        }
                    }
                   
                    break;
            }
        }
    }
}
