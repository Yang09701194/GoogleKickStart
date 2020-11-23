using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class ATMQueue
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
				int maxWithdraw = Convert.ToInt32(info[1]);
				nums = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();

				//  人的位置  錢/max可提領
				Dictionary<int, int> indexDivisor = new Dictionary<int, int>();
				for (int j = 0; j < nums.Count; j++)
				{
					indexDivisor.Add(j + 1, (int)Math.Ceiling((double)nums[j]/(double)maxWithdraw));
				}

				var orderedData = indexDivisor.OrderBy(d => d.Value); 

				Console.WriteLine($"Case #{i + 1}: {String.Join(" ", orderedData.Select(d => d.Key))}");

			}




		}


	}
}
