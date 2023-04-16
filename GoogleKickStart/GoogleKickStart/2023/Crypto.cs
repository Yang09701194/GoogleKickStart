using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class Crypto
	{


		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{

				info = Console.ReadLine().Split(' ').ToList();
				//int intervalCou = Convert.ToInt32(info[0]);
				//int duration = Convert.ToInt32(info[1]);
				int rows = Convert.ToInt32(Console.ReadLine());

				var map = info.Select(d => Convert.ToInt32(d)).ToList();

				string rest = "NO";
				bool ispass = false;
				var convertResult = new HashSet<string>();
				for (int j = 0; j < rows; j++)
				{
					string row = Console.ReadLine();
					if (ispass) continue;

					bool res = convertResult.Add(String.Join("", row.Select(c => map[(int)c - 65])));
					if (!res)// res false exist
					{
						rest = "YES";
						ispass = true;
					}
				}

				Console.WriteLine($"Case #{i + 1}: {rest}");
			}



		}

	}
}
