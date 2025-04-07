using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
	internal class Program
	{
		public static SLL list = new SLL();

		static void Main(string[] args)
		{
			Console.WriteLine("Function [PRINT]");
			list.PrintData();

			Console.WriteLine("Function [Append] 'a'");
			list.Append('a');
			list.PrintList();

			Console.WriteLine("Function [Append] 'b'");
			list.Append('b');
			list.PrintList();

			Console.WriteLine("Function [Append] 'c'");
			list.Append('c');
			list.PrintData();

			Console.WriteLine("Function [Retrieve] '0' ");
			Console.WriteLine(list.Retrieve(0));

			Console.WriteLine("Function [Retrieve] '1' ");
			Console.WriteLine(list.Retrieve(1));

			Console.WriteLine("Function [Retrieve] '2' ");
			Console.WriteLine(list.Retrieve(2));
			list.PrintData();

			Console.WriteLine("\n\nFunction [Insert] 'd' at '0'");
			list.Insert('d', 0);
			list.PrintList();

			Console.WriteLine("Function [Insert] '1' at '1'");
			list.Insert('1', 1);
			list.PrintList();

			Console.WriteLine("Function [Insert] '2' at '2'");
			list.Insert('2', 2);
			list.PrintData();

			//Console.WriteLine("Function [Replace] 'c' with 'e'");
			//list.Replace('e', 2);
			//list.PrintData();

			//Console.WriteLine("Function [Delete] at index 2");
			//list.Delete(2);
			//list.PrintData();


			//Console.WriteLine("Function [FindIndexOf] 'b'");
			//Console.WriteLine("Index found: " + list.IndexOf('b') + "\n\n");


			//Console.WriteLine("Function [Clear]");
			//list.Clear();
			//list.PrintData();

			Console.WriteLine("Function [Size]");
			list.Size();
			list.PrintData();



			Console.ReadKey();
		}
	}
}
