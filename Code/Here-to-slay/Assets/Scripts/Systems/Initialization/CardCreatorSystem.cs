using UnityEngine;
using Unity.Entities;
using Util;
using Components;
using System;
using Components.Enums;
using Unity.Collections;
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
        private bool _isInitialized;
        #endregion

        protected override void OnCreate()
        {
            Debug.Log("HeroCardCreatorSystem.OnCreate");
            // Read JSON files
            ReadHeroesFromJSON();
            _isInitialized = false;
            
            

        }
        protected override void OnUpdate() {
            //TODO: check if this way of making sure OnUpdate runs "only once" hurts performance
            Debug.Log("CardCreatorSystem.OnUpdate");
            if (!_isInitialized)
            {
                // Create cards
                CreateHeroCards();

                _isInitialized = true;
            }
            else
            {
                Debug.Log("disabling CardCreatorSystem");
                World.GetExistingSystemManaged<CardCreatorSystem>().Enabled = false;
            }
            
        }
        #region Private Methods
        private void ReadHeroesFromJSON()
        {
            _heroesFromJSON = JsonUtility.FromJson<Heroes>(Resources.Load<TextAsset>(HEROES_JSON_PATH).text);
            Debug.Log("CardCreatorSystem.ReadHeroesFromJSON first card: " + _heroesFromJSON.heroes[0].name);
        }
        //Creates hero card entities using data from HeroCardCreator and JSON
        private void CreateHeroCards() {
            //for now, assume there is only one hero card creator
            Debug.Log("CardCreatorSystem.CreateHeroCards");
            foreach (RefRO<HeroCardCreator> heroCardCreator in SystemAPI.Query<RefRW<HeroCardCreator>>())
            {
                Debug.Log("CardCreatorSystem.CreateHeroCard: heroCardCreator component found");
                //since we make structural changes while iterating through entities, we need to use EntityCommandBuffer for "thread safety"
                EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);
                foreach (HeroJSON heroData in _heroesFromJSON.heroes)
                {
                    CreateHeroCardFrom(ecb, heroData);
                }
                
                
            }
        }
        private void CreateHeroCardFrom(EntityCommandBuffer ecb, HeroJSON heroData)
        {
            
            Entity newHeroCardEntity = ecb.CreateEntity();
            //first hero card only
            Debug.Log("CardCreatorSystem.CreateHeroCard: " + heroData.name);
            int mR = heroData.minRoll;
            HeroClass hC = Enum.TryParse(typeof(HeroClass), heroData.heroClass, out object heroClass) ? (HeroClass)heroClass : HeroClass.none;
            ecb.AddComponent<HeroCard>(newHeroCardEntity);
            ecb.SetComponent<HeroCard>(newHeroCardEntity, new HeroCard
            {

                MinRoll = mR,
                HeroClass = hC,
                IsActivated = false,

            });
            Debug.Log($"CardCreatorSystem.CreateHeroCards: MinRoll: {mR}, HeroClass: {hC}");
            //TODO: check if every string data is transferred
            //if not, then increase byte size of strings in BaseCard
            int id = heroData.id;
            string name = heroData.name;
            string description = heroData.description;
            ecb.AddComponent<BaseCard>(newHeroCardEntity);
            ecb.SetComponent<BaseCard>(newHeroCardEntity, new BaseCard
            {
                CardId = id,
                Name = name,
                Description = description,
                IsViewable = true,
            });
            Debug.Log($"CardCreatorSystem.CreateHeroCards: CardId: {id}, Name: {name}, Description: {description}");

        }
        #endregion
    }
}
