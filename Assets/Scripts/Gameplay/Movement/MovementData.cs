using UnityEngine;

[CreateAssetMenu(fileName = "New MovementData", menuName = "Movement/Movement Data")]
public class MovementDataa : ScriptableObject
{
    public enum Type { Straight, Sinusoidal, Bounce };
    public Type type;
    public float speed = 5f;
    public float frequency = 3f;
    public float magnitude = 5f;
    public float offset = 5f;
}
