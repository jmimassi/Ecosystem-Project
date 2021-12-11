using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Entity
    {
        public int x;
        public int y;
        protected Entity(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

     
    }
}
