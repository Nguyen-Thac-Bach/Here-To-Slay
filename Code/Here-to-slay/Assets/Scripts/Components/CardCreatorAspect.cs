using Unity.Entities;
using Unity.Collections;
using Components.Enums;
namespace Components
{
    /// <summary>
    /// Aspect that contains the json paths for all card types
    /// </summary>
    public readonly partial struct CardCreatorAspect : IAspect
    {
        //so that SystemAPI can access this aspect?
        public readonly Entity Entity;

        //aggregation of components that provide json data for each card types
        //all need to be written at the start of the game, so for now they are all RW
        private readonly RefRO<HeroCardCreatorProperties> _heroCardCreatorProperties;
        
        public string Heroes_JSON_PATH => _heroCardCreatorProperties.ValueRO.Heroes_JSON_PATH.ToString();
        public Entity HeroCardPrefab => _heroCardCreatorProperties.ValueRO.HeroCardPrefab;
    }
}

