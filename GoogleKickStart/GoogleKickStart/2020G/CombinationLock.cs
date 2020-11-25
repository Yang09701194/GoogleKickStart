using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class CombinationLock
	{



		/// <summary>
		/// 參考
		/// </summary>
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
				for (int j = 0; j < eles.Count; j++)
				{
					eles[j] -= 1;
				}
				int n = eles.Count;
				eles.Sort();
				long ans = int.MaxValue, ca = 0;
				List<int> pq1 = new List<int>(); 
				List<int> pq2 = new List<int>();
				for (int c = 0; c < n; c++)
				{
					ca += eles[0] - eles[c];
					pq1.Add(eles[c]);
				}
				for (int c = 0; c < pq1.Count; c++)
				{
					int j = (c + n - 1) % n;
					int x2 = eles[j] + i == 0 ? max : 0;
					while (pq1.Count > 0 && Math.Abs(x2 - pq1.First()) > Math.Abs(x2 - pq1.First() - max))
					{
						ca += Math.Abs(x2 - pq1.First()) - Math.Abs(x2 - pq1.First());
						pq2.Add(pq1.First()+max);
						pq2.Sort();
						pq1.RemoveAt(0);
					}

					ans = ans < ca ? ans : ca;
					List<int> v = new List<int>();
					while (pq2.Count> 0 && eles[c]+max>pq2.First())
					{
						v.Add(pq2.First());
						ca -= pq2.First() - x2;
						ca += eles[c] + max - pq2.First();
						pq2.RemoveAt(0);
					}

					ca += (eles[i] + max - x2) * (pq1.Count - pq2.Count);
					foreach (var ve in v)
					{
						pq1.Add(ve);
					}
					pq1.Sort();
				}

				Console.WriteLine($"Case #{i + 1}: {ans}");


			}


		}


		//這邊利用之前看過一篇心得的 水平線上往一個點移動最小總移動量 中位數
		//但是轉成環之後   就變成往前  往後移都可以  都有可能更短  就更難一層  就沒解開
		public static void Run2()
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
