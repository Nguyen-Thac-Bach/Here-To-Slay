using Unity.Entities;
using Components.Enums;
using Unity.Collections;

namespace Components
{
    public struct HeroCardCreator : IComponentData
    {
        public Entity HeroCardPrefab;
        public FixedString128Bytes Heroes_JSON_PATH;
        //any other instantiation data if needed
    }
}

