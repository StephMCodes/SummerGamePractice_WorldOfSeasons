using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    
    internal class Combat
    {
        public static List<Character> charactersInCombat = new List<Character>();
        
       // public static List<Character> charactersStillToFight = new List<Character>(charactersInCombat);

        public static void ColeCombat()
        {
            //lets take every character in battle and prepare a list to give them their turn.
            //they will be removed when they had theirs and the list is remade every round

            List<Character> charactersStillToFight = new List<Character>(charactersInCombat);

            //lets keep track of all the current speeds and sort/reverse for descending order
            List<int> characterSpeeds = new List<int>();

            foreach (Character character in charactersInCombat)
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
                        Console.WriteLine(character.name + "'s turn! FIGHT ON!");
                        HaveTurn(character);
                        //as to not duplicate, we remove from waiting list
                        charactersStillToFight.Remove(character);
                        break;
                    }
                    
                }
            }

            }
        
        public static void EnterCombat()
        {
           foreach (Character character1 in charactersInCombat)
            {
                int speed1 = character1.speed;

                foreach (Character character2 in charactersInCombat)
                {
                    int speed2 = character2.speed;

                    if (speed1 > speed2)
                    {
                        HaveTurn(character1);
                    }
                    else
                    {
                        HaveTurn(character2);
                    }
                }
            }
        }

        public static void HaveTurn(Character character)
        {
            Console.WriteLine("It's " +character.name + "'s turn!");
        }


    }
}
