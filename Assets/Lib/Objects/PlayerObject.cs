using System;
using System.Diagnostics;

namespace Assets.Lib.Objects
{
    [Serializable]
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class PlayerObject : LivingEntityObject
    {
        public PlayerObject(string name) : base(name) { }
        public PlayerObject() : this("Player") { }
        public PlayerObject(LivingEntityObject livingEntityObject) : base(livingEntityObject) { }
        public PlayerObject(PlayerObject playerObject) : this((LivingEntityObject)playerObject) { }

        public override string ToString()
        {
            return base.ToString();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
