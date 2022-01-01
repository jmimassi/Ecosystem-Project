using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Herbivore : Animal
    {
       
        protected Herbivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed, string Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        {
        }

        public virtual void Hunt(List<Entity> List,Simulation sim)
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
                plants.Sort(); 
                int distancex = plants[0].x - this.x;
                int distancey = plants[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;


                if (Math.Sqrt(pythagore) <= this.ContactRadius)
                {
                    this.Eat(plants[0],sim);
                    Console.WriteLine("La plante se situant en {0}, {1} a été mangée", plants[0].x, plants[0].y);
                }
                else
                {
                    Move(plants[0]);
                    Console.WriteLine("L'herbivore se déplace vers la plante se situant en {0}, {1}", plants[0].x, plants[0].y);
                }


            }
        }

        public void Eat(Plant plant, Simulation sim)
        {
            this.EP += 2;
            sim.DestroyObject(plant);

        }

        


    }
}
