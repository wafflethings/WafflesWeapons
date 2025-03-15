using System;

namespace Sandbox
{
	[Serializable]
	public class AlterOption<T>
	{
		public string name;

		public string key;

		public string tooltip;

		public T value;

		public Type type;

		public Action<T> callback;

		public IConstraints constraints;
	}
}
