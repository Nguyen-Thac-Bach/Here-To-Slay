using UnityEngine;
using Unity.Entities;

namespace Systems.Initialization
{
    [CreateAfter(typeof(JSONReaderSystem))]
    public partial class HeroCardCreatorSystem : SystemBase
    {
        protected override void OnCreate()
        {
            Debug.Log("HeroCardCreatorSystem.OnCreate");
        }
        protected override void OnUpdate() { }
    }
}
