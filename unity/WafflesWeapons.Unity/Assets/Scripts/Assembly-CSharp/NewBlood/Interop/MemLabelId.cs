namespace NewBlood.Interop
{
	public struct MemLabelId
	{
		public MemLabelIdentifier identifier;

		public MemLabelId(MemLabelIdentifier identifier, ushort salt, uint rootReferenceIndex)
		{
			this.identifier = default(MemLabelIdentifier);
		}
	}
}
