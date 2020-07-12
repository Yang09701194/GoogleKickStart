using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleKickStart
{
	class AlienPiano
	{

		public static void Run()
		{


			List<int> nums = new List<int>();
			List<string> info = new List<string>();

			int caseCou = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < caseCou; i++)
			{
				//int totalBreskDays = 0;
				int ruleBreakCou = 0;
				int minruleBreakCou = int.MaxValue;

				info = Console.ReadLine().Split(' ').ToList();
				int numCou = Convert.ToInt32(info[0]);
				nums = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();



				Func<int, List<int>, List<int>> AddMin = (basis, nums1) =>
				{
					int b = basis;
					List<int> res = new List<int>();
					res.Add(nums1[0]);
					for (int j = 1; j < nums1.Count; j++)
					{
						if (nums1[j] == nums1[j - 1])
						{
							res.Add((b) % 4);

						}
						if (nums1[j] > nums1[j - 1])
						{
							res.Add((++b)%4);
							
						}
						if (nums1[j] < nums1[j - 1])
						{
							res.Add((--b) % 4);

						}
					}

					return res;
				};

				int pitchCou = 4;
				if (nums.Count > 1)
				{

					for (int j = 0; j < 4; j++)
					{

						ruleBreakCou = 0;


						List<int> res = AddMin(j, nums);
						for (int k = 1; k < nums.Count; k++)
						{
							if (
								nums[k].Equals(nums[k - 1])
								!=
								res[k].Equals(res[k-1])
								)
							{
								ruleBreakCou++;
							}
						}

					}

					if (ruleBreakCou < minruleBreakCou)
						minruleBreakCou = ruleBreakCou;



				}



				Console.WriteLine($"Case #{i + 1}: {ruleBreakCou}");

			}



		}

	}
}