using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    internal class Program
    {
        public static Character player = new Character("Default", "None", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, "None");
        public static Character friend = new Character("Default", "None", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, "None");
        public static List<Character> charactersInCombat = new List<Character>();
        public static string target;
     

        static void Main(string[] args)
        {
            //FIXED??
            Initializing.Initialize();
            
            foreach (Character person in charactersInCombat)
            {
                Console.WriteLine(person.name);
            }
            
           


            CreateCharacter(player);
            charactersInCombat.Add(player);

            Console.WriteLine("Create a team member to cover your weaknesses.");
            //CreateCharacter(friend);
           // Combat.charactersInCombat.Add(friend);

            // DisplayInfo(player);
            // DisplayInfo(Opponents.dummy);

            //do while?
            Combat.EnterCombat();
            Combat.EnterCombat();

            //Combat.EnterCombat();
            Console.ReadLine();

        }

        public static void CreateCharacter(Character character)
        {
            Console.WriteLine("Welcome to Character Creator");
            ASKNAME: Console.WriteLine("Enter a name:");
            character.name = Console.ReadLine();
            Console.WriteLine("Your name is " + character.name + ". Is this correct? Enter [no] if not.");
            string nameCheck = Console.ReadLine().ToLower();
            if (nameCheck == "no")
            {
                goto ASKNAME;
            }
            else
            {
                Console.WriteLine("Enter the season you were born in (SPRING, SUMMER, AUTUMN or WINTER):");
            }
            string seasonchoice = Console.ReadLine().ToLower();
            SeasonChoice(seasonchoice, character);
            Console.WriteLine("Apply your stats: HP, SPEED, ATTACK, MAGIC");
            Console.WriteLine("You have 16, 14, 10 and 8 to apply.");
            Console.WriteLine("Which stat receives 16?");
            string statselection = Console.ReadLine().ToUpper();
            ApplyStat(statselection, 16, character);
            Console.WriteLine("Which stat receives 14?");
            statselection = Console.ReadLine().ToUpper();
            ApplyStat(statselection, 14, character);
            Console.WriteLine("Which stat receives 10?");
            statselection = Console.ReadLine().ToUpper();
            ApplyStat(statselection, 10, character);
            Console.WriteLine("Which stat receives 8?");
            statselection = Console.ReadLine().ToUpper();
            ApplyStat(statselection, 8, character);
            ChangeColour(character);
            Console.WriteLine("Welcome, " + character.name + ", member of the " + character.season + "folk.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Thanks for testing.");
            Console.WriteLine();
            return;
        }

        public static void SeasonChoice(string seasonchoice, Character character)
        {
        ASKSEASON: if (seasonchoice == "spring")
            {
                character.season = seasonchoice;
            }
            else if (seasonchoice == "summer")
            {
                character.season = seasonchoice;
            }
            else if (seasonchoice == "autumn")
            {
                character.season = seasonchoice;
            }
            else if (seasonchoice == "winter")
            {
                character.season = seasonchoice;
            }
            else
            {
                Console.WriteLine("Enter a valid season:");
                seasonchoice = Convert.ToString(Console.ReadLine());
                goto ASKSEASON;
            }
            return;
        }
        public static void ApplyStat(string stat, int number, Character character) //should be character not just player? STILL TO FIX
        {
            ASKSTAT: if (stat == "HP" && character.hp == 0)
            {
                character.hp = number;
                character.hpMax = number;
            }
            else if (stat == "SPEED" && character.speed == 0)
            {
                character.speed = number;
                character.speedMax = number;
            }
            else if (stat == "ATTACK" && character.attack == 0)
            {
                character.attack = number;
            }
            else if (stat == "MAGIC" && character.magic == 0)
            {
                character.magic = number;
            }
            else
            {
                Console.WriteLine("Enter a valid stat:");
                stat = Convert.ToString(Console.ReadLine().ToUpper());
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
            Console.ForegroundColor = ConsoleColor.White;
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
            else if (character.season == "winter")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
