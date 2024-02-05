namespace CodeChampions.Models
{
	public class Result
	{
		public string country { get; set; }
		public int lastOnlineTimeSeconds { get; set; }
		public int rating { get; set; }
		public int friendOfCount { get; set; }
		public string titlePhoto { get; set; }
		public string handle { get; set; }
		public string avatar { get; set; }
		public int contribution { get; set; }
		public string organization { get; set; }
		public string rank { get; set; }
		public int maxRating { get; set; }
		public int registrationTimeSeconds { get; set; }
		public string maxRank { get; set; }
	}

	public class Root
	{
		public string status { get; set; }
		public List<Result> result { get; set; }
	}


}
