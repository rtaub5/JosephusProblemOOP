using System;
using System.Collections.Generic;
using System.Text;


namespace JosephusOO
{
    /// <summary>
    /// Soldier class initialized soldiers for Josephus's Problem. 
    /// </summary>
    class Soldier
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public int Location { get; set; } // numbered relative to the "first one created"
        // neighbors:
        public Soldier Left { get; set; }
        public Soldier Right { get; set; }

        /// <summary>
        /// Soldier constructor initializes soldiers.
        /// </summary>
        /// <param name="na">name of soldier</param>
        /// <param name="a">age of soldier</param>
        /// <param name="loc">location of soldier relative to the first soldier</param>
        public Soldier(String na, int a, int loc)
        {
            Name = na;
            Age = a;
            Location = loc;
            Left = null;
            Right = null;

        }

        /// <summary>
        /// instructs currentSoldier to "kill" Right Neighbor by manipulating lefts and rights neighbors.
        /// This will remove right neighbor from the circle.
        /// </summary>
        public void KillRightNeighbor()
        {
            Soldier executioner = this;
            Soldier beingKilled = executioner.Right;
            // executioner will now point to the next living soldier.
            executioner.Right = beingKilled.Right;

            // executioner's new neighbors will now point to executioner instead of beingKilled
            executioner.Left.Right = executioner;
            executioner.Right.Left = executioner;

            Console.WriteLine($"Executing {beingKilled.Name}, age {beingKilled.Age}.");
        }
        /// <summary>
        /// Loops through all the soldiers and kills every time countdown becomes 0.
        /// When only one soldier is left, the loop exits and the survivor is printed.
        /// </summary>
        /// <param name="n">soldiers countdown from n till 0 which is when  KillRightNeighbor() will be called.</param>
        public void CommenceGroupSuicide(int n) 
        {
            // starts with n - 1, in order to start the countdown from first soldier, and not the next one.
            int countdown = n - 1;
            Soldier currSoldier = this;

            // while the currentSoldier is not the only one in the circle
            while (currSoldier.Right != currSoldier)
            {
                if (countdown == 0)
                {
                    countdown = n;
                    currSoldier.KillRightNeighbor();
                }                    
                countdown--;          
                currSoldier = currSoldier.Right;                           
            }
            Console.WriteLine($"Survivor: {currSoldier.Name}, age {currSoldier.Age}. ");
        }

        /// <summary>
        /// Prints name, age, and location of soldier
        /// </summary>
        /// <returns>string information of soldier</returns>
        public string toString()
        {
            return ($"Name: {Name} Age: {Age} Location: {Location}");
        }

    }
}
