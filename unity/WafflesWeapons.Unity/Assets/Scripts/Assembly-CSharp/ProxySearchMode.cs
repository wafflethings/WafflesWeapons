using System;

[Flags]
public enum ProxySearchMode
{
	None = 0,
	IncludeStatic = 1,
	IncludeDynamic = 2,
	FloorOnly = 4,
	IncludeBurning = 8,
	IncludeNotBurning = 0x10,
	Any = 0x1B,
	AnyFloor = 0x1F,
	AnyNotBurning = 0x13,
	AnyBurning = 0xB
}
