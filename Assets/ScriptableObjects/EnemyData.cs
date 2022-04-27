
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int damage;
    public int points;
    public bool canDropItem;
    public GameObject[] droppableItems;
    public float dropPercentage = 5f;
}