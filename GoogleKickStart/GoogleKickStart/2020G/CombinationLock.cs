using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class CombinationLock
	{

		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{

				info = Console.ReadLine().Split(' ').ToList();
				int cou = Convert.ToInt32(info[0]);
				int max = Convert.ToInt32(info[1]);
				int max_half = max / 2;
				List<int> eles = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();




				long minDist = long.MaxValue;

				int eMax = eles.Max(), eMin = eles.Min();
				if (eMax - eMin < max_half && eles.Count > 1000)
				{
					var elesOrder = eles.OrderBy(e => e).ToList();
					int idx = elesOrder.Count / 2;
					List<int> idxs = new List<int>() { idx + 1 };
					for (int d = 0; d < 3; d++)
					{
						int point = idxs[d];
						for (int j = 0; j < elesOrder.Count; j++)
						{
							long totalDist = 0;
							if (j != d)
							{
								int dist = Math.Abs(elesOrder[j] - elesOrder[d]);
								if (dist > max_half)
									dist = max - dist;
								totalDist += dist;
							}

							if (minDist > totalDist)
								minDist = totalDist;
						}

					}


				}
				else//這段就可以pass 2個test   最後一個TLE
				{
					for (int j = 0; j < eles.Count; j++)
					{
						long totalDist = 0;
						for (int k = 0; k < eles.Count; k++)
						{
							if (j != k)
							{
								int dist = Math.Abs(eles[j] - eles[k]);
								if (dist > max_half)
									dist = max - dist;
								totalDist += dist;
							}
						}

						if (minDist > totalDist)
							minDist = totalDist;
					}
				}

				Console.WriteLine($"Case #{i + 1}: {minDist}");

			}


		}

	}
}
