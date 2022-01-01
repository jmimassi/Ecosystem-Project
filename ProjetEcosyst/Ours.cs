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


        public void Reproduce(Simulation sim,Ours ours)
        {
            Console.WriteLine("L'ours cherche à se reproduire avec l'ours se trouvant en {0},{1}", ours.x, ours.y);
            if (this.Sex == "Femelle")
            {
                if (ours.Sex == "Mâle")
                {   
                    if(this.pregnant == false)
                    {
                        Console.WriteLine("L'ours se reproduit et tombe enceinte");
                        this.pregnant = true;
                        this.pregnancy = 0;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Hélas son partenaire est du même sexe !");
                }
            }
            else
            {
                if (ours.Sex == "Femelle" && ours.pregnant == false)
                {
                    Console.WriteLine("L'ours féconde l'ours se trouvant en {0}, {1} ", ours.x,ours.y);
                    Fecond(ours);
                }
                else if (ours.Sex == "Femelle" && ours.pregnant == true)
                {
                    Console.WriteLine("Hélas son partenaire est déjà enceinte!");
                }
                else
                {
                    Console.WriteLine("Hélas son partenaire est du même sexe !");
                }
            }

        }



        public override void Hunt(List<Entity> ListOfNearbyEntitiesForAnimal, Simulation sim)
        {
            base.Hunt(ListOfNearbyEntitiesForAnimal,sim);
            int count = ListOfNearbyEntitiesForAnimal.Count;
            List<Ours> listOfNearbyBears = new List<Ours>();
            List<Meat> listOfNearbyMeat = new List<Meat>();
            List<Herbivore> listOfNearbyHerbivores = new List<Herbivore>();
            for (int i = 0; i < count; i++)
            {
                
                if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Ours) )
                {
                    if ( (ListOfNearbyEntitiesForAnimal[i].x,ListOfNearbyEntitiesForAnimal[i].y) != (this.x,this.y) )
                    {
                        listOfNearbyBears.Add((Ours)ListOfNearbyEntitiesForAnimal[i]);
                    }
                    
                }
                if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Meat))
                {
                    listOfNearbyMeat.Add((Meat)ListOfNearbyEntitiesForAnimal[i]);
                }
                if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Herbivore))
                {
                    listOfNearbyHerbivores.Add((Herbivore)ListOfNearbyEntitiesForAnimal[i]);
                }



            }
            
             if (listOfNearbyBears.Count > 0 && listOfNearbyHerbivores.Count == 0 && listOfNearbyMeat.Count == 0 )
            {
                listOfNearbyBears.Sort();
                int distancex = listOfNearbyBears[0].x - this.x;
                int distancey = listOfNearbyBears[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if(Math.Sqrt(pythagore) < this.ContactRadius)
                {
                    
                   Reproduce(sim, listOfNearbyBears[0]);
                }
                else
                {
                    Console.WriteLine("Se déplace vers l'ours se trouvant en {0}, {1}", listOfNearbyBears[0].x, listOfNearbyBears[0].y);
                    Move(listOfNearbyBears[0]);
                }
            }
             else
            {
                Move(null);
            }
        }
    }

    
}
