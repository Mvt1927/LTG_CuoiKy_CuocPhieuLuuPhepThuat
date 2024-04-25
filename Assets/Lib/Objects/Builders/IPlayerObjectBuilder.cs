namespace Assets.Lib.Objects.Builders
{
    interface IPlayerObjectBuilder
    {

        LivingEntityObject LivingEntityObject { get; set; }


        PlayerObjectBuilder AddLivingEntityObject(LivingEntityObject livingEntityObject);

        PlayerObject Build();
    }
}
