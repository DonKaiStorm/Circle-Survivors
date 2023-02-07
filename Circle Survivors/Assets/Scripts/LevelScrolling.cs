using UnityEngine;

public class LevelScrolling : MonoBehaviour
{
	//Player Based Information
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
	[SerializeField] Vector2Int playerTilePosition;
	Vector2Int onTileGridPlayerPosition;

	//TerrainTileInformation
	[SerializeField] float tileSize = 2f;
    GameObject[,] terrainTiles;

	//Count of Existing Tiles
	[SerializeField] int terrainTileHorizontalCount;
	[SerializeField] int terrainTileVerticalCount;

	[SerializeField] int fovHeight = 3;
	[SerializeField] int fovWidth = 3;

	public void Add(GameObject gameObject, Vector2Int tilePosition)
	{
		terrainTiles[tilePosition.x, tilePosition.y] = gameObject;
	}

	private void Awake()
	{
		terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
	}
	private void Update()
	{
		//Set PlayerTile position based on location divided by tileSize
		playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
		playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

		playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
		playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;
		if (currentTilePosition != playerTilePosition)
		{
			currentTilePosition = playerTilePosition;

			onTileGridPlayerPosition.x = CalculateWrapPosition(onTileGridPlayerPosition.x, true);
			onTileGridPlayerPosition.y = CalculateWrapPosition(onTileGridPlayerPosition.y, false);
			UpdateScreen();
		}
	}

	private int CalculateWrapPosition(float currentValue, bool horizontal)
	{
		if (horizontal)
		{
			//Wrap using horizontal values
			if (currentValue >= 0)
			{
				currentValue %= terrainTileHorizontalCount;
			}
			else
			{
				currentValue += 1;
				currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
			}
		}
		else
		{
			//Wrap using vertical values
			if (currentValue >= 0)
			{
				currentValue %= terrainTileVerticalCount;
			}
			else
			{
				currentValue += 1;
				currentValue = terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
			}
		}

		return (int)currentValue;
	}

	private void UpdateScreen()
	{
		for (int pov_x = -(fovWidth / 2); pov_x <= fovWidth / 2; pov_x++)
		{
			for (int pov_y = -(fovHeight / 2); pov_y <= fovHeight / 2; pov_y++)
			{
				int tileUpdate_x = CalculateWrapPosition(playerTilePosition.x + pov_x, true);
				int tileUpdate_y = CalculateWrapPosition(playerTilePosition.y + pov_y, false);

				GameObject tile = terrainTiles[tileUpdate_x, tileUpdate_y];
				tile.transform.position = CalculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
			}
		}
	}

	private Vector3 CalculateTilePosition(int x, int y)
	{
		return new Vector3(x * tileSize, y * tileSize, 0f);
	}
}
