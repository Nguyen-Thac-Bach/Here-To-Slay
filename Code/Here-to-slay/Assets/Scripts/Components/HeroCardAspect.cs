using Unity.Entities;

namespace Components
{
    public readonly partial struct HeroCardAspect: IAspect
    {
        public readonly Entity Entity;

        private readonly RefRO<HeroCardID> _cardID;
        private readonly RefRO<HeroCardName> _name;
        private readonly RefRO<HeroCardDescription> _description;
        private readonly RefRW<HeroCardIsViewable> _isViewable;
        private readonly RefRO<HeroCardMinRoll> _minRoll;
        private readonly RefRO<HeroCardBaseHeroClass> _baseHeroClass;
        private readonly RefRW<HeroCardCurrentHeroClass> _currentHeroClass;
        private readonly RefRW<HeroCardIsActivated> _isActivated;
    }
}

