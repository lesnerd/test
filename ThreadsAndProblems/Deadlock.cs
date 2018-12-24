using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndProblems
{
    public class RealLifeDeadlock
    {
        static readonly object firstLock = new object();
        static readonly object secondLock = new object();
        static void ThreadJob()
        {
            Console.WriteLine("\t\t\t\tLocking firstLock");
            lock (firstLock)
            {
                Console.WriteLine("\t\t\t\tLocked firstLock");
                // Wait until we're fairly sure the first thread
                // has grabbed secondLock
                Thread.Sleep(1000);
                Console.WriteLine("\t\t\t\tLocking secondLock");
                lock (secondLock)
                {
                    Console.WriteLine("\t\t\t\tLocked secondLock");
                }
                Console.WriteLine("\t\t\t\tReleased secondLock");
            }
            Console.WriteLine("\t\t\t\tReleased firstLock");
        }


        //static void Main()
        //{
        //    new Thread(new ThreadStart(ThreadJob)).Start();
        //    // Wait until we're fairly sure the other thread
        //    // has grabbed firstLock
        //    Thread.Sleep(500);
        //    Console.WriteLine("Locking secondLock");
        //    lock (secondLock)
        //    {
        //        Console.WriteLine("Locked secondLock");
        //        Console.WriteLine("Locking firstLock");
        //        lock (firstLock)
        //        {
        //            Console.WriteLine("Locked firstLock");
        //        }
        //        Console.WriteLine("Released firstLock");
        //    }
        //    Console.WriteLine("Released secondLock");
        //    Console.Read();
        //}
    }

    //Thread 1 acquires lock A.
    //Thread 2 acquires lock B.
    //Thread 1 attempts to acquire lock B, but it is already held by Thread 2 and thus Thread 1 blocks until B is released.
    //Thread 2 attempts to acquire lock A, but it is held by Thread 1 and thus Thread 2 blocks until A is released.
    class Deadlock
    {
        object lockA = new object();
        object lockB = new object();
        void t1() //Thread 1
        {
            lock (lockA)
            {
                lock (lockB)
                {
                    /* ... */
                }
            }
        }
        void t2() //Thread 2 
        {
            lock (lockB)
            {
                lock (lockA)
                {
                    /* ... */
                }
            }
        }
    }
}
