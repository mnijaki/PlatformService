namespace PlatformService.Dtos
{
	public class ReadPlatformDto
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string Publisher { get; set; }
		
		public string Cost { get; set; }

		public bool IsDTO { get; set; } = true;
	}
}