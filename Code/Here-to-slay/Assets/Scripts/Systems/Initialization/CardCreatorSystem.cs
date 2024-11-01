using UnityEngine;
using Unity.Entities;
using Util;
using Components;
using System;
using Components.Enums;
namespace Systems.Initialization
{
    //We use SystemBase, which allows features like Entities.ForEach
    public partial class CardCreatorSystem : SystemBase
    {
        #region Constants
        private const string HEROES_JSON_PATH = "JSON/heroes";
        #endregion

        #region Fields
        private Heroes _heroesFromJSON;
        #endregion

        protected override void OnCreate()
        {
            Debug.Log("HeroCardCreatorSystem.OnCreate");
            // Read JSON files
            ReadHeroesFromJSON();
            // Create cards
            CreateHeroCards();
            

        }
        protected override void OnUpdate() { }
        #region Private Methods
        private void ReadHeroesFromJSON()
        {
            _heroesFromJSON = JsonUtility.FromJson<Heroes>(Resources.Load<TextAsset>(HEROES_JSON_PATH).text);
        }
        //Creates hero card entities using data from HeroCardCreator and JSON
        private void CreateHeroCards() {
            //for now, assume there is only one hero card creator
            foreach (RefRO<HeroCardCreator> heroCardCreator in SystemAPI.Query<RefRW<HeroCardCreator>>())
            {
                Entity newHeroCardEntity = EntityManager.CreateEntity();
                //first hero card only
                Debug.Log("HeroCardCreatorSystem.CreateHeroCards: first card: " + _heroesFromJSON.heroes[0].name);
                int mR = _heroesFromJSON.heroes[0].minRoll;
                HeroClass hC = Enum.TryParse(typeof(HeroClass), _heroesFromJSON.heroes[0].heroClass, out object heroClass) ? (HeroClass)heroClass : HeroClass.none;
                EntityManager.AddComponentData(newHeroCardEntity, new HeroCard
                {
                    
                    MinRoll = mR,
                    HeroClass = hC,
                    IsActivated = false,
                    
                });
                Debug.Log($"HeroCardCreatorSystem.CreateHeroCards: MinRoll: {mR}, HeroClass: {hC}");
                //TODO: check if every string data is transferred
                //if not, then increase byte size of strings in BaseCard
                int id = _heroesFromJSON.heroes[0].id;
                string name = _heroesFromJSON.heroes[0].name;
                string description = _heroesFromJSON.heroes[0].description;

                EntityManager.AddComponentData(newHeroCardEntity, new BaseCard
                {
                    CardId = id,
                    Name = name,
                    Description = description,
                    IsViewable = true,
                });
                Debug.Log($"HeroCardCreatorSystem.CreateHeroCards: CardId: {id}, Name: {name}, Description: {description}");

            }
        }
        #endregion
    }
}
