using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class Untie
	{


		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			
			for (int i = 0; i < caseCou; i++)
			{
				string res = "";
				var seq = (Console.ReadLine()).ToList();

				int chCou = 0;
				int last = 0;
				for (int j = 0; j < seq.Count - 1; j++)
				{
					if (seq[j] == seq[j + 1])
					{
						chCou++;
						j += 1;
					}

					last = j;
				}

				if (last < seq.Count - 1 && seq[0] == seq[seq.Count - 1])
					chCou++;

				Console.WriteLine($"Case #{i + 1}: {chCou}");
			}



		}

	}
}