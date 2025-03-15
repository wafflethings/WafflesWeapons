using System.Collections.Generic;
using System.IO;

public class FileDirectoryTree : IDirectoryTree<FileInfo>, IDirectoryTree
{
	public string name { get; private set; }

	public DirectoryInfo realDirectory { get; private set; }

	public IDirectoryTree<FileInfo> parent { get; set; }

	public IEnumerable<IDirectoryTree<FileInfo>> children { get; private set; }

	public IEnumerable<FileInfo> files { get; private set; }

	public FileDirectoryTree(string path, IDirectoryTree<FileInfo> parent = null)
	{
	}

	public FileDirectoryTree(DirectoryInfo realDirectory, IDirectoryTree<FileInfo> parent = null)
	{
	}

	public void Refresh()
	{
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public IEnumerable<FileInfo> GetFilesRecursive()
	{
		return null;
	}
}
