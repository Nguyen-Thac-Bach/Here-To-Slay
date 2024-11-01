using Unity.Entities;
using Components.Enums;

namespace Components
{
    public struct HeroCardCreator : IComponentData
    {
        public Entity HeroCardPrefab;
        //any other instantiation data if needed
    }
}

