using Unity.Entities;
using Unity.Collections;
using Components.Enums;

namespace Components
{
    //for now, each component is separate, but we can combine them into a single struct if needed later
    public struct HeroCardID: IComponentData
    {
        public int CardId;
    }

    public struct HeroCardName: IComponentData
    {
        public FixedString32Bytes Name;
    }

    public struct HeroCardDescription: IComponentData
    {
        public FixedString512Bytes Description;
    }

    public struct HeroCardIsViewable: IComponentData
    {
        public bool IsViewable;
    }
    public struct HeroCardMinRoll: IComponentData
    {
        public int MinRoll;
    }
    public struct HeroCardHeroClass: IComponentData
    {
        public HeroClass HeroClass;
    }

    public struct HeroCardIsActivated: IComponentData
    {
        public bool IsActivated;
    }
}

