using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public sealed class RestrictedSerializationBinder : SerializationBinder
{
	public HashSet<Type> AllowedTypes { get; }

	public override Type BindToType(string assemblyName, string typeName)
	{
		return null;
	}
}
