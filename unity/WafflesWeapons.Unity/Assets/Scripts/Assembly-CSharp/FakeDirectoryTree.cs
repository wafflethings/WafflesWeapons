using System.Collections.Generic;

public class FakeDirectoryTree<T> : IDirectoryTree<T>, IDirectoryTree
{
	public string name { get; private set; }

	public IEnumerable<IDirectoryTree<T>> children { get; private set; }

	public IEnumerable<T> files { get; private set; }

	public IDirectoryTree<T> parent { get; set; }

	public FakeDirectoryTree(string name, IEnumerable<T> files = null, IEnumerable<IDirectoryTree<T>> children = null, IDirectoryTree<T> parent = null)
	{
	}

	public FakeDirectoryTree(string name, List<T> files = null, List<FakeDirectoryTree<T>> children = null, IDirectoryTree<T> parent = null)
	{
	}

	public void Refresh()
	{
	}

	public IEnumerable<T> GetFilesRecursive()
	{
		return null;
	}
}
