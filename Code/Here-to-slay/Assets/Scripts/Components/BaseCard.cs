using Unity.Entities;
using Unity.Collections;

public struct BaseCard : IComponentData
{
    public int CardId;
    public FixedString32Bytes Name;
    //TODO: add image field
    public FixedString128Bytes Description;
    public bool IsViewable;
}
