using UnityEngine;
using Unity.Entities;
using Util;
using Components;
using System;
using Components.Enums;
using Unity.Collections;
//commented out for now
/*
namespace Systems.Initialization
{
    //We use SystemBase, which allows features like Entities.ForEach
    //[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
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
        protected override void OnUpdate()
        {
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
                //check if hero cards are created
                
                int heroCardCount = 0;
                Entities
                    .ForEach((in BaseCard baseCard, in HeroCard heroCard) =>
                {
                    Debug.Log("CardCreatorSystem.OnUpdate: hero card found: ");
                    Debug.Log($"baseCard.Name: {baseCard.Name}, heroCard.MinRoll: {heroCard.MinRoll}");
                    heroCardCount++;
                }).WithoutBurst().Run();
                Debug.Log("CardCreatorSystem.OnUpdate: heroCardCount: " + heroCardCount);
                
                //disable this system
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
        private void CreateHeroCards()
        {
            //for now, assume there is only one hero card creator
            Debug.Log("CardCreatorSystem.CreateHeroCards");
            //since we make structural changes while iterating through entities, we need to use EntityCommandBuffer for "thread safety"
            EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);
            foreach (RefRO<HeroCardCreator> heroCardCreator in SystemAPI.Query<RefRW<HeroCardCreator>>())
            {
                Debug.Log("CardCreatorSystem.CreateHeroCard: heroCardCreator component found");
                foreach (HeroJSON heroData in _heroesFromJSON.heroes)
                {
                    CreateHeroCardFrom(ecb, heroData, heroCardCreator.ValueRO.HeroCardPrefab);
                }
            }
            //actually create entities
            ecb.Playback(EntityManager);
            ecb.Dispose();
        }
        private void CreateHeroCardFrom(EntityCommandBuffer ecb, HeroJSON heroData, Entity heroCardPrefab)
        {

            Entity newHeroCardEntity = ecb.Instantiate(heroCardPrefab);

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
*/
