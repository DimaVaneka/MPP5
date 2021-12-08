using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
namespace laba4
{
	public static class AssemblyLoader
    {
		public static void Load(string assemblyPath)
		{
			//Загружаем сборку с заданным путем, переданным в конструкторе метода
			// абстрактный класс. Он содержит статические методы работы со сборкой. Эти методы позволяют, например, загружать сборку;
			Assembly assembly = Assembly.LoadFrom(assemblyPath);

			//Получает типы, определенные в этой сборке
			Type[] types = assembly.GetTypes().OrderBy(x => x.Namespace).ThenBy(x => x.Name).ToArray();


			//Проходим по типам и выводим имена всех паблик типов
			foreach (Type type in types)
            {
				if (type.IsPublic)
				{
					Console.WriteLine(type.FullName);
				}
            }
		}
    }
}
