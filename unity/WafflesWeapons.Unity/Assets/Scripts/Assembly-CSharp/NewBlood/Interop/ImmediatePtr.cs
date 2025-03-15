namespace NewBlood.Interop
{
	public struct ImmediatePtr<T> where T : unmanaged
	{
		public unsafe T* m_Ptr;
	}
}
