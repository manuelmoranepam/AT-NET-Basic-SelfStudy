using System.Collections.Generic;

namespace EpamTests.Interfaces.Models.Careers
{
	public interface ICareerSearch
	{
		bool IsOnsite { get; set; }
		bool IsRemote { get; set; }
		string JobName { get; set; }
		string Keyword { get; set; }
		string Location { get; set; }
		bool OpenToRelocation { get; set; }
		List<string> Skills { get; set; }
	}
}
