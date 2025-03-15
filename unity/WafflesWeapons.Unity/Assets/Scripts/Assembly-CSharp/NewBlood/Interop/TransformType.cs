using System;

namespace NewBlood.Interop
{
	[Flags]
	public enum TransformType : byte
	{
		kNoScaleTransform = 0,
		kUniformScaleTransform = 1,
		kNonUniformScaleTransform = 2,
		kOddNegativeScaleTransform = 4
	}
}
