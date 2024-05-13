using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    internal class Program
    {
        public static Character player = new Character();
        static void Main(string[] args)
        {
            //hello world
            //this is a line of code to be pushed
            //hello do you see this
            
            CreateCharacter();
            DisplayInfo(player);
            Console.ReadLine();

        }

        public static void CreateCharacter()
        {
            Console.WriteLine("Welcome to Character Creator");
            Console.WriteLine("Enter your name:");
            player.name = Console.ReadLine();
            Console.WriteLine("Enter the season you were born in (SPRING, SUMMER, AUTUMN or WINTER):");
            string seasonchoice = Console.ReadLine().ToLower();
            SeasonChoice(seasonchoice);
            Console.WriteLine("Apply your stats: HP, SPEED, ATTACK, MAGIC");
            Console.WriteLine("You have 16, 14, 10 and 8 to apply.");
            Console.WriteLine("Which stat receives 16?");
            string statselection = Console.ReadLine().ToUpper();
            ApplyStat(statselection, 16);
            Console.WriteLine("Which stat receives 14?");
            statselection = Console.ReadLine().ToUpper();
            ApplyStat(statselection, 14);
            Console.WriteLine("Which stat receives 10?");
            statselection = Console.ReadLine().ToUpper();
            ApplyStat(statselection, 10);
            Console.WriteLine("Which stat receives 8?");
            statselection = Console.ReadLine().ToUpper();
            ApplyStat(statselection, 8);
            ChangeColour(player);
            Console.WriteLine("Welcome, " + player.name + ", member of the " + player.season + "folk.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Thanks for testing.");
            return;
        }

        public static void SeasonChoice(string seasonchoice)
        {
        ASKSEASON: if (seasonchoice == "spring")
            {
                player.season = seasonchoice;
            }
            else if (seasonchoice == "summer")
            {
                player.season = seasonchoice;
            }
            else if (seasonchoice == "autumn")
            {
                player.season = seasonchoice;
            }
            else if (seasonchoice == "winter")
            {
                player.season = seasonchoice;
            }
            else
            {
                Console.WriteLine("Enter a valid season:");
                seasonchoice = Convert.ToString(Console.ReadLine());
                goto ASKSEASON;
            }
            return;
        }
        public static void ApplyStat(string stat, int number)
        {
            ASKSTAT: if (stat == "HP" && player.hp == 0)
            {
                player.hp = number;
            }
            else if (stat == "SPEED" && player.speed == 0)
            {
                player.speed = number;
            }
            else if (stat == "ATTACK" && player.attack == 0)
            {
                player.attack = number;
            }
            else if (stat == "MAGIC" && player.magic == 0)
            {
                player.magic = number;
            }
            else
            {
                Console.WriteLine("Enter a valid stat:");
                stat = Convert.ToString(Console.ReadLine());
                goto ASKSTAT;
            }
            return; }

        public static void DisplayInfo(Character character)
        {
            ChangeColour(character);
            Console.WriteLine(character.name);
            Console.WriteLine("HP: " + character.hp);
            Console.WriteLine("SPEED: " + character.speed);
            Console.WriteLine("ATTACK: " + character.attack);
            Console.WriteLine("MAGIC: " + character.magic);
            return;
        }

        public static void ChangeColour(Character character)
        {
            if (character.season == "spring")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (character.season == "summer")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (character.season == "autumn")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

    }
}
