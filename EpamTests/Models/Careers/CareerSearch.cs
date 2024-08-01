using EpamTests.Interfaces.Models.Careers;

using System.Collections.Generic;

namespace EpamTests.Models.Careers;

internal class CareerSearch : ICareerSearch
{
	public string JobName { get; set; } = null!;
	public string Keyword { get; set; } = null!;
	public string Location { get; set; } = null!;
	public List<string> Skills { get; set; } = null!;
	public bool IsRemote { get; set; }
	public bool IsOnsite { get; set; }
	public bool OpenToRelocation { get; set; }
}
