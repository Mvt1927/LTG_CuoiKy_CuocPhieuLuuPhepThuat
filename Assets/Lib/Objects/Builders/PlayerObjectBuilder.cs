namespace Assets.Lib.Objects.Builders
{
    internal class PlayerObjectBuilder : IPlayerObjectBuilder
    {
        public LivingEntityObject LivingEntityObject { get; set; } = new LivingEntityObjectBuilder().Build();

        public PlayerObjectBuilder AddLivingEntityObject(LivingEntityObject livingEntityObject)
        {
            LivingEntityObject = livingEntityObject;
            return this;
        }

        public PlayerObject Build()
        {
            return new PlayerObject(LivingEntityObject);
        }
    }
}
