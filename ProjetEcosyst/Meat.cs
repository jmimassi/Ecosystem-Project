using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public class Meat : Entity
    {
        public int age;
        public Meat(int x,int y) : base(x,y)
        {
            this.age = 0;
        }

        public void Age()
        {
            this.age++;
        }

    }
}
