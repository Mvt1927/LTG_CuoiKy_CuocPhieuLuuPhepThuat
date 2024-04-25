using Assets.Lib.Objects;
using Assets.Lib.Objects.Builders;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour, IPlayer
    {
        [Header("Player Data")]
        [SerializeField]
        PlayerObject _playerObject = new PlayerObjectBuilder().Build();

        public PlayerObject PlayerObject { get => _playerObject; set => _playerObject = value; }
        public LivingEntityObject LivingEntityObject { get => _playerObject; set => _playerObject = (PlayerObject)value; }
        public EntityObject EntityObject { get => _playerObject; set => _playerObject = (PlayerObject)value; }

        private void Awake()
        {
            SetUp();
        }

        void SetUp()
        {
            _playerObject.Name = gameObject.name;
            _playerObject.InitializeGameObject(gameObject);

        }

    }

}