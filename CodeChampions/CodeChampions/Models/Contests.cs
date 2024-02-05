namespace CodeChampions.Models
{
	public class Contest
	{
		public int id { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string phase { get; set; }
		public bool frozen { get; set; }
		public int durationSeconds { get; set; }
		public int startTimeSeconds { get; set; }
		public int relativeTimeSeconds { get; set; }
	}

	public class dataOfContests
	{
		public string status { get; set; }
		public List<Contest> result { get; set; }
	}

}
