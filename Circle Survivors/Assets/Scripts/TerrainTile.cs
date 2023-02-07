using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;

    void Start()
    {
        GetComponentInParent<LevelScrolling>().Add(gameObject, tilePosition);
    }

    
}
