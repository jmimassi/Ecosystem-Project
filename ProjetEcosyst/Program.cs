using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEcosyst
{
    class Program
    { 
        public static void Main(string[] args)
        {


            //Entity proie = new(0, 0);

            //Animal chasseur = new Animal(10, 10, 10, 10,1, 5, 5, 2, "Male");

            //int i = 5;

            //while (i > 0) {

            //    Console.WriteLine(chasseur.x);
            //    Console.WriteLine(chasseur.y);

            //    chasseur.Move(proie);

            //    Console.WriteLine(chasseur.x);
            //    Console.WriteLine(chasseur.y);
            //    i--;
            //}

            // Brebis breb = new Brebis(0, 0, 10, 10, 0, 5, 1, 2, "Male");
            //Herbe herb = new Herbe(3, 0, 1, 1, 1, 1, 1);

            //List<Entity> plants = new List<Entity>();

            //plants.Add(herb);
            //Console.WriteLine(breb.x);
            //breb.Hunt(plants);
            //Console.WriteLine(breb.x);
            //breb.Hunt(plants);
            List<Entity> list = new List<Entity>();

            Ours ours1 = new Ours(0, 0, 10, 10, 1, 7, 2, 3, 3, "Male");
            Ours ours2 = new Ours(20, 10, 10, 10, 1, 7, 2, 3, 3, "Male");
            Ours ours3 = new Ours(-10, -11, 10, 10, 1, 4, 2, 3, 3, "Male");
            list.Add(ours1);
            list.Add(ours2);
            list.Add(ours3);
            Brebis breb1 = new Brebis(0, 5, 5, 5, 1, 5, 1, 2, "Male");
            Brebis breb2 = new Brebis(15, -10, 7, 5, 1, 5, 1, 2, "Male");
            Brebis breb3 = new Brebis(-10, -10, 3, 5, 1, 5, 1, 2, "Male");
            list.Add(breb1);
            list.Add(breb2);
            list.Add(breb3);
            Herbe herb1 = new Herbe(15, -9, 1, 1, 1, 2, 5);
            Herbe herb2 = new Herbe(5, 10, 1, 1, 1, 2, 5);
            Herbe herb3 = new Herbe(10, 10, 1, 1, 1, 2, 5);
            Herbe herb4 = new Herbe(17, 22, 1, 1, 1, 2, 5);
            Herbe herb5 = new Herbe(-10, -10, 1, 1, 1, 2, 5);
            Herbe herb6 = new Herbe(0, -8, 1, 1, 1, 2, 5);
            list.Add(herb1);    
            list.Add(herb2);
            list.Add(herb3);
            list.Add(herb4);
            list.Add(herb5);
            list.Add(herb6);
            Simulation sim = new Simulation(list);

            int clock = 4; 
            while (clock > 0)
            {
                sim.Update(sim);
                Thread.Sleep(2500);
                clock--;
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");
                Console.WriteLine("                     ");

            }
        }
        

    }
}