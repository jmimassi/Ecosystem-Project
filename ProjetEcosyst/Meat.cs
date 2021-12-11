using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    internal class Meat : Entity
    {
        public int age;
        public Meat(int x,int y, int age) : base(x,y)
        {
            this.age = age;
        }

    }
}
