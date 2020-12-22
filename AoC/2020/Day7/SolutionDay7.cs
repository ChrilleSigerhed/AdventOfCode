using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class SolutionDay7
{
	private IDictionary<string, List<Bag>> bags = new Dictionary<string, List<Bag>>();
	private string _bagRegex = @"\d+ (\w* \w* \w*)";
	public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day7\Input.txt");

    public int Part1()
    {
        string[] bags = new string[2];
        List<string> totalBags = new List<string>();
        for (int i = 0; i < Input.Length; i++)
        {
            if(Input[i].Contains("shiny gold"))
            {
                bags = Input[i].Split(" contain");
                if(bags[0] != "shiny gold")
                {
                    totalBags.Add(bags[0]);
                }
            }
        }
        bool foundBag = true;
        while (foundBag)
        {
            foundBag = false;
            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < totalBags.Count; j++)
                {
                    if (Input[i].Contains(totalBags[j]))
                    {
                        bags = Input[i].Split(" bags");
                        if (bags[0] != "shiny gold" && !totalBags.Contains(bags[0]))
                        {
                            totalBags.Add(bags[0]);
                            foundBag = true;
                        }
                    }
                }
            }
        }
        return totalBags.Count;
    }
	public int Part2()
	{

		foreach (string rule in Input)
		{
			string bagName = rule.Split(" contain ")[0];
			if (rule.Contains("contain no other bags"))
			{
				bags.Add(bagName, new List<Bag>());
			}
			else
			{
				List<Bag> groups = Regex.Matches(rule, _bagRegex).Select(match =>
				{
					int spaceLocation = match.Value.IndexOf(" ");
					int count = Convert.ToInt32(match.Value.Substring(0, spaceLocation));
					string name = match.Value.Substring(spaceLocation + 1);
					return new Bag() { Count = count, Name = name };
				}).ToList();
				bags.Add(bagName, groups);
			}
		}

		List<Bag> shinyGoldBag = bags.FirstOrDefault(f => f.Key == "shiny gold bags").Value;
		int total = BagsCount(shinyGoldBag);

		return total;
	}

	private int BagsCount(List<Bag> bag)
	{
		int counter = 0;
		foreach (Bag bagInfo in bag)
		{
			string name = bagInfo.Name;
			if (!name.EndsWith("s"))
				name += "s";
			List<Bag> bagList = bags.FirstOrDefault(f => f.Key == name).Value;
			if (bagList.Count != 0)
				counter += bagInfo.Count * BagsCount(bagList);

			counter += bagInfo.Count;
		}
		return counter;
	}
}

public class Bag
{
	public int Count { get; set; }
	public string Name { get; set; }
}


