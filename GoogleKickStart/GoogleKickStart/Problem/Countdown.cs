using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart.Problem
{
	class Countdown
	{

		public  static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());



			for (int c = 0; c < caseCou; c++)
			{
				int totalCountDown = 0;

				info = Console.ReadLine().Split(' ').ToList();
				int countdown = Convert.ToInt32(info[1]);
				nums = Console.ReadLine().Split(' ').Where(s => !String.IsNullOrWhiteSpace(s)).Select(s => Convert.ToInt32(s)).ToList();

				int accumulateCuontdown = 0;
				for (int i = countdown - 1; i < nums.Count; ++i)
				{
					int ok = 1;
					for (int j = 1; j <= (countdown & ok); ++j)
					{
						if (nums[i + 1 - j] != j)
						{
							ok = 0;
						}
					}
					totalCountDown += ok;
				}

				Console.WriteLine($"Case #{c + 1}: {totalCountDown}");

				
			}



		}

	}
}
