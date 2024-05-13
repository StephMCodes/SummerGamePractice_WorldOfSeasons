using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    
    internal class Combat
    {
        
        
        public static void EnterCombat()
        {
           foreach (Character character1 in Program.charactersInCombat)
            {
                int speed1 = character1.speed;

                foreach (Character character2 in Program.charactersInCombat)
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
