namespace Assets.Lib.Objects
{
    internal interface IWeaponObject
    {
        //generate all interfaces of the WeaponObject class

        void ApplyBonus();

        float DamagePointBonus { get; set; }
        float HealthPointBonus { get; set; }
        float ManaPointBonus { get; set; }

    }
}