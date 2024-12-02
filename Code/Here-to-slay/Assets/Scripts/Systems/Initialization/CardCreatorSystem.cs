using UnityEngine;
using Unity.Entities;
using Util;
using Components;
using System;
using Components.Enums;
using Unity.Collections;
//commented out for now

namespace Systems.Initialization
{
    //We use Isystem, which is faster than SystemBase
    //[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    public partial struct CardCreatorSystem : ISystem
    {
        #region Constants
        #endregion

        #region Fields
        #endregion

        public void OnCreate(ref SystemState state)
        {
            
            Debug.Log("HeroCardCreatorSystem.OnCreate");
            //wait for components to exist
            state.RequireForUpdate<HeroCardCreatorProperties>();
        }

        public void OnDestroy(ref SystemState state)
        {
        }
        public void OnUpdate(ref SystemState state)
        {
            //we only want to run this system once, so we disable it for future updates
            state.Enabled = false;
            //TODO: check if this way of making sure OnUpdate runs "only once" hurts performance
            Debug.Log("CardCreatorSystem.OnUpdate");

            //Hero cards
            CreateHeroesFromJSON(ref state);

            //check if cards are created
            int heroCardCount = 0;
            Debug.Log("CardCreatorSystem.OnUpdate: heroCardCount: " + heroCardCount);
                

            

        }
        #region Private Methods
        private void CreateHeroesFromJSON(ref SystemState state)
        {
            //read json file
            Entity heroCardCreatorEntity = SystemAPI.GetSingletonEntity<HeroCardCreatorProperties>();
            CardCreatorAspect cardCreatorAspect = SystemAPI.GetAspect<CardCreatorAspect>(heroCardCreatorEntity);
            string Heroes_JSON_PATH = cardCreatorAspect.Heroes_JSON_PATH;
            Heroes heroesFromJSON = JsonUtility.FromJson<Heroes>(Resources.Load<TextAsset>(Heroes_JSON_PATH).text);
            Debug.Log("CardCreatorSystem.CreateHeroesFromJSON: loaded data from " + Heroes_JSON_PATH);
            //create hero card entities using data from HeroCardCreator and JSON

            //for now, assume there is only one hero card creator
            Debug.Log("CardCreatorSystem.CreateHeroCards");
            //since we make structural changes while iterating through entities, we need to use EntityCommandBuffer for "thread safety"
            EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);
            foreach (HeroJSON heroData in heroesFromJSON.heroes)
            {
                CreateHeroCardFrom(ecb, heroData, cardCreatorAspect);
            }

            //actually create entities
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
        private void CreateHeroCardFrom(EntityCommandBuffer ecb, HeroJSON heroData, CardCreatorAspect cardCreatorAspect)
        {
            Debug.Log("CardCreatorSystem.CreateHeroCard: " + heroData.name);
            Entity newHeroCardEntity = ecb.Instantiate(cardCreatorAspect.HeroCardPrefab);
            int mR = heroData.minRoll;
            HeroClass hC = Enum.TryParse(typeof(HeroClass), heroData.heroClass, out object heroClass) ? (HeroClass)heroClass : HeroClass.none;
            //TODO: how to access newHeroCardEntity's components?
            //the prefab will need to contain a script first that sets display texts. I need to access the script to set its values for card display
            /*
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
            */
        }
        #endregion
    }
}

