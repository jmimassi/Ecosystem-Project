using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class LifeForm : Entity
    {
        public int HP;
        public int EP;
        public int age;
        protected LifeForm(int x, int y, int HP, int EP, int age) : base(x, y)
        {
            this.HP = HP;
            this.EP = EP;
            this.age = age;
        }

        public virtual void ConvertPVToPE()
        {
            this.HP--;
            this.EP++;
        }
        public void LoseHP(int number)
        {
            this.HP -= number;
        }

        


    }
}
