using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Plant : LifeForm
    {
        public int RootRadius;
        public int SeedingRadius;
        public int lastreproduiced = 0;

        protected Plant(int x, int y,int HP,int EP,int age, int rootRadius, int seedingRadius) : base(x, y,HP,EP,age)
        {
            this.RootRadius = rootRadius;
            this.SeedingRadius = seedingRadius;
        }

        public void toage()
        {
            this.age++;
            this.lastreproduiced ++;
        }

        

        public void Eat(OrganicMat orga, Simulation sim)
        {
            this.HP += 2;
            sim.DestroyObject(orga);
        }

        public void Reproduce(Simulation sim)
        {
            Random rand = new Random();
            int xe = rand.next(0,SeedingRadius);
            int ye = rand.next(0,SeedingRadius);
            int distance = Math.Sqrt((xe - this.x)*(xe - this.x)+(ye - this.y)*(ye - this.y))
            while (distance > SeedingRadius)
            {
                int xe = rand.next(0,SeedingRadius);
                int ye = rand.next(0,SeedingRadius);
                int distance = Math.Sqrt((xe - this.x)*(xe - this.x)+(ye - this.y)*(ye - this.y))
            }

            Plant child = new Plant(xe,ye,this.HP,this.EP,0,this.RootRadius,this.SeedingRadius);
            sim.AddEntity(child);
            lastreproduiced = 0;
            
        }


    }
}
