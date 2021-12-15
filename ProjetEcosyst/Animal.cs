using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public abstract class Animal : LifeForm
    {
        public int VisionRadius;
        public int ContactRadius;
        protected string Sex;
        protected int speed;

        protected Animal(int x, int y, int HP, int EP, int age, int VisionRadius, int ContactRadius, int speed, string Sex) :
        base(x, y, HP, EP, age)
        {
            this.VisionRadius = VisionRadius;
            this.ContactRadius = ContactRadius;
            this.Sex = Sex;
            this.speed = speed;
        }




        public void Move(Entity prey)
        {
            Random rnd = new Random();
            int numx = rnd.Next(-1, 1);
            int numy = rnd.Next(-1, 1);

            while (numx == 0 & numy == 0)
            {
                numx = rnd.Next(-1, 1);
                numy = rnd.Next(-1, 1);
            }

            if (prey == null)
            {
                this.x = this.x + numx * this.speed;
                this.y = this.y + numy * this.speed;
            }

            else
            {
                int directx = prey.x - this.x;
                int directy = prey.y - this.y;
                try {
                    directx = directx / (Math.Abs(directx));

                    this.x = this.x + directx * this.speed;
                }
                catch(System.DivideByZeroException)
                {
                    
                }
                try
                {
                    directy = directy / (Math.Abs(directy));

                    this.y = this.y + directy * this.speed;
                }
                catch (System.DivideByZeroException)
                {

                }



            }
            Console.WriteLine("Se déplace en {}, {}",this.x,this.y);
        }

        public void Fecond()
        {

        }


        

    }
}
