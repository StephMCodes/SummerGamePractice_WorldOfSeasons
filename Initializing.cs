using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Of_Seasons
{
    static internal class Initializing
    {
        public static Character trainingDummy = new Character("Training Dummy", "None", 1, 10, 10, 2, 2, 2, 2, 2, 2, 2, 2, true, Weapon.Unarmed, false);
        public static Character punchingBag = new Character("Punching Bag", "None", 1, 10, 10, 2, 2, 2, 2, 2, 2, 2, 2, true, Weapon.Unarmed, false);
        public static void Initialize ()
        {
            //constructor?
            Program.charactersInCombat.Add(trainingDummy);
            //trainingDummy.name = "Training Dummy";
            //trainingDummy.hpMax = 10;
            //trainingDummy.hp = trainingDummy.hpMax;
            //trainingDummy.speed = 1;
            //trainingDummy.speedMax = trainingDummy.speed;
            //trainingDummy.isOpponent = true;
            Program.charactersInCombat.Add(punchingBag);
            //punchingBag.name = "Punching Bag";
            //punchingBag.hpMax = 10;
            //punchingBag.hp = punchingBag.hpMax;
            //punchingBag.speed = 1;
            //punchingBag.speedMax = punchingBag.speed;
            //punchingBag.isOpponent = true;

            //hello world
            //this is a line of code to be pushed
            //hello do you see this
            //Opponents.dummy.name = "Training Dummy";
            //Opponents.dummy.hpMax = 20;
            //Opponents.dummy.hp = 20;
            //Opponents.dummy.speed = 1;
            //Opponents.dummy.speedMax = 1;
            //Opponents.dummy.attack = 2;
            //Opponents.dummy.magic = 5;
            //Opponents.dummy.isOpponent = true;
            // Combat.charactersInCombat.Add(Opponents.dummy);
            //Opponents.punchingbag.name = "Punching Bag";
            //Opponents.punchingbag.hpMax = 20;
            //Opponents.punchingbag.hp = 20;
            //Opponents.punchingbag.speed = 2;
            //Opponents.punchingbag.speedMax = 1;
            //Opponents.punchingbag.attack = 2;
            //Opponents.punchingbag.magic = 5;
            //Opponents.punchingbag.isOpponent = true;
            //Combat.charactersInCombat.Add(Opponents.punchingbag);
            //might change to be placed better and initialize...
        }
    }
}
