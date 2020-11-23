using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class MaximumCoins
	{


		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{

				//info = Console.ReadLine().Split(' ').ToList();
				//int intervalCou = Convert.ToInt32(info[0]);
				//int duration = Convert.ToInt32(info[1]);

				int rows = Convert.ToInt32(Console.ReadLine());
				List<List<int>> matrix = new List<List<int>>();

				for (int j = 0; j < rows; j++)
				{
					matrix.Add(Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList());
				}

				//  31 21 11 12 13
				List<List<int>> start = new List<List<int>>();
				start.Add(new List<int>() {1, 1});
				for (int j = 2; j <= rows; j++)
				{
					start.Add(new List<int>() {j, 1});
					start.Add(new List<int>() {1, j});
				}

				long max = 0;
				for (int j = 0; j < start.Count; j++)
				{
					long total = 0;
					for (int sRow = start[j][0] - 1, sCol = start[j][1] - 1; sRow < rows && sCol < rows; sRow++, sCol++)
					{
						total += matrix[sRow][sCol];
					}

					if (total > max)
						max = total;
				}

				Console.WriteLine($"Case #{i + 1}: {max}");

			}



		}
	}
}
