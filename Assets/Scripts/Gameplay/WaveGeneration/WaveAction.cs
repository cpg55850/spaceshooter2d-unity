using UnityEngine;

[System.Serializable]
public class Enemy
{
    public Transform prefab;
    public float yPos;
    public float delay;
}

[CreateAssetMenu(fileName = "New WaveAction", menuName = "Waves/WaveAction")]
public class WaveAction : ScriptableObject
{
    new public string name;
    public float delay;
    public float enemyDelay;
    public Transform prefab;
    public int spawnCount;
    public Enemy[] enemies;
    public string message;
}
