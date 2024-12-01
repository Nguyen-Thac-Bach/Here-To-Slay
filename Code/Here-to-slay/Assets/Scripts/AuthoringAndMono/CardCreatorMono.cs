using Unity.Entities;
using UnityEngine;

namespace AuthoringAndMono
{
    /// <summary>
    /// Authoring component that exposes the HeroCardPrefab and Heroes_JSON_PATH to the Unity Editor.
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
            throw new System.NotImplementedException();
        }
    }
}

