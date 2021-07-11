using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class ArithmeticSquare
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

				//int rows = Convert.ToInt32(Console.ReadLine());
				List<List<int>> matrix = new List<List<int>>();

				for (int j = 0; j < 3; j++)
				{
					matrix.Add(Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList());
				}

				matrix[1].Insert(1, 0);  //  empty pos

				Dictionary<int, int> mediumTimes = new Dictionary<int, int>();
				Action<int> addMed = (num) =>
				{
					if (num % 2 == 0)
					{
						num /= 2;
						if (!mediumTimes.ContainsKey(num))
						{
							mediumTimes.Add(num, 1);
						}
						else
						{
							mediumTimes[num]++;
						}
					}
					
				};


				addMed((matrix[0][0] + matrix[2][2]));
				addMed((matrix[0][1] + matrix[2][1]));
				addMed((matrix[0][2] + matrix[2][0]));
				addMed((matrix[1][0] + matrix[1][2]));

				List<int> allPossible = new List<int>() {0};

				int crossCou = 0;
				int MaxCou = 0;
				if (mediumTimes.Count > 0)
				{
					var maxTimes = mediumTimes.OrderByDescending(m => m.Value).First();
					

					allPossible = mediumTimes.Where(k => k.Value == maxTimes.Value).Select(k => k.Key).ToList();
					crossCou = maxTimes.Value;
				}

				foreach (int possVal in allPossible)
				{
					int cou = crossCou;
					int middle = possVal;
					matrix[1][1] = middle;

					if (matrix[0][0] - matrix[0][1] == matrix[0][1] - matrix[0][2])
					{
						cou++;
					}
					if (matrix[0][0] - matrix[1][0] == matrix[1][0] - matrix[2][0])
					{
						cou++;
					}
					if (matrix[2][0] - matrix[2][1] == matrix[2][1] - matrix[2][2])
					{
						cou++;
					}
					if (matrix[2][2] - matrix[1][2] == matrix[1][2] - matrix[0][2])
					{
						cou++;
					}

					if (cou > MaxCou)
					{
						MaxCou = cou;
					}
				}


				Console.WriteLine($"Case #{i + 1}: {MaxCou}");
			}



		}

	}
}
