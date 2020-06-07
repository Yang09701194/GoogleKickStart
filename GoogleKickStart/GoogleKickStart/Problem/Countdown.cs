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



			for (int i = 0; i < caseCou; i++)
			{
				int totalCountDown = 0;

				info = Console.ReadLine().Split(' ').ToList();
				int countdown = Convert.ToInt32(info[1]);
				nums = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();

				int accumulateCuontdown = 0;
				for (int j = 0; j <= nums.Count - countdown; j++)
				{
					if (nums[j] == countdown)
					{
						bool isCd = true;
						//int jump = -1;
						for (int k = 0; k < countdown; k++)
						{
							if (nums[j + k] == countdown - k)
							{
								//jump++;
							}
							else
							{
								isCd = false;
								break;
							}
						}

						if (isCd)
						{
							totalCountDown++;
						}
						//if(jump > 0)
						//	j += jump;

					}


				}

				Console.WriteLine($"Case #{i + 1}: {totalCountDown}");

				
			}



		}

	}
}
