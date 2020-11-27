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
		/// 參考 cpp ver
		/// 10^9  真的就要 long  int馬上吃Wrong Answer
		/// 應該做到C++ 100%轉C#了  但是test case 3 還是TLE 怪 目前沒招  明明C++已經全pass了  
		/// </summary>
		public static void Run()
		{
			List<string> info = new List<string>();

			long caseCou = Convert.ToInt64(Console.ReadLine());

			for (long o = 0; o < caseCou; o++)
			{

				info = Console.ReadLine().Split(' ').ToList();
				long cou = Convert.ToInt64(info[0]);
				long max = Convert.ToInt64(info[1]);
				List<long> eles = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToList();
				for (int j = 0; j < eles.Count; j++)
				{
					eles[j] -= 1;
				}
				int n = eles.Count;
				eles.Sort();
				long ans = long.MaxValue, ca = 0;
				List<long> pq1 = new List<long>(); 
				List<long> pq2 = new List<long>();
				for (int i = 0; i < n; i++)
				{
					ca += eles[n-1] - eles[i];
					pq1.Add(eles[i]);
				}
				pq1.Sort();
				for (int i = 0; i < n; i++)
				{
					int j = (i + n - 1) % n;
					long x2 = eles[j] + (i > 0 ? max : 0);
					while (pq1.Count > 0 && Math.Abs(x2 - pq1.First()) > Math.Abs(x2 - pq1.First() - max))
					{
						ca += Math.Abs(x2 - pq1.First() - max) - Math.Abs(x2 - pq1.First());
						pq2.Add(pq1.First()+max);
						//pq2.Sort();
						pq1.RemoveAt(0);
					}

					ans = ans < ca ? ans : ca;
					List<long> v = new List<long>();
					while (pq2.Count> 0 && eles[i]+max>pq2.First())
					{
						v.Add(pq2.First());
						ca -= pq2.First() - x2;
						ca += eles[i] + max - pq2.First();
						pq2.RemoveAt(0);

					}

					ca += (eles[i] + max - x2) * (pq1.Count - pq2.Count);
					foreach (var ve in v)
					{
						pq1.Add(ve);
					}
					//pq1.Sort();
				}

				Console.WriteLine($"Case #{o + 1}: {ans}");

			}

		}


		//這邊利用之前看過一篇心得的 水平線上往一個點移動最小總移動量 中位數
		//但是轉成環之後   就變成往前  往後移都可以  都有可能更短  就更難一層  就沒解開
		public static void Run2()
		{

			List<long> nums = new List<long>();
			List<string> info = new List<string>();

			long caseCou = Convert.ToInt64(Console.ReadLine());

			for (long i = 0; i < caseCou; i++)
			{

				info = Console.ReadLine().Split(' ').ToList();
				long cou = Convert.ToInt64(info[0]);
				long max = Convert.ToInt64(info[1]);
				long max_half = max / 2;
				List<long> eles = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToList();

				long minDist = long.MaxValue;

				long eMax = eles.Max(), eMin = eles.Min();
				if (eMax - eMin < max_half && eles.Count > 1000)
				{
					var elesOrder = eles.OrderBy(e => e).ToList();
					long idx = elesOrder.Count / 2;
					List<long> idxs = new List<long>() { idx + 1 };
					for (int d = 0; d < 3; d++)
					{
						long polong = idxs[d];
						for (int j = 0; j < elesOrder.Count; j++)
						{
							long totalDist = 0;
							if (j != d)
							{
								long dist = Math.Abs(elesOrder[j] - elesOrder[d]);
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
						for (long k = 0; k < eles.Count; k++)
						{
							if (j != k)
							{
								long dist = Math.Abs(eles[j] - eles[j]);
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
