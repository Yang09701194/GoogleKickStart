using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class RecordBreaker
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
				int days = Convert.ToInt32(info[0]);
				nums = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();

				int previousMax = nums[0];

				for (int j = 0; j < nums.Count; j++)
				{
					if (j > 0 && nums[j - 1] > previousMax)
						previousMax = nums[j - 1];

					if (j == 0)
					{
						if (nums.Count == 1)
						{
							breakDays.Add(j);
							break;
						}

						if (nums[j] > nums[j + 1])
						{
							breakDays.Add(j);

						}
						//bool isAllGreater = true;
						//for (int k = 1; k < nums.Count; k++)
						//{
						//	if (nums[j] <= nums[k])
						//		isAllGreater = false;
						//}

						//if (isAllGreater)
						//{
						//	breakDays.Add(j);
						//	break;
						//}
					}

					if (j == nums.Count - 1)
					{
						if (nums[j] > previousMax)
						{
							breakDays.Add(j);
							break;
						}
					}

					//int previousBreakDays = breakDays.Any() ? breakDays.Last() : 0;
					//bool isAdded = false;
					if (nums[j] <= previousMax)
						continue;

					//for (int k = j+1; k < nums.Count; k++)
					//{
						if (nums[j] > nums[j+1])
						{
							breakDays.Add(j);
						}
						//else
						//{
						//	break;
						//}
					//}
				}
				
				Console.WriteLine($"Case #{i + 1}: {breakDays.Count}");
				
			}



		}

	}
}