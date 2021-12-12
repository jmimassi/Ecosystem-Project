using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Herbivore : Animal
    {
        //protected Herbivore(int x, int y, int HP, int EP,int age,int VisionRadius,int ContactRadius, char Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, Sex)
        //{
        //}
        protected Herbivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed, string Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        {
        }

        public override void Hunt(List<Entity> List)
        {
            List<Plant> plants = new List<Plant>();

            foreach (Entity e in List)
            {
                try
                {
                    plants.Add((Plant)e);
                }

                catch { }
            }


            if (plants.Count > 0)
            {
                int distancex = plants[0].x - this.x;
                int distancey = plants[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;


                if (Math.Sqrt(pythagore) <= this.ContactRadius)
                {
                    // Eat(plants[0]);
                    Console.WriteLine("Plante Mangée");
                }
                else
                {
                    Move(plants[0]);
                }


            }
            else
            {
                Move(null);
            }
        }
    }
}
