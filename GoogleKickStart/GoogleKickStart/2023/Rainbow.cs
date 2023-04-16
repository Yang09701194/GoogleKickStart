using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class Rainbow
	{


		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{
				var len = Console.ReadLine();

				info = Console.ReadLine().Split(' ').ToList();

				var set = new HashSet<int>();

				StringBuilder res = new StringBuilder();
				string result = "";
				if (info.Count == 1)
				{
					result = info[0];
				}
				else
				{
					for (int j = 0; j < info.Count; j++)
					{
						if (j > 0 && info[j] == info[j - 1])
						{
							continue;
						}

						bool isnew = set.Add(Convert.ToInt32(info[j]));
						if (isnew)
						{
							res.Append($"{info[j]} ");
						}
						else
						{
							res = new StringBuilder("IMPOSSIBLE");
							break;
						}
					}

					result = res.ToString().TrimEnd();
				}

				Console.WriteLine($"Case #{i + 1}: {result}");
			}



		}

	}
}