using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class LifeForm : Entity
    {
        protected int HP;
        protected int EP;
        protected int age;
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

        public virtual void loseE()
        {
            this.EP--;
        }

        public virtual int getHP()
        {
            return this.HP;
        }

        public virtual int getEP()
        {
            return this.EP;
        }
        public void LoseHP(int number)
        {
            this.HP -= number;
        }

        public virtual int getAge()
        {
            return this.age;
        }

        public abstract void Reproduce();
        public abstract void Eat(Entity food);

    }
}
