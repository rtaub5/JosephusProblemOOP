using System;


namespace JosephusOO
{
    /// <summary>
    /// Author: Rocki Taub
    /// PA01
    /// This program initializes a number of soldiers and a count number in order to implement Josephus's Problem in Object-Oriented code.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // default number of soldiers
            int soldierNumber = 10;
            if (args.Length == 1)
            {
                int.TryParse(args[0], out soldierNumber);
            }

            Soldier firstSoldier = CreateSoldiers(soldierNumber);
         

            firstSoldier.CommenceGroupSuicide(5);

        }

        /// <summary>
        /// Creates the number of soldiers specified and sets Left and Right neighbors of soldiers.
        /// </summary>
        /// <param name="soldierNumber">number of soldiers to be instantiated</param>
        /// <returns name="firstSoldier">first soldier in the circle</returns>
        public static Soldier CreateSoldiers(int soldierNumber)
        {
            //prevSoldier stores previous soldier so can be set as the left of the next soldier
            Soldier prevSoldier = null;
            Soldier firstSoldier = null;


            for (int ix = 0; ix < soldierNumber; ++ix)
            {
                String soldierName = "Private " + (ix + 1);

                // generates ages of soldiers
                var random = new Random();
                int age = random.Next(20, 60);

                Soldier soldier = new Soldier(soldierName, age, (ix + 1));

                soldier.Left = prevSoldier;

                // will set currentSoldier as right of previous soldier, or sets value of first soldier for later use.
                if (ix != 0)
                    prevSoldier.Right = soldier;
                else
                    firstSoldier = soldier;

                // last soldier will have firstSoldier set as next Soldier to complete the circle
                if (ix == (soldierNumber - 1))
                {
                    soldier.Right = firstSoldier;
                    firstSoldier.Left = soldier;
                }

                prevSoldier = soldier;
            }

            return firstSoldier;

        }
    }
}


