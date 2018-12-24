using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndProblems
{
    class Livelock
    {
        public static void Main(string[] args)
        {
            var husband = new Diner("Bob");
            var wife = new Diner("Alice");

            var spoon = new Spoon(husband);

            Task.WaitAll(
                Task.Run(() => husband.EatWith(spoon, wife)),
                Task.Run(() => wife.EatWith(spoon, husband))
                );
        }

        public class Spoon
        {
            public Diner Owner { get; private set; }
            public Spoon(Diner diner)
            {
                Owner = diner;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            public void SetOwner(Diner d)
            {
                Owner = d;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            public void Use()
            {
                Console.WriteLine("{0} has eaten!", Owner.Name);
            }
        }

        public class Diner
        {
            public string Name { get; private set; }
            private bool IsHungry { get; set; }

            public Diner(string n)
            {
                Name = n;
                IsHungry = true;
            }

            public void EatWith(Spoon spoon, Diner spouse)
            {
                while (IsHungry)
                {
                    // Don't have the spoon, so wait patiently for spouse.
                    if (spoon.Owner != this)
                    {
                        try
                        {
                            Thread.Sleep(1);
                        }
                        catch (ThreadInterruptedException e)
                        {
                        }

                        continue;
                    }

                    // If spouse is hungry, insist upon passing the spoon.
                    if (spouse.IsHungry)
                    {
                        Console.WriteLine("{0}: You eat first my darling {1}!", Name, spouse.Name);
                        spoon.SetOwner(spouse);
                        continue;
                    }

                    // Spouse wasn't hungry, so finally eat
                    spoon.Use();
                    IsHungry = false;
                    Console.WriteLine("{0}: I am stuffed, my darling {1}!", Name, spouse.Name);
                    spoon.SetOwner(spouse);
                }
            }
        }
    }

}
