using System;
using UnityEngine;

[Serializable]
public class SavedVector3
{
	public float x;

	public float y;

	public float z;

	public static SavedVector3 Zero => new SavedVector3(Vector3.zero);

    public static SavedVector3 One => new SavedVector3(Vector3.one);

	public SavedVector3(Vector3 vector3)
	{
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
    }

	public Vector3 ToVector3()
	{
        return new Vector3(this.x, this.y, this.z);
    }
}
