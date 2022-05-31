using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadDemo
{

    class ProducerConsumer
    {
        Queue<int> q = new Queue<int>();
        public void Produce()
        {
            Random num = new Random();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(num.Next(1,10));
                q.Enqueue(num.Next(1,10));
               
            }
            Console.WriteLine("\n");
        }

        public void Consume()
        {
            int sum = 0;
          foreach(int item in q)
            {
                Console.WriteLine("Item in queue: " + item);
                //Console.ReadLine();
                sum = sum + item;
                Console.WriteLine("Total is: " +sum);
                //Console.ReadLine();
                if (sum > 30000)
                    sum = 0;
            }
            Console.ReadLine();  
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter ProducerCount");
            int ProducerCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter ProducerSleepTime in milliseconds");
            int ProducerSleepTime = Convert.ToInt32(Console.ReadLine());

            ProducerConsumer pc = new ProducerConsumer();

            Task Producer = Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < ProducerCount; j++)
                {
                    pc.Produce();

                }            
            }
            );
            Producer.Wait(ProducerSleepTime);

            Task Consumer = Task.Factory.StartNew(() =>
            {
                pc.Consume();
            }
            );
            Consumer.Wait();
        }
    }
}
