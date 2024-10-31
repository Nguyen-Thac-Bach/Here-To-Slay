using UnityEngine;
using Unity.Entities;
using Util;
namespace Systems
{
    public partial class JSONReaderSystem : SystemBase
    {
        public const string HEROES_JSON_PATH = "JSON/heroes";
        public Heroes heroesFromJSON;
        protected override void OnCreate()
        {
            Debug.Log("JSONReaderSystem.OnCreate");
            // Read JSON files
            // Heroes
            heroesFromJSON = JsonUtility.FromJson<Heroes>(Resources.Load<TextAsset>(HEROES_JSON_PATH).text);
            foreach (HeroJSON hero in heroesFromJSON.heroes)
            {
                Debug.Log($"id: {hero.id}, type: {hero.type}, name: {hero.name}");
                Debug.Log($"description: {hero.description}, img: {hero.img}, heroClass: {hero.heroClass}");
            }
        }
        protected override void OnUpdate() { }
    }
}

