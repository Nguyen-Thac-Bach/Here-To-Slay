using Unity.Entities;

public class BaseCard : IComponentData
{
    public int CardId;
    public string Name;
    //TODO: add image field
    public string Description;
    public bool IsViewable;
}
