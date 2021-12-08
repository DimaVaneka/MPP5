using System;
using System.Collections.Generic;
using System.Threading;

namespace laba1
{
    public class TaskQueue
    {
		public delegate void TaskDelegate();

		static List<Thread> threads = new List<Thread>();
		static List<TaskDelegate> TaskDelegates = new List<TaskDelegate>();


		public TaskQueue(int threadsCount)
		{
			threadsCount = Math.Abs(threadsCount);
			
			if (threadsCount == 0)
			{
				threadsCount = 1;
			}

			for (int i = 0; i < threadsCount; i++)
			{
				Thread thread = new Thread(ThreadProc);
				thread.IsBackground = true;
				thread.Start();
				threads.Add(thread);
			}
		}

		public void EnqueueTask(TaskDelegate task)
		{
			TaskDelegates.Add(task);
		}
              
        public void ThreadProc()
		{
			TaskDelegate del = null;
			Thread.Sleep(50);

			while (true)
			{
				lock (this)
				{
					if (TaskDelegates.Count > 0)
					{                  
						del = TaskDelegates[0];
						TaskDelegates.RemoveAt(0);
      				}
				}

				if (del != null)
				{
					del();
					del = null;
				}
			}
		}
    }
}
