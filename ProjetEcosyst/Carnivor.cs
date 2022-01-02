using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Carnivore : Animal
    {
        public int AttackPoint;

        protected Carnivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed,int AttackPoint ,string Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        {
                this.AttackPoint = AttackPoint; 
        }

        public void Attack(Herbivore proie)
        {
            proie.LoseHP(AttackPoint);
        }


        public virtual void Hunt(List<Entity> ListOfNearbyEntitiesForAnimal, Simulation sim)
        {
            Console.WriteLine("L'animal commence sa chasse");
            int count = ListOfNearbyEntitiesForAnimal.Count; 
            List<Meat> listOfNearbyMeat = new List<Meat>();
            List<Herbivore> listOfNearbyHerbivores = new List<Herbivore>();

            for (int i = 0; i < count; i++)
            {
                try {
                    
                    Meat meat = (Meat)ListOfNearbyEntitiesForAnimal[i];
                    listOfNearbyMeat.Add(meat);
                   
                }
                catch
                {
                    
                }
                try
                {
                    Herbivore herbi = (Herbivore)ListOfNearbyEntitiesForAnimal[i];
                    listOfNearbyHerbivores.Add(herbi);
                }
                catch { }

                

                
            }

            if(listOfNearbyMeat.Count > 0)
            {
                listOfNearbyMeat.Sort();
                int distancex = listOfNearbyMeat[0].x - this.x;
                int distancey = listOfNearbyMeat[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if(Math.Sqrt(pythagore) < this.ContactRadius)
                {
                    Console.WriteLine("Mange la viande se trouvant en {0},{1}", listOfNearbyMeat[0].x, listOfNearbyMeat[0].y);
                   Eat(listOfNearbyMeat[0],sim);
                }
                else
                {
                    Console.WriteLine("Se déplace vers {0},{1}", listOfNearbyMeat[0].x, listOfNearbyMeat[0].y);
                    Move(listOfNearbyMeat[0]);
                }
            }

            else if (listOfNearbyHerbivores.Count > 0 && listOfNearbyMeat.Count == 0)
            {
                listOfNearbyHerbivores.Sort(); 
                int distancex = listOfNearbyHerbivores[0].x - this.x;
                int distancey = listOfNearbyHerbivores[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if (Math.Sqrt(pythagore) < this.ContactRadius)
                {
                    Console.WriteLine("Attaque l'herbivore se trouvant en {0},{1}", listOfNearbyHerbivores[0].x, listOfNearbyHerbivores[0].y);
                    Attack(listOfNearbyHerbivores[0]);
                }
                else
                {
                    Console.WriteLine("Se déplace vers l'herbivore se trouvant en {0},{1}", listOfNearbyHerbivores[0].x, listOfNearbyHerbivores[0].y);
                    Move(listOfNearbyHerbivores[0]);
                }
            }

        }

        public void Eat(Meat meat, Simulation sim)
        {
            this.EP += 3;
            sim.DestroyObject(meat);
        }










        //protected Carnivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed, char Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        //{
        //}
    }
}
