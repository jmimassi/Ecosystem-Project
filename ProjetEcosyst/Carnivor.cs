using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Carnivore : Animal
    {
        int AttackPoint;

        protected Carnivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed,int AttackPoint ,string Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        {
                this.AttackPoint = AttackPoint; 
        }

        public void Attack(Herbivore proie)
        {
            proie.LoseHP(AttackPoint);
        }

        public  void Eat(Meat food)
        {
            this.EP += 5;
            // appeller DestroyObject

        }

        public override void Hunt(List<Entity> ListOfNearbyEntitiesForAnimal)
        {

            int count = ListOfNearbyEntitiesForAnimal.Count; //2 listes une de viande, une d'hérbivore. 
            List<Meat> listOfNearbyMeat = new List<Meat>();
            List<Herbivore> listOfNearbyHerbivores = new List<Herbivore>();

            for (int i = 0; i < count; i++)
            {
                try {
                    if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Meat))
                    {
                        listOfNearbyMeat.Add((Meat)ListOfNearbyEntitiesForAnimal[i]);
                    }
                }
                catch
                {
                    // cmt faire marcher ? ici tt est des entités
                }
                try
                {
                    if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Herbivore))
                    {
                        listOfNearbyHerbivores.Add((Herbivore)ListOfNearbyEntitiesForAnimal[i]);
                    }
                }
                catch { }

                

                
            }

            if(listOfNearbyMeat.Count > 0)
            {
                int distancex = listOfNearbyMeat[0].x - this.x;
                int distancey = listOfNearbyMeat[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if(Math.Sqrt(pythagore) < this.ContactRadius)
                {
                   Eat(listOfNearbyMeat[0]);
                }
                else
                {
                    Move(listOfNearbyMeat[0]);
                }
            }

            else if (listOfNearbyHerbivores.Count > 0)
            {
                int distancex = listOfNearbyHerbivores[0].x - this.x;
                int distancey = listOfNearbyHerbivores[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if (Math.Sqrt(pythagore) < this.ContactRadius)
                {
                    Attack(listOfNearbyHerbivores[0]);
                }
                else
                {
                    Move(listOfNearbyHerbivores[0]);
                }
            }



            else
            {
                Move(null);
            }

        }



 
        





        //protected Carnivore(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed, char Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        //{
        //}
    }
}
