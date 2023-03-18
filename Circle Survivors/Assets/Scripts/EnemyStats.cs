using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyStats")] 
public class EnemyStats : ScriptableObject
{
    [SerializeField] public int maxHP;
    [SerializeField] public float speed;
    [SerializeField] public int atk;
    [SerializeField] public int XP;
}
