using UnityEngine;

[System.Serializable]
public class MovementData
{
    public enum Type { Straight, Sinusoidal, Bounce };
    public Type type;
    public float speed = 5f;
    public float frequency = 1f;
    public float magnitude = 5f;
    public float offset = 5f;
}

[System.Serializable]
public class Enemy
{
    public GameObject prefab;
    public MovementData movementData;
    public float yPos;
    public float delay;
}

[System.Serializable]
public class WaveAction
{
    public GameObject prefab;
    public MovementData movementData;
    new public string name;
    public float delay;
    public float enemyDelay;
    public float speed;
    public float yOffset;
    public int spawnCount;
    public Enemy[] enemies;
    public string message;

}

[CreateAssetMenu(fileName = "New WaveAction", menuName = "Waves/Wave")]
public class Wave : ScriptableObject
{
    public string waveName;
    public string message;
    public GameObject prefab;
    public float enemyDelay;
    public MovementData movementData;
    public float delay;
    public WaveAction[] waveActions;
}
