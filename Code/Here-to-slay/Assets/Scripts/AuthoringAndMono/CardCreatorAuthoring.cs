using Unity.Entities;
using Unity.Collections;
using UnityEngine;

using Components;
namespace AuthoringAndMono
{
    /// <summary>
    /// Authoring component that exposes the "card prefabs" and "json file paths" to the Unity Editor.
    /// Basically, this is needed so I can drag the prefabs, and set the JSON paths in the Unity Editor.
    /// </summary>
    public class CardCreatorAuthoring : MonoBehaviour
    {
        public GameObject HeroCardPrefab;
        public string Heroes_JSON_PATH = "JSON/heroes";
        //other prefabs and JSON paths will be added later
    }

    /// <summary>
    /// Creates the entity from CardCreatorAuthoring data.
    /// Needed to convert the data from the Unity Editor to ECS.
    /// </summary>
    public class CardCreatorBaker: Baker<CardCreatorAuthoring>
    {
        public override void Bake(CardCreatorAuthoring authoring)
        {
            Entity cardCreatorEntity = GetEntity(TransformUsageFlags.None); //no need for transform
            AddComponent(cardCreatorEntity, new HeroCardCreator
            {
                HeroCardPrefab = GetEntity(authoring.HeroCardPrefab, TransformUsageFlags.Dynamic),
                Heroes_JSON_PATH = new FixedString128Bytes(authoring.Heroes_JSON_PATH)
            }); 
            Debug.Log($"added HeroCardCreator component with Heroes_JSON_PATH = \"{new FixedString128Bytes(authoring.Heroes_JSON_PATH)}\" to cardCreatorEntity");
        }
    }
}

