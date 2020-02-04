using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;

namespace CollectionClass
{
    /// <summary>
    /// Class to use System.Collections.Concurrent Classes
    /// </summary>
    internal class ConcurrentCollections
    {
        private BlockingCollection<int> blocking;

        /// <summary>
        /// Provides blocking and bounding capabilities for thread-safe collections.
        /// </summary>
        public void blockingCollection()
        {
            blocking = new BlockingCollection<int>(3);          
            blocking.TryAdd(32);
            Thread thread1 = new Thread(() => InsertTwo(2));
            Thread thread2 = new Thread(InsertOne);

            thread1.Start();
            thread2.Start();
            foreach (var i in blocking)
            {
                Console.WriteLine(i);
            }
            blocking = null;
        }

        /// <summary>
        /// Insert 
        /// </summary>
        /// <param name="i"></param>
        private void InsertTwo(int i)
        {
            blocking.TryAdd(i);
        }

        /// <summary>
        /// Insert 
        /// </summary>
        /// <param name="i"></param>
        private void InsertOne()
        {
            blocking.TryAdd(1);
        }

        /// <summary>
        ///ConcurrentBag-- A thread-safe unordered collection of objects.
        /// </summary>
        public void concurrentBag()
        {
            ConcurrentBag<int> concurrent = new ConcurrentBag<int>();
            concurrent.Add(1);
            concurrent.Add(2);
            concurrent.Add(3);
            foreach (var i in concurrent)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        ///concurrentDictionary-- A Thread-safe collection of key/value pairs that can be accessed by multiple threads concurrently.
        /// </summary>
        public void concurrentDictionary()
        {
            ConcurrentDictionary<int, int> concurrent = new ConcurrentDictionary<int, int>();
            concurrent.TryAdd(1, 11);
            concurrent.TryAdd(2, 12);
            concurrent.TryAdd(3, 54);
            concurrent.TryUpdate(2, 45, 26);
            foreach (var i in concurrent)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        ///ConcurrentStack--  LIFO collection of objects.
        /// </summary>
        public void concurrentStack()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.TryPeek(out int temp);
            Console.WriteLine("Peek" + temp);
            stack.TryPop(out temp);
            Console.WriteLine("Pop" + temp);
            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        ///ConcurrentQueue -- FIFO collection of objects.
        /// </summary>
        public void concurrentQueue()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.TryPeek(out int temp);
            Console.WriteLine("Peek" + temp);
            queue.TryDequeue(out temp);
            Console.WriteLine("Pop" + temp);
            foreach (var i in queue)
            {
                Console.WriteLine(i);
            }
        }
    }
    internal class Collections
    {
        private static void Main(string[] args)
        {
           
            ConcurrentCollections concurrentcollections = new ConcurrentCollections();
            Console.WriteLine("BlockingCollection");
            concurrentcollections.blockingCollection();
            Console.WriteLine("ConcurrentBag");
            concurrentcollections.concurrentBag();
            Console.WriteLine("ConcurrentDictionary");
            concurrentcollections.concurrentDictionary();
            Console.WriteLine("ConcurrentStack");
            concurrentcollections.concurrentStack();
            Console.WriteLine("ConcurrentQueue");
            concurrentcollections.concurrentQueue();
        }
    }
}