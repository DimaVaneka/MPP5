
using System;

namespace laba4
{
    class MainClass
    {
        public static void Main()
        {
			ConsoleKeyInfo keyPressed;
			do
			{
				String assemblyPath = Console.ReadLine();
                		AssemblyLoader.Load(assemblyPath);
				Console.WriteLine("Press Esc to exit.");
                		keyPressed = Console.ReadKey();
			} while (keyPressed.Key != ConsoleKey.Escape);

        }
    }
}
