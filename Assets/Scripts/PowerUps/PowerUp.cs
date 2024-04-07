using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject
{
    public string powerUpName;
    public GameObject powerUpPrefab;
}