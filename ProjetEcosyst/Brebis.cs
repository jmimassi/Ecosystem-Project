using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public class Brebis : Herbivore
    {
        public Brebis(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed, string Sex) : base(x, y, HP, EP, age, VisionRadius, ContactRadius, speed, Sex)
        {

        }

        public void Reproduce(Simulation sim,Brebis breb)
        {
            if (this.Sex == "Femelle")
            {
                if (breb.Sex == "Mâle")
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
                if (breb.Sex == "Femelle")
                {
                    Fecond(breb);
                }
            }

        }

        public override void Hunt(List<Entity> ListOfNearbyEntitiesForAnimal, Simulation sim)
        {
            base.Hunt(ListOfNearbyEntitiesForAnimal,sim);
            count = ListOfNearbyEntitiesForAnimal.length;
            List<Brebis> listeOfNearbyBrebis = new List<Brebis>();
             for (int i = 0; i < count; i++)
            {
                
                if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Brebis))
                {
                    listeOfNearbyBrebis.add((Brebis) ListOfNearbyEntitiesForAnimal[i]);
                }
                
            }

             if (listeOfNearbyBrebis.length > 0)
            {
                listeOfNearbyBears.Sort(Brebis.SortByDistance());
                int distancex = listOfNearbyBrebis[0].x - this.x;
                int distancey = listOfNearbyBrebis[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if(Math.Sqrt(pythagore) < this.ContactRadius)
                {
                   Reproduce(sim, listeOfNearbyBrebis[0]);
                }
                else
                {
                    Move(listOfNearbyBrebis[0]);
                }
            }
             else
            {
                Move(null);
            }
        }
    }
}
