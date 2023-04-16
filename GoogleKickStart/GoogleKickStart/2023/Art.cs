using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class Art
	{


		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			int turn = 0;

			List<long> points = new List<long>(){0};
			long curr = 0;
			while (curr < 1000000000000)
			{
				curr += 26 * ++turn;
				points.Add(curr);
			}

			for (int i = 0; i < caseCou; i++)
			{
				string res = "";
				var pos = Convert.ToInt64(Console.ReadLine());
				
				//A 65
				for (int j = 1; j < points.Count; j++)
				{
					if (pos <= points[j])
					{
						//j times
						long idx = (pos - 1 - points[j-1]) / j;
						res = ((char)(65 + idx)).ToString();
						break;
					}
				}

				Console.WriteLine($"Case #{i + 1}: {res}");
			}



		}

	}
}