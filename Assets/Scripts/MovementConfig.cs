using UnityEngine;

namespace DefaultNamespace{
    [CreateAssetMenu(fileName = "MovementConfig", menuName = "ScriptableObjects/MovementConfig")]
    public class MovementConfig : ScriptableObject{
        public float HorAcceleration, MaxHorSpeed, MaxVertSpeed;
        public float JumpForce;
    }
}