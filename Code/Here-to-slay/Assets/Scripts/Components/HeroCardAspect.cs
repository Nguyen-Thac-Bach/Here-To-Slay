using Unity.Entities;
using Unity.Collections;
using Components.Enums;
namespace Components
{
    public readonly partial struct HeroCardAspect: IAspect
    {
        //so that SystemAPI can access this aspect?
        public readonly Entity Entity;

        //aggregation of all components that make up a HeroCard
        //all need to be written at the start of the game, so for now they are all RW
        private readonly RefRW<HeroCardID> _cardID;
        private readonly RefRW<HeroCardName> _name;
        private readonly RefRW<HeroCardDescription> _description;
        private readonly RefRW<HeroCardIsViewable> _isViewable;
        private readonly RefRW<HeroCardMinRoll> _minRoll;
        private readonly RefRW<HeroCardBaseHeroClass> _baseHeroClass;
        private readonly RefRW<HeroCardCurrentHeroClass> _currentHeroClass;
        private readonly RefRW<HeroCardIsActivated> _isActivated;

        /// <summary>
        /// "Constructor" for HeroCardAspect
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="isViewable"></param>
        /// <param name="minRoll"></param>
        /// <param name="baseHeroClass"></param>
        /// <param name="currentHeroClass"></param>
        /// <param name="isActivated"></param>
        /// <returns>true if successful</returns>
        public bool InitializeHeroCardAspect(int cardId, FixedString32Bytes name, FixedString512Bytes description, bool isViewable, int minRoll, HeroClass baseHeroClass, HeroClass currentHeroClass, bool isActivated)
        {
            _cardID.ValueRW.CardId = cardId;
            _name.ValueRW.Name = name;
            _description.ValueRW.Description = description;
            _isViewable.ValueRW.IsViewable = isViewable;
            _minRoll.ValueRW.MinRoll = minRoll;
            _baseHeroClass.ValueRW.HeroClass = baseHeroClass;
            _currentHeroClass.ValueRW.HeroClass = currentHeroClass;
            _isActivated.ValueRW.IsActivated = isActivated;

            return true;
        }
    }
}

