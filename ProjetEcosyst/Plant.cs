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
            this.EP += 2;
            sim.DestroyObject(orga);
        }

        


    }
}
