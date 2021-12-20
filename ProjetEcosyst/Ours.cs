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
            if (this.Sex == "Femelle")
            {
                if (ours.Sex == "Mâle")
                {   
                    if(this.pregnant == false)
                    {
                    this.pregnant == true;
                    this.pregnancy == 0;
                    }
                    
                }
            }
            else
            {
                if (ours.Sex == "Femelle")
                {
                    Fecond(ours);
                }
            }

        }



        public override void Hunt(List<Entity> ListOfNearbyEntitiesForAnimal, Simulation sim)
        {
            base.Hunt(ListOfNearbyEntitiesForAnimal,sim);
            count = ListOfNearbyEntitiesForAnimal.length;
            List<Ours> listeOfNearbyBears = new List<Ours>();
             for (int i = 0; i < count; i++)
            {
                
                if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Ours))
                {
                    listeOfNearbyBears.add((Ours) ListOfNearbyEntitiesForAnimal[i]);
                }
                
            }

             if (listeOfNearbyBears.length > 0)
            {
                listeOfNearbyBears.Sort(Ours.SortByDistance());
                int distancex = listOfNearbyBears[0].x - this.x;
                int distancey = listOfNearbyBears[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if(Math.Sqrt(pythagore) < this.ContactRadius)
                {
                   Reproduce(sim, listeOfNearbyBears[0]);
                }
                else
                {
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
