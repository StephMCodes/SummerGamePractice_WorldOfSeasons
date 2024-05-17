using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
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
        
        public static void MeleeAttack()
        {
           
        }

        public static void HaveTurn(Character character)
        {
            Program.ChangeColour(character);
            Console.WriteLine("It's " + character.name + "'s turn!");
            Console.WriteLine("HP: " + character.hp + "/" + character.hpMax);
            Console.WriteLine("Attack: " + character.attack + "\tMagic: " + character.magic);
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("[ATTACK]    [MAGIC]    [ITEMS]    [CHECK]");
            Console.WriteLine("--------------------------------------------------------------");
            string turnChoice = Console.ReadLine().ToLower();
            switch (turnChoice)
            {
                case "attack":
                    //display weapons to choose from
                    Console.WriteLine("You decide to attack!");
                    MeleeAttack();

                    break;

                case "magic":
                    ASKSPELL: Console.WriteLine("Which spell will you cast? Enter [list] to access your spellbook.");
                    string listCheck = Console.ReadLine().ToLower();
                    if (listCheck == "list")
                    {
                        Console.WriteLine("You check your spells.");
                        Console.ReadKey();
                        goto ASKSPELL;

                    }
                    else
                    {
                        Magic.CastSpell(listCheck, character);
                    }
                    //display spells to choose from if wanted or just cast
                    break;

                case "items":
                    Console.Clear();
                    Console.WriteLine("Enter the name of an item to use it or [cancel] to return.");
                    //if cancel goto start of turn
                    break;

                case "check":
                    Console.WriteLine("Enter a name to check stats and abilities in full detail.");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
