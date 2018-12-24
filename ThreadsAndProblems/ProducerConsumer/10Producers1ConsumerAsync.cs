using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ThreadsAndProblems.ProducerConsumer
{
    public class _10Producers1ConsumerAsync
    {
        private BufferBlock<int> queue = new BufferBlock<int>();

        public void Main()
        {
            var producers = Enumerable.Range(0, 10).Select(async x =>
            {
                await Producer();
            });

            var consumer = Consumer();

            Task.WaitAll(producers.ToArray());
            consumer.Wait();

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private async Task Producer()
        {
            var data = Enumerable.Range(1, 5);

            foreach (var item in data)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                await queue.SendAsync(item);
                Console.WriteLine("Producer. Item: {0}, TimeStamp: {1}", item, DateTime.Now);
            }

            queue.Complete();

            return;
        }

        private async Task Consumer()
        {
            while (await queue.OutputAvailableAsync())
            {
                var item = await queue.ReceiveAsync();
                Console.WriteLine("Consumer. Item: {0}, TimeStamp: {1}", item, DateTime.Now);
            }

            return;
        }
    }
}
