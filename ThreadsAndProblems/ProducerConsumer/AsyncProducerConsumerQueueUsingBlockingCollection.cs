using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndProblems.ProducerConsumer
{
    //More information about 'BlockingCollection' https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/blockingcollection-overview
    public class AsyncProducerConsumerQueue<T> : IDisposable
    {
        private readonly Action<T> m_consumer;
        private readonly BlockingCollection<T> m_queue;
        private readonly CancellationTokenSource m_cancelTokenSrc;

        public AsyncProducerConsumerQueue(Action<T> consumer)
        {
            m_consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
            m_queue = new BlockingCollection<T>(new ConcurrentQueue<T>());
            m_cancelTokenSrc = new CancellationTokenSource();

            for (int i = 0; i < 5; i++)
                Task.Factory.StartNew(() => ConsumeLoop(m_cancelTokenSrc.Token));

            //new Thread(() => ConsumeLoop(m_cancelTokenSrc.Token)).Start();
        }

        public void Produce(T value)
        {   
                m_queue.Add(value);
        }

        private void ConsumeLoop(CancellationToken cancelToken)
        {
            while (!cancelToken.IsCancellationRequested)
            {
                try
                {
                    var item = m_queue.Take(cancelToken);
                    Console.WriteLine("=====Thread #{1} Consuming item: {0} ===== ", item, Thread.CurrentThread.ManagedThreadId);
                    m_consumer(item);
                    Console.WriteLine("===== Finished Consuming =====");
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            }
        }

        #region IDisposable

        private bool m_isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!m_isDisposed)
            {
                if (disposing)
                {
                    m_cancelTokenSrc.Cancel();
                    m_cancelTokenSrc.Dispose();
                    m_queue.Dispose();
                }

                m_isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
