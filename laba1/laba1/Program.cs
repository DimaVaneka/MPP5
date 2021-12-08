using System;
using System.Threading;

namespace laba1
{
    class MainClass
    {
        public static void Task1()
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("Task__1, i = {0};", i);
			}
		}
                
		public static void Task2()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("Task____2, i = {0};", i);
            }
        }
        
		public static void Task3()
        {
            for (int i = 0; i < 3000; i++)
            {
                Console.WriteLine("Task______3, i = {0};", i);
            }
        }

		public static void Task4()
        {
            for (int i = 0; i < 400; i++)
            {
                Console.WriteLine("Task________4, i = {0};", i);
            }
        }
        
        public static void Main(string[] args)
        {
			TaskQueue queue = new TaskQueue(2);

			queue.EnqueueTask(Task1);
			queue.EnqueueTask(Task2);
			queue.EnqueueTask(Task3);
			queue.EnqueueTask(Task4);

			Thread.Sleep(10000);
		}

    }
}