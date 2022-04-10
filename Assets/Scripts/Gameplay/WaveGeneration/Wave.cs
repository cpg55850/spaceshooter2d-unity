using UnityEngine;

[CreateAssetMenu(fileName = "New WaveAction", menuName = "Waves/Wave")]
public class Wave : ScriptableObject
{
    public string waveName;
    public WaveAction[] waveActions;
}
