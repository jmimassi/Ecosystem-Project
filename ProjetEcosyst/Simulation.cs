using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public class Simulation
    {
        public List<Entity> listOfEntities = new List<Entity>();
        public Simulation(List<Entity> listOfEntities)
        {
            this.listOfEntities = listOfEntities;
        }

        public static List<Entity> NearbyEntities(Animal chasseur, List<Entity> listOfEntities)
        {
            List<Entity> listOfNearbyEntities = new List<Entity>();
            int count = listOfEntities.Count;

            for (int i = 0; i < count; i++)
            {
                int distancex = listOfEntities[i].x - chasseur.x;
                int distancey = listOfEntities[i].y - chasseur.y;

                int pythagore = distancex*distancex + distancey*distancey;

                if (Math.Sqrt(pythagore) < chasseur.VisionRadius)
                {
                    listOfNearbyEntities.Add(listOfEntities[i]);
                }
            }



            return listOfNearbyEntities;
        }

        public static List<OrganicMat> NearbyOrgaMat(Plant chasseur, List<Entity> listOfEntities)
        {
            List<OrganicMat> listOfNearbyOrgaMat = new List<OrganicMat>();
            int count = listOfEntities.Count;

            for (int i = 0; i < count; i++)
            {
                int distancex = listOfEntities[i].x - chasseur.x;
                int distancey = listOfEntities[i].y - chasseur.y;

                int pythagore = distancex * distancex + distancey * distancey;

                try
                {
                    OrganicMat mat = (OrganicMat) listOfEntities[i];
                    if (Math.Sqrt(pythagore) < chasseur.RootRadius)
                    {
                        listOfNearbyOrgaMat.Add(mat);
                    }
                }
                catch { }
            }



            return listOfNearbyOrgaMat;
        }

        public bool CheckDie(LifeForm ent)
        {
            if ( ent.HP <= 0)
            {
                return true;
            }
            return false;
        }

        public void DestroyObject(Entity ent)
        {
            int index = this.listOfEntities.IndexOf(ent);
            this.listOfEntities.RemoveAt(index);
        }

        public void AddEntity(Entity entité)
        {
            listOfEntities.Add(entité);
        }

        


        public void Update(Simulation sim)
        {
            List<Entity> entities2 = new List<Entity>(this.listOfEntities.ToArray());
            entities2.ForEach(entit =>
            {
                try
                {

                    Ours ours = (Ours)entit;
                    Console.WriteLine("Ours se situant en : {0},{1}, HP : {2}, EP : {3}", ours.x,ours.y, ours.HP, ours.EP);
                    if (ours.EP == 0)
                    {
                        ours.ConvertPVToPE();
                        Console.WriteLine("L'ours perd 1PV et le transforme en PE");
                    }
                    if (CheckDie(ours) == true)
                    {
                        DestroyObject(entit);
                        Meat meat = new Meat(ours.x,ours.y);
                        sim.AddEntity(meat);    
                        Console.WriteLine("L'ours n'a plus de PV, il meurt");
                    }
                    else
                    {
                        
                        List<Entity> list = NearbyEntities(ours, listOfEntities);
                        ours.Hunt(list, sim);
                        if (ours.pregnancy > 5 && ours.pregnant == true)
                        {
                            Random rand = new Random();
                            int a  = rand.Next(0,1);
                            string Sex;
                            if (a == 0)
                            {
                                Sex = "Femelle";
                            }
                            else
                            {
                                Sex = "Male";
                            }
                            Ours enfant = new Ours(ours.x,ours.y,ours.HP,ours.EP,0,ours.VisionRadius,ours.ContactRadius,ours.speed,ours.AttackPoint,Sex);
                            Console.WriteLine("Un ourson naît en {0}, {1}",enfant.x,enfant.y);
                            sim.AddEntity(enfant);
                            ours.pregnant = false;
                            ours.pregnancy = 0;
                        }
                        ours.grow();
                        ours.EP--;
                    }
                    

                }
                catch { }

                try
                {

                    Brebis breb = (Brebis)entit;
                    Console.WriteLine("Brebis se situant en : {0},{1}, HP : {2}, EP : {3}", breb.x, breb.y, breb.HP, breb.EP);
                    if (breb.EP == 0)
                    {
                        breb.ConvertPVToPE();
                        Console.WriteLine("La brebis perd 1PV et le transforme en PE");

                    }
                    if (CheckDie(breb) == true)
                    {
                        DestroyObject(entit);
                        Console.WriteLine("La brebis n'a plus de PV, elle meurt");
                        Meat meat = new Meat(breb.x, breb.y);
                        sim.AddEntity(meat);
                    }
                    else
                    {
                        List<Entity> list = NearbyEntities(breb, listOfEntities);
                        breb.Hunt(list, sim);
                        if (breb.pregnancy > 1 && breb.pregnant == true)
                        {
                            Random rand = new Random();
                            int a  = rand.Next(0,1);
                            string Sex;
                            if (a == 0)
                            {
                                Sex = "Femelle";
                            }
                            else
                            {
                                Sex = "Male";
                            }
                            Brebis enfant = new Brebis(breb.x,breb.y,breb.HP,breb.EP,0,breb.VisionRadius,breb.ContactRadius,breb.speed,Sex);
                            Console.WriteLine("Une brebis naît en {0}, {1}", enfant.x, enfant.y);
                            sim.AddEntity(enfant);
                            breb.pregnant = false;
                            breb.pregnancy = 0;
                        }
                        breb.grow();
                        breb.EP--;
                    }


                }
                catch { }

                try
                {   
                    
                    Herbe herb = (Herbe)entit;
                    herb.lastreproduiced++;
                    List<OrganicMat> list = NearbyOrgaMat(herb, listOfEntities);
                    if (herb.EP == 0)
                    {
                        herb.ConvertPVToPE();

                    }
                    if (CheckDie(herb) == true)
                    {
                        DestroyObject(entit);
                    }
                    else if (herb.lastreproduiced > 2)
                    {
                        herb.Reproduce(sim);
                    }
                    

                    else if (list.Count > 0)
                    {
                        herb.Eat(list[0], sim);
                    }
                    
                    herb.toage();
                    herb.EP--;


                }
                catch { }

                try
                {

                    Meat meat = (Meat)entit;
                    meat.Age();
                    if (meat.age > 5)
                    {
                        Console.WriteLine("La viande se situant en {0} {1} s'est transformée en déchet organique", meat.x, meat.y);
                        OrganicMat mat = new OrganicMat(meat.x,meat.y);
                        sim.DestroyObject(meat);
                        sim.AddEntity(mat);
                       
                    }


                }
                catch { }

            });

            
        }

    }
}
