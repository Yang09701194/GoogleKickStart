using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class MetalHarvest
	{
		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{
				//int totalBreskDays = 0;
				List<int> breakDays = new List<int>();

				info = Console.ReadLine().Split(' ').ToList();
				int intervalCou = Convert.ToInt32(info[0]);
				int duration = Convert.ToInt32(info[1]);

				List<int[]> intervals = new List<int[]>();
				for (int j = 0; j < intervalCou; j++)
				{
					nums = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();
					intervals.Add(new int[]{nums[0], nums[1]});
				}

				var orderedIntervals = intervals.OrderBy(t => t[0]);
				int totalDeployCou = 0;
				int lastIntervalEnd = -1;
				foreach (int[] interval in orderedIntervals)
				{
					if (lastIntervalEnd < interval[0])
					{

					}

				}

				Console.WriteLine($"Case #{i + 1}: {0}");
			}




		}



	}
}
