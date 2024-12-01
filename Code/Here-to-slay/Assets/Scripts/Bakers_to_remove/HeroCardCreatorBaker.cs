
using UnityEngine;
using Unity.Entities;
using Components;
namespace Bakers
{
    public class HeroCardCreatorBaker : Baker<HeroCardCreatorAuthoring>
    {
        //Create an empty entity, then add the HeroCardCreator component to it
        public override void Bake(HeroCardCreatorAuthoring authoring)
        {
            Debug.Log("HeroCardCreatorBaker.Bake");
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new HeroCardCreator()
            {
                HeroCardPrefab = GetEntity(authoring.HeroCardPrefab, TransformUsageFlags.Dynamic)
            });

        }
    }
}