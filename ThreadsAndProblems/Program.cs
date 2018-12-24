using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadsAndProblems.ProducerConsumer;

namespace ThreadsAndProblems
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //_10Producers1ConsumerAsync pc = new _10Producers1ConsumerAsync();
        //    //pc.Main();


        //    AsyncProducerConsumerQueue<string> producerConsumer = new AsyncProducerConsumerQueue<string>(Console.WriteLine);
        //    var producers = Enumerable.Range(0, 10).Select(async x =>
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //             producerConsumer.Produce(i.ToString() + " Produced by: " + x + " ");
        //        }
        //    });

        //    Task.WaitAll(producers.ToArray());
        //    //for (int i = 0; i < 1000; i++)
        //    //{
        //    //    producerConsumer.Produce(i.ToString());
        //    //}
        //    Console.ReadKey();
        //}
    }
}
