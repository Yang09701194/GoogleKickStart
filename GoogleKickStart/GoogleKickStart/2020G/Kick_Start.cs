using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class Kick_Start
	{

		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{
				//int totalBreskDays = 0;

				//info = Console.ReadLine().Split(' ').ToList();
				//int intervalCou = Convert.ToInt32(info[0]);
				//int duration = Convert.ToInt32(info[1]);
				string info2 = Console.ReadLine();

				List<int> indexOfKicks = new List<int>();
				int find = 0;
				while (true)
				{
					find = info2.IndexOf("KICK", find);
					if (find >= 0)
					{
						indexOfKicks.Add(find);
						find += 1;
					}
					else
						break;
				}

				find = 0;
				List<int> indexOfStarts = new List<int>();
				while (true)
				{
					find = info2.IndexOf("START", find);
					if (find >= 0)
					{
						indexOfStarts.Add(find);
						find += 1;
					}
					else
						break;
				}

				int res = 0;
				foreach (int indexOfKick in indexOfKicks)
				{
					res += indexOfStarts.Count(idx => idx > indexOfKick);
				}

				Console.WriteLine($"Case #{i + 1}: {res}");

			}




		}



	}
}
