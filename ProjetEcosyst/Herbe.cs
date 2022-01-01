using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    public class Herbe : Plant
    {
        public Herbe(int x, int y,int HP,int EP,int age ,int rootRadius, int seedingRadius) : base(x, y,HP,EP,age,rootRadius,seedingRadius)
        {

        }

        public void Reproduce(Simulation sim)
        {
            Random rand = new Random();
            int addx = 0;
            int addy = 0;
            addx = rand.Next(1, this.SeedingRadius);
            addy = rand.Next(1, this.SeedingRadius);
            while (Math.Sqrt(addx * addx + addy * addy) > this.SeedingRadius)
            {
                addx = rand.Next(1, this.SeedingRadius);
                addy = rand.Next(1, this.SeedingRadius);
            }
            Herbe herbe = new Herbe( this.x+addx, this.y+addy,1,1,1,this.RootRadius, this.SeedingRadius);
            Console.WriteLine("Une nouvelle herbe apparait en {0},{1}", herbe.x,herbe.y);
            sim.AddEntity( herbe );
        }


    }
}
