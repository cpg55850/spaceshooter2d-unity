using UnityEngine;

//[System.Serializable]
//public class Enemy
//{
//    public GameObject prefab;
//    public MovementData movementData;
//    public float yPos;
//    public float delay;
//}

[CreateAssetMenu(fileName = "New WaveAction", menuName = "Waves/WaveAction")]
public class WaveActionz : ScriptableObject
{
    public GameObject prefab;
    public MovementData movementData;
    new public string name;
    public float delay;
    public float enemyDelay;
    public int spawnCount;
    public Enemy[] enemies;
    public string message;

}
