
using UnityEngine;
using Unity.Entities;
using Components;
namespace Bakers
{
    public class HeroCardBaker : Baker<HeroCardAuthoring>
    {
        public override void Bake(HeroCardAuthoring authoring)
        {
            // TODO: Implement the Bake method, continue from here
            var entity = GetEntity(TransformUsageFlags.None);
        }
    }
}