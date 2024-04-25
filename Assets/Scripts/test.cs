using Assets.Lib.Objects;
using Assets.Lib.Objects.Builders;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    [ExecuteInEditMode]
    public class test : MonoBehaviour
    {
        public LivingEntityObject livingEntityObject;
        public EntityObject entityObject;
        public string json;

        public int testa = 0;

        [SerializeField] private InputActionReference testInputAction;

        private void Awake()
        {
            entityObject = new EntityObjectBuilder()
                .AddName("test")
                .Build();

            livingEntityObject = new LivingEntityObjectBuilder()
                .AddHealthPoint(1.0f)
                .AddEntityObject(entityObject)
                .Build();

            Debug.Log(EntityAnimator.SpriteState.Idle);

            entityObject.InitializeGameObject(gameObject);
        }
        //generates toJson

        private void Start()
        {
            livingEntityObject.HealthPoint = 10000;
            json = JsonUtility.ToJson(livingEntityObject);
            Debug.Log(json);
        }

        private void Update()
        {
            if (testInputAction.action.triggered)
            {
                LivingEntityObject templivingEntityObject = JsonUtility.FromJson<LivingEntityObject>(json);
                Debug.Log(templivingEntityObject.Transform.position);
                transform.position = templivingEntityObject.Transform.position;
                Debug.Log(livingEntityObject.Transform.position);
            }
        }
    }

}