using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public class Simulation
    {
        private int speedOfLife;
        private List<Entity> listOfEntities = new List<Entity>();

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

        public void CheckDie(LifeForm ent)
        {
            if ( ent.HP == 0)
            {
                int x = ent.x;
                int y = ent.y;
                try
                {
                    
                }
                catch
                {

                }
                DestroyObject(ent);
            }
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
