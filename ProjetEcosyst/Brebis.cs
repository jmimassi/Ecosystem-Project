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
            Console.WriteLine("Cherche à se reproduire avec la brebis se trouvant en {0},{1}", breb.x, breb.y);
            if (this.Sex == "Femelle")
            {
                if (breb.Sex == "Male")
                {   
                    if(this.pregnant == false)
                    {
                        Console.WriteLine("La brebis se reproduit et tombe enceinte");
                        this.pregnant = true;
                        this.pregnancy = 0;
                    }

                }
                else
                {
                    Console.WriteLine("Hélas la brebis est du même sexe !");
                }
            }
            else
            {
                if (breb.Sex == "Femelle" && breb.pregnant == false)
                {
                    Console.WriteLine("Féconde la brebis se trouvant en {0}, {1} ", breb.x, breb.y);
                    Fecond(breb);
                }
                else if (breb.Sex == "Femelle" && breb.pregnant == true)
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
            List<Brebis> listeOfNearbyBrebis = new List<Brebis>();
            List<Plant> plants = new List<Plant>();
            for (int i = 0; i < count; i++)
            {
                
                if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Brebis))
                {
                    if ((ListOfNearbyEntitiesForAnimal[i].x, ListOfNearbyEntitiesForAnimal[i].y) != (this.x, this.y))
                    {
                        listeOfNearbyBrebis.Add((Brebis)ListOfNearbyEntitiesForAnimal[i]);
                    }
                        
                }
                if (ListOfNearbyEntitiesForAnimal[i].GetType() == typeof(Plant))
                {
                    plants.Add((Plant)ListOfNearbyEntitiesForAnimal[i]);
                }


            }

             if (listeOfNearbyBrebis.Count > 0 && plants.Count == 0)
            {
                listeOfNearbyBrebis.Sort(); // trier par distance
                int distancex = listeOfNearbyBrebis[0].x - this.x;
                int distancey = listeOfNearbyBrebis[0].y - this.y;

                int pythagore = distancex * distancex + distancey * distancey;

                if(Math.Sqrt(pythagore) < this.ContactRadius)
                {
                   Reproduce(sim, listeOfNearbyBrebis[0]);
                }
                else
                {
                    Console.WriteLine("Se déplace vers la brebis se trouvant en {0}, {1}", listeOfNearbyBrebis[0].x, listeOfNearbyBrebis[0].y);
                    Move(listeOfNearbyBrebis[0]);
                }
            }
             else
            {
                Move(null);
            }
        }
    }
}
