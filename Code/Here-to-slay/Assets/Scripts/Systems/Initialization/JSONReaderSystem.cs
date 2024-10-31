using UnityEngine;
using Unity.Entities;
using Util;
namespace Systems.Initialization
{
    [DisableAutoCreation]
    public partial class JSONReaderSystem : SystemBase
    {
        private const string HEROES_JSON_PATH = "JSON/heroes";
        private Heroes _heroesFromJSON;
        private bool _heroesFromJSONIsDefined = false;
        public Heroes HeroesFromJSON { get => _heroesFromJSON;private set => _heroesFromJSON = value;}
        public bool HeroesFromJSONIsDefined { get => _heroesFromJSONIsDefined; private set => _heroesFromJSONIsDefined = value; }
        protected override void OnCreate()
        {
            Debug.Log("JSONReaderSystem.OnCreate");
            // Read JSON files
            // Heroes
            _heroesFromJSON = JsonUtility.FromJson<Heroes>(Resources.Load<TextAsset>(HEROES_JSON_PATH).text);
            _heroesFromJSONIsDefined = true;
            
            /*foreach (HeroJSON hero in heroesFromJSON.heroes)
            {
                Debug.Log($"id: {hero.id}, type: {hero.type}, name: {hero.name}");
                Debug.Log($"description: {hero.description}, img: {hero.img}, heroClass: {hero.heroClass}");
            }*/
        }
        protected override void OnUpdate() { }
    }
}

