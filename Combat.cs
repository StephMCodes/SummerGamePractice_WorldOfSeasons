using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    
    static internal class Combat
    {
      //  public static List<Character> charactersInCombat = new List<Character>();
     //   public static string target;
        
       // public static List<Character> charactersStillToFight = new List<Character>(charactersInCombat);

        public static void EnterCombat()
        {
            //lets take every character in battle and prepare a list to give them their turn.
            //they will be removed when they had theirs and the list is remade every round

            List<Character> charactersStillToFight = new List<Character>(Program.charactersInCombat);

            //lets keep track of all the current speeds and sort/reverse for descending order
            List<int> characterSpeeds = new List<int>();

            foreach (Character character in Program.charactersInCombat)
            {
                characterSpeeds.Add(character.speed);
            }
            characterSpeeds.Sort();
            characterSpeeds.Reverse();

            //now we go from highest speed and check which character has it and has not had their turn
            //if the reqs are met, character gets turn and is removed from the waiting list

            foreach (int speed in characterSpeeds)
            {
                foreach (Character character in charactersStillToFight)
                {
                    if (character.speed == speed)
                    {
                        if (character.isDown==true)
                        {
                            Console.WriteLine(character.name + "is down and cannot continue to fight!");
                            break;
                        }

                        if (character.isOpponent == false)
                        {
                            Console.WriteLine(character.name + "'s turn! FIGHT ON!");
                            HaveTurn(character);
                        } else
                        {
                            //method for enemy
                            Console.WriteLine("Enemy attacks you for " + character.attack + " health points.");
                            Program.player.hp -= character.attack;
                            if (Program.player.hp <=0)
                            {
                                Console.WriteLine("You died!");
                            }
                        }
                        //as to not duplicate, we remove from waiting list
                        charactersStillToFight.Remove(character);
                        break;
                    }
                    
                }
            }

            }

        public static void CheckTeamSpells()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You check your spells.");
            Console.WriteLine("--------------------------------------------------------------");
            foreach (Magic spell in Program.teamMagicList)
            {
                if (spell.spellSeason== "spring")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(spell.spellName);
                    Console.WriteLine(spell.spellDesc);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (spell.spellSeason == "summer")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(spell.spellName);
                    Console.WriteLine(spell.spellDesc);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (spell.spellSeason == "autumn")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(spell.spellName);
                    Console.WriteLine(spell.spellDesc);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (spell.spellSeason == "winter")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(spell.spellName);
                    Console.WriteLine(spell.spellDesc);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }

            Console.WriteLine("--------------------------------------------------------------");

        }

        public static void MeleeAttack(Character character)
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

                    Random rnd = new Random();
                    int hitChance = rnd.Next(101);

                    if (hitChance > character.weapon.hitChance)
                    {
                        Console.WriteLine("Your attack missed!");
                        return;
                    }
                    Console.WriteLine(character.name + " attacks with their " + character.weapon.name + " for " + character.attack * character.weapon.power + " damage!");
                    person.hp -= Convert.ToInt32(character.attack * character.weapon.power);
                    if (person.hp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(person.name + " defeated!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Program.charactersInCombat.Remove(person);
                        person.isDown = true;
                        // Combat.charactersStillToFight.Remove(person);
                    }
                    else { Console.WriteLine(person.name + "'s HP:" + person.hp); }
                    return;
                }
                else
                {
                    Console.WriteLine("Re-enter a valid option.");
                    goto ASKTARGET;
                }
            }
            }

        public static void HaveTurn(Character character)
        {
            STARTTURN: Program.ChangeColour(character);
            Console.WriteLine("It's " + character.name + "'s turn!");
            Console.WriteLine("HP: " + character.hp + "/" + character.hpMax + "\tMANA: " + character.mana);
            Console.WriteLine("Attack: " + character.attack + "\tMagic: " + character.magic);
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("[ATTACK]    [MAGIC]    [ITEMS]    [CHECK]");
            Console.WriteLine("--------------------------------------------------------------");
            string turnChoice = Console.ReadLine().ToLower();
            switch (turnChoice)
            {
                default:
                    Console.WriteLine("Enter a valid option!");
                    goto STARTTURN;

                case "attack":
                    Console.Clear();
                    //display weapons to choose from?
                    Console.WriteLine("You decide to attack!");
                    character.mana++;
                    if (character.mana > character.manaMax)
                    {
                        character.mana = character.manaMax;
                    }
                    MeleeAttack(character);
                   

                    break;

                case "magic":
                ASKSPELL: Console.Clear();
                    Console.WriteLine("Which spell will you cast? Enter [list] to access the team's spellbook.");
                    string listCheck = Console.ReadLine().ToLower();
                    
                    foreach (Magic spell in Program.teamMagicList)
                    {
                        if (spell.spellName == listCheck)
                        {
                            Magic.CastSpell(listCheck, character);
                           break;
                        } 
                    }



                    if (listCheck == "list")
                    {
                        CheckTeamSpells();
                        Console.WriteLine("Enter anything to return.");
                        Console.ReadKey();
                        Console.Clear();
                        goto ASKSPELL;

                    }
                    else
                    {

                        Console.WriteLine("Enter a valid spell!");
                        listCheck = Console.ReadLine().ToLower();
                        goto ASKSPELL;
                    }
                    
                    
                   
                   

                case "items":
                    Console.Clear();
                    Console.WriteLine("Enter the name of an item to use it or [cancel] to return.");
                    string checkItems = Console.ReadLine().ToLower();
                    
                    if (checkItems == "cancel")
                    { goto STARTTURN; }
                    break;

                case "check":
                    Console.Clear();
                   
                    Console.WriteLine("ALLIES:");
                    foreach (Character character2 in Program.charactersInCombat)
                    {
                        if (character2.isOpponent==false)
                        {
                           Program.ChangeColour(character2);
                           Console.WriteLine(character2.name);
                           Program.ChangeColour(character);
                        }
                    }

                    Console.WriteLine("OPPONENTS:");
                    foreach (Character character2 in Program.charactersInCombat)
                    {
                        if (character2.isOpponent == true)
                        {
                            Program.ChangeColour(character2);
                            Console.WriteLine(character2.name);
                            Program.ChangeColour(character);
                        }
                    }

                ASKCHOICE: Console.WriteLine("Enter a name to check stats in full detail or [cancel] to return.");
                    string checkChoice = Console.ReadLine().ToLower();

                    if(checkChoice == "cancel")
                    { goto STARTTURN; }
                    
                    foreach (Character tocheck in Program.charactersInCombat)
                    {
                        if (checkChoice == tocheck.name)
                        {
                            Program.ChangeColour(tocheck);
                            Console.WriteLine(tocheck.name + " of the " + tocheck.season + "folk.");
                            Console.WriteLine("HP: " + tocheck.hp + "/" + tocheck.hpMax + "\tMANA: " + tocheck.mana);
                            Console.WriteLine("Attack: " + tocheck.attack + "\tMagic: " + tocheck.magic);
                            Console.WriteLine(tocheck.weapon);
                            Program.ChangeColour(character);
                            Console.ReadKey();
                            goto ASKCHOICE;

                        }
                        else
                        {
                            Console.WriteLine("Enter a valid name.");
                            goto ASKCHOICE;
                        }

                    }

                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
         //?   return;
        }

        
    }
}
