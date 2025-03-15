using System.Collections.Generic;

public class Magenta
{
	public string path;

	public string version;

	public readonly Dictionary<string, List<string>> bundles;

	public readonly Dictionary<string, string> assetsToBundles;

	public readonly Dictionary<string, List<string>> sceneDependencies;

	public readonly List<string> agonyDependencies;

	public Magenta(string path, bool loadUnhardened = true)
	{
	}

	public Dictionary<string, List<string>> GetUnhardenedBundles()
	{
		return null;
	}
}
