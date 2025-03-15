using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class DirectoryTreeBrowser<T> : MonoBehaviour
{
	[SerializeField]
	protected GameObject itemButtonTemplate;

	[SerializeField]
	protected GameObject folderButtonTemplate;

	[SerializeField]
	protected Transform itemParent;

	[SerializeField]
	protected GameObject backButton;

	[SerializeField]
	protected GameObject plusButton;

	[SerializeField]
	private TMP_Text pageText;

	private List<Action> cleanupActions;

	protected IDirectoryTree<T> currentDirectory;

	protected int maxPages;

	protected int currentPage;

	protected abstract int maxPageLength { get; }

	protected abstract IDirectoryTree<T> baseDirectory { get; }

	public static FakeDirectoryTree<T> Folder(string name, List<T> files = null, List<IDirectoryTree<T>> children = null, IDirectoryTree<T> parent = null)
	{
		return null;
	}

	private void Awake()
	{
	}

	public int PageOf(int index)
	{
		return 0;
	}

	public void SetPage(int target)
	{
	}

	public void NextPage()
	{
	}

	public void PreviousPage()
	{
	}

	public void StepUp()
	{
	}

	public void StepDown(IDirectoryTree<T> dir)
	{
	}

	public void GoToBase()
	{
	}

	public virtual void Rebuild(bool setToPageZero = true)
	{
	}

	protected abstract Action BuildLeaf(T item, int indexInPage);

	protected virtual Action BuildDirectory(IDirectoryTree<T> folder, int indexInPage)
	{
		return null;
	}
}
