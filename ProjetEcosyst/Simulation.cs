using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    internal class Simulation
    {
        public int speedOfLife;
        public List<Entity> listOfEntities = new List<Entity>();

        //public void Run()
        //{


        //}

        public static List<Entity> NearbyEntities(Animal chasseur)
        {
            List<Entity> listOfNearbyEntities = new List<Entity>();
            int count = listOfNearbyEntities.Count;

            for (int i = 0; i < count; i++)
            {
                int distancex = listOfNearbyEntities[i].x - chasseur.x;
                int distancey = listOfNearbyEntities[i].y - chasseur.y;

                int pythagore = distancex*distancex + distancey*distancey;

                if (Math.Sqrt(pythagore) < chasseur.VisionRadius)
                {
                    listOfNearbyEntities.Add(listOfNearbyEntities[i]);
                }
            }



            return listOfNearbyEntities;
        }


        public void AddEntity(Entity entité)
        {
            listOfEntities.Add(entité);
        }


        //public void update(Entity truc)
        //{
        //    if (typeof(truc) != typeof(Meat))
        //    {
        //        truc.age
        //        if truc.Age 
        //    }
        //}

    }
}
