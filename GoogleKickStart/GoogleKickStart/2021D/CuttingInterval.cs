using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class CuttingInterval
	{
		public static void Run()
		{
			//TLE

			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{

				info = Console.ReadLine().Split(' ').ToList();
				int intervalCou = Convert.ToInt32(info[0]);
				int maxCutPos = Convert.ToInt32(info[1]);

				//int rows = Convert.ToInt32(Console.ReadLine());
				//List<List<int>> matrix = new List<List<int>>();
				List<List<int>> intervals = new List<List<int>>();
				List<List<int>> newIntervals = new List<List<int>>();

				for (int j = 0; j < intervalCou; j++)
				{
					intervals.Add(Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList());
				}

				//  map to 1D line
				HashSet<int> line = new HashSet<int>();
				for (int j = 0; j < intervals.Count; j++)
				{
					line.Add(intervals[j][0]);
					line.Add(intervals[j][1]);
				}

				Dictionary<int, int> cutPoint_cou = new Dictionary<int, int>();

				int cutCou = 1;
				bool cutDicInit = false;
				int maxCouCutPont = 0;
				while (cutCou <= maxCutPos)
				{
					List<int> lines = line.Select(l => l).OrderBy(l => l).ToList();

					List<int> allCutPoints = new List<int>();

					if (cutDicInit)
					{
						for (int j = 0; j < lines.Count - 1; j++)
						{
							if (lines[j] == maxCouCutPont)
							{
								allCutPoints.Add((lines[j] + lines[j + 1]) / 2);
							}
							if (j > 0)
							{
								allCutPoints.Add((lines[j] + lines[j - 1]) / 2);
							}
						}
					}
					else
					{
						for (int j = 0; j < lines.Count - 1; j++)
						{
							allCutPoints.Add((lines[j] + lines[j + 1]) / 2);
						}
					}

					if (cutDicInit)
					{
						if (cutPoint_cou.Count > 1)
						{
							List<int> vals= cutPoint_cou.OrderByDescending(k => k.Value).Select(k => k.Key).ToList();

							allCutPoints.Add(vals[0]);
							allCutPoints.Add(vals[1]);
						}
						if (cutPoint_cou.Count == 1)
						{
							List<int> vals = cutPoint_cou.OrderByDescending(k => k.Value).Select(k => k.Key).ToList();

							allCutPoints.Add(vals[0]);
						}
						else
						{
							allCutPoints.Add(lines[0]);
						}
					}

					foreach (int cutPoint in allCutPoints)
					{
						List<List<int>> tempNewIntervals = new List<List<int>>();

						foreach (List<int> interval in intervals)
						{
							if (cutPoint > interval[0] && cutPoint < interval[1])
							{
								tempNewIntervals.Add(new List<int>() {interval[0], cutPoint});
								tempNewIntervals.Add(new List<int>() {cutPoint, interval[1]});
							}
							else
							{
								tempNewIntervals.Add(interval);
							}
						}

						// get max cut intervals cou point
						if (tempNewIntervals.Count >= newIntervals.Count)
						{
							if (!cutPoint_cou.ContainsKey(cutPoint))
							{
								cutPoint_cou.Add(cutPoint, tempNewIntervals.Count);
							}

							maxCouCutPont = cutPoint;
							newIntervals = tempNewIntervals.ToList();
						}

						
					}

					line = new HashSet<int>();
					for (int j = 0; j < newIntervals.Count; j++)
					{
						line.Add(newIntervals[j][0]);
						line.Add(newIntervals[j][1]);
					}

					if (cutDicInit)
					{
						cutPoint_cou.Remove(maxCouCutPont);
					}

					intervals = newIntervals.ToList();

					cutDicInit = true;
					cutCou++;
				}

				 
				Console.WriteLine($"Case #{i + 1}: {intervals.Count}");
			}



		}


	}
}
