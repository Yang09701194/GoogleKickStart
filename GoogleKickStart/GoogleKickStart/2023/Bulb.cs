using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class Bulb
	{


		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{

				info = Console.ReadLine().Split(' ').ToList();

				int M = Convert.ToInt32(info[0]);
				int R = Convert.ToInt32(info[1]);
				int N = Convert.ToInt32(info[2]);


				var ps = Console.ReadLine().Split(' ').Select(d =>Convert.ToInt32(d)).ToList();
				string res = null;
				int cou = 0;
				if ((ps[0] - R > 0) || ps[N - 1] + R < M)
				{
					res = "IMPOSSIBLE";
				}
				else
				{
					
					int curr = 0;

					for (int j = 0; j < N; j++)
					{
						if (j < N -1 && ps[j] + R < ps[j + 1] - R)
						{
							res = "IMPOSSIBLE";
							break;
						}


						bool isAdd = false;

						if (curr == 0)
						{
							while (j < N && curr + R >= ps[j])
							{
								j++;
								isAdd = true;
							}
							if (isAdd) j--;
							curr = ps[j];
							cou++;

							if (ps[j] + R >= M)
							{
								break;
							}
							continue;
						}

						// last point
						if (ps[j] + R >= M)
						{
							cou++;
							break;
						}

						isAdd = false;
						while (j < N && curr + R >= ps[j] - R)
						{
							j++;
							isAdd = true;
						}
						if(isAdd) j--;

						curr = ps[j];
						cou++;
					}
				}

				Console.WriteLine($"Case #{i + 1}: {res ?? cou.ToString()}");
			}



		}

	}
}