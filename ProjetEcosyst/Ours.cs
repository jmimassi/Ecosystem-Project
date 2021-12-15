using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
        public class Ours : Carnivore
    {



        public Ours(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed,int AttackPoint,string Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed,AttackPoint, Sex)
            { 
            }

        public void Reproduce(Simulation sim)
        {


        }



        public override void Hunt(List<Entity> ListOfNearbyEntitiesForAnimal, Simulation sim)
        {
            Console.WriteLine(" ");
            int count = ListOfNearbyEntitiesForAnimal.Count; //2 listes une de viande, une d'hérbivore. 
            List<Meat> listOfNearbyMeat = new List<Meat>();
            List<Herbivore> listOfNearbyHerbivores = new List<Herbivore>();
            List<Ours> listOfNearbyPartners = new List<Ours>();

            for (int i = 0; i < count; i++)
            {
                try
                {

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
                try
                {
                    Ours ours = (Ours) ListOfNearbyEntitiesForAnimal[i];
                    if (ours.Sex != this.Sex) {
                        listOfNearbyPartners.Add(ours);
                    }
                   
                }
                catch { }




            }

            if (listOfNearbyMeat.Count > 0)
            {
                int distancex = listOfNearbyMeat[0].x - this.x;
                int distancey = listOfNearbyMeat[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if (Math.Sqrt(pythagore) < this.ContactRadius)
                {
                    Console.WriteLine("L'ours mange la viande se situant en {0},{1}", listOfNearbyMeat[0].x, listOfNearbyMeat[0].y);
                    Eat(listOfNearbyMeat[0], sim);
                }
                else
                {
                    Console.WriteLine("L'ours se déplace vers la viande se situant en {0},{1}", listOfNearbyMeat[0].x, listOfNearbyMeat[0].y);
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
                    Console.WriteLine("L'ours attaque l'herbivore se situant en {0},{1}", listOfNearbyHerbivores[0].x, listOfNearbyHerbivores[0].y);
                    Attack(listOfNearbyHerbivores[0]);
                }
                else
                {
                    Console.WriteLine("L'ours se déplace vers l'herbivore se situant en {0},{1}", listOfNearbyHerbivores[0].x, listOfNearbyHerbivores[0].y);
                    Move(listOfNearbyHerbivores[0]);
                }
            }

            //else if (listOfNearbyPartners.Count > 0)
            //{
            //    int distancex = listOfNearbyPartners[0].x - this.x;
            //    int distancey = listOfNearbyPartners[0].y - this.y;

            //    int pythagore = distancex * distancex + distancey * distancey;

            //    if (Math.Sqrt(pythagore) < this.ContactRadius)
            //    {
            //        // Reproduice(Simulation sim);
            //    }
            //    else
            //    {
            //        Move(listOfNearbyHerbivores[0]);
            //    }
            //}



            else
            {
                Move(null);
            }

        }
    }

    
}
