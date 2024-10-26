using Unity.Entities;
using Components.Enums;

namespace Components
{
    public struct HeroCard : IComponentData
    {
        public int MinRoll;
        //todo: add ability effect - type is not clear for now
        public HeroClass HeroClass;
        //todo: add current class when masks are implemented
        //todo: add item field when items are implemented
        public bool IsActivated;
    }
}

