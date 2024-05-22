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
        

        public static Magic winterShroud = new Magic("Winter Shroud", "winter", 5, 5, 101, 5, true, ""); //should always hit
        public static Magic coldWind = new Magic("Cold Wind", "winter", 2, 4, 95, 1, true, ""); //AOE ATTACK
        public static Magic freeze = new Magic("Freeze", "winter", 3, 5, 80, 3, false, "speed");                                                                                    //slows down enemy

        public static Magic absorb = new Magic("Absorb", "Autumn", 3, 3, 80, 1, false, "lifesteal");




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
          // need to make a spell list, this is goofy
            if (spell.spellSeason != character.season)
            {
                Console.WriteLine("You are the wrong season to cast this spell!");
                Combat.HaveTurn(character);
                return;
            }

            
            
            Random rnd = new Random();
            int hitChance = rnd.Next(101);

            if (hitChance > spell.spellHit)
            {
                Console.WriteLine("Your spell missed!");
                return;
            }

            if (spell.isAOE == true)
            {
                int enemyCount = 0;
                foreach (Character person in Program.charactersInCombat)
                {
                    if (person.isOpponent == true)
                    {
                        person.hp -= Convert.ToInt32(character.magic * amount);
                        enemyCount++;
                        if (person.hp <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(person.name + " defeated!"); 
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                Console.WriteLine(character.name + " hurt the enemy party for " + (character.magic * amount) + " health points.");
                if (spell.statusEffect == "lifesteal")
                {
                    character.hp += Convert.ToInt32(amount);
                    Console.WriteLine(character.name + " gained " + (enemyCount * (character.magic * amount)) + " health points.");
                    if (character.hp > character.hpMax)
                    {
                        character.hp = character.hpMax;

                    }
                }
            }
            else
            {
            ASKTARGET: Console.WriteLine("Who will you target?");
                Program.target = Console.ReadLine();
                bool validTarget = false;
                foreach (Character person in Program.charactersInCombat)
                {
                    if (person.isOpponent == true && Program.target == person.name)
                    {
                        validTarget = true;
                    }
                }
                if (validTarget == false)
                {
                    Console.WriteLine("Re-enter a valid option.");
                    goto ASKTARGET;
                }
                foreach (Character person in Program.charactersInCombat)

                {
                    if (person.name == Program.target)
                    {
                        person.hp -= Convert.ToInt32(character.magic * amount);
                        
                        if (person.hp <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(person.name + " defeated!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    }
                    
                }
                Console.WriteLine(character.name + " hurt the enemy for " + (character.magic * amount) + " health points.");
                if (spell.statusEffect == "lifesteal")
                {
                    character.hp += Convert.ToInt32(amount);
                    Console.WriteLine(character.name + " gained " + character.magic * amount + " health points.");
                    if (character.hp > character.hpMax)
                    {
                        character.hp = character.hpMax;

                    }
                }
            }

            return;
        }

        public static void HealSpell(Character character, double amount, Magic spell)
        {
            if (spell.spellSeason != character.season)
            {
                Console.WriteLine("You are the wrong season to cast this spell!");
                Combat.HaveTurn(character);
                return;
            }

            


            if (spell.isAOE == true)
            {
                foreach (Character person in Program.charactersInCombat)
                {
                    if (person.isOpponent == false)
                    {
                        person.hp += Convert.ToInt32(character.magic * amount);
                        if (person.hp > person.hpMax)
                        {
                            person.hp = person.hpMax;
                            
                        }
                    }
                   
                }
                Console.WriteLine(character.name + " healed the party for " + character.magic * amount + " health points.");
            }
            else
            {
            ASKTARGET: Console.WriteLine("Who will you target?");
                Program.target = Console.ReadLine();
                bool validTarget = false;
                foreach (Character person in Program.charactersInCombat)
                {
                    if (person.isOpponent == false && Program.target == person.name)
                    {
                        validTarget = true;
                    }
                }
                if (validTarget == false)
                {
                    Console.WriteLine("Re-enter a valid option.");
                    goto ASKTARGET;
                }


                foreach (Character person in Program.charactersInCombat)
                {
                    if (person.isOpponent == false && Program.target == person.name)
                    {
                        person.hp += Convert.ToInt32(character.magic * amount);
                        if (person.hp > person.hpMax)
                        {
                            person.hp = person.hpMax;

                        }
                        Console.WriteLine(person.name + " was healed for " + character.magic * amount + " health points.");

                    }
                   
                }

                    return;
            }
        }

        public static void StatusSpell(Character character, double amount, Magic spell)
        {
            if (spell.spellSeason != character.season)
            {
                Console.WriteLine("You are the wrong season to cast this spell!");
                Combat.HaveTurn(character);
                return;
            }

            Random rnd = new Random();
            int hitChance = rnd.Next(101);

            if (hitChance > spell.spellHit)
            {
                Console.WriteLine("Your spell missed!");
                return;
            }

            if (spell.isAOE == true)
            {
                foreach (Character person in Program.charactersInCombat)
                {
                    if (person.isOpponent == true)
                    {
                        if (spell.statusEffect == "speed")
                        {
                            person.speed -= Convert.ToInt32(amount);
                            if (person.speed <=0)
                            {
                                person.speed = 1;
                            }
                        }

                        
                    }
                }
                Console.WriteLine("The enemy party got their " + spell.statusEffect + " reduced by " + spell.spellPower + " for " + spell.spellTurns + " turns.");
            }
            else
            {
            ASKTARGET: Console.WriteLine("Who will you target?");
                Program.target = Console.ReadLine();
                bool validTarget = false;
                foreach (Character person in Program.charactersInCombat)
                {
                    if (person.isOpponent == true && Program.target == person.name)
                    {
                        validTarget = true;
                    }
                }
                if (validTarget == false)
                {
                    Console.WriteLine("Re-enter a valid option.");
                    goto ASKTARGET;
                }

                foreach (Character person in Program.charactersInCombat)
                {
                    if (person.isOpponent == true && Program.target == person.name)
                    {
                        if (spell.statusEffect == "speed")
                        {
                            person.speed -= Convert.ToInt32(amount);
                            if (person.speed <= 0)
                            {
                                person.speed = 1;
                            }

                            Console.WriteLine(person.name + " got their speed reduced by " + spell.spellPower + " for " + spell.spellTurns + " turns.");

                        }
                            else
                        {
                            Console.WriteLine("Re-enter a valid option.");
                            goto ASKTARGET;
                        }
                
                    }

                    }
                }
            
            return;
        }

       

        public static void CastSpell(string spell, Character character)
        {
            switch (spell) 
            {
                case "winter shroud":
                    //describe instead of giving numbers. you can do that in the method.
                    if (character.mana >= winterShroud.spellCost)
                    {
                        Console.WriteLine(character.name + " summons a healing, gentle snowfall upon their team.");
                        character.mana -= winterShroud.spellCost;
                        HealSpell(character, 0.5, winterShroud);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(character.name + " does not have enough mana for that!");
                        Combat.HaveTurn(character);
                    }
                    
                    break;

                case "cold wind":
                    if (character.mana >= coldWind.spellCost)
                    {
                        Console.WriteLine(character.name + " brings forth cold winds upon the enemy party.");
                       DamageSpell(character, 0.5, coldWind);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(character.name + " does not have enough mana for that!");
                        Combat.HaveTurn(character);
                    }
                    
                    break;

                case "freeze": //maybe a save to unfreeze?
                    if (character.mana >= freeze.spellCost)
                    {
                        Console.WriteLine(character.name + " cast Freeze, aiming to cover their opponent's legs in ice.");
                        StatusSpell(character, freeze.spellPower, freeze);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(character.name + " does not have enough mana for that!");
                        Combat.HaveTurn(character);
                    }
                    break;
                           
                    

                    
                    

                    
            }
        }
    }
}
