using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Plant : LifeForm
    {
        protected int RootRadius;
        protected int SeedingRadius;

        protected Plant(int x, int y, int HP, int EP, int age, int rootRadius, int seedingRadius) : base(x, y, HP, EP, age)
        {
            this.RootRadius = rootRadius;
            this.SeedingRadius = seedingRadius;
        }

        public override void Reproduce()
        {
            /* Dans simulation créer un nouvel objet plante */
        }

    }
}
