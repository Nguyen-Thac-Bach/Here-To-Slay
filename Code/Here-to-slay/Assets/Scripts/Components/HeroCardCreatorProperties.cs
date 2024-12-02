using Unity.Entities;
using Components.Enums;
using Unity.Collections;

namespace Components
{
    /// <summary>
    /// Component that holds the prefab for the hero card, and the path to the JSON file that contains the hero data.
    /// </summary>
    public struct HeroCardCreatorProperties : IComponentData
    {
        public Entity HeroCardPrefab;
        public FixedString128Bytes Heroes_JSON_PATH;
        //any other instantiation data if needed
    }
}

