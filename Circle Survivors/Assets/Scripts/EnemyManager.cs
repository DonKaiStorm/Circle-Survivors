using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;
    [SerializeField] Vector2 spawningArea;
    [SerializeField] float spawnIncrements;
    float timer;
	[SerializeField] GameObject player;
	int listCount;
	Transform parentTransform;
	Vector3 spawnPosition;

	public void Awake()
	{
		listCount = enemyList.Count;
		parentTransform = transform;
	}
	private void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0f)
		{
			SpawnEnemy();
			timer = spawnIncrements;
		}
	}

	private void SpawnEnemy()
	{

		//Genetate the spawn position and then use the player position as a center point
		GeneratePosition();
		spawnPosition += player.transform.localPosition;

		//Determine which enemy to spawn an spawn it
		int enemyToSpawn = Random.Range(0, listCount);
		GameObject spawnedEnemy = Instantiate(enemyList[enemyToSpawn]);

		//Set the transform and target, along with organization in the hierarchy
		spawnedEnemy.transform.localPosition = spawnPosition;
		spawnedEnemy.GetComponent<Enemy>().SetTarget(player);
		spawnedEnemy.transform.parent = parentTransform;
	}

	private void GeneratePosition()
	{
		//Moves the player to the far x or y axis depending on the value, so that they don't pop into existence on the screen
		float axisModifier = Random.value > 0.5f ? -1f : 1f;

		if (Random.value > 0.5f)
		{
			spawnPosition.x = Random.Range(-spawningArea.x, spawningArea.x);
			spawnPosition.y = spawningArea.y * axisModifier;
		}
		else
		{
			spawnPosition.y = Random.Range(-spawningArea.y, spawningArea.y);
			spawnPosition.x = spawningArea.x * axisModifier;
		}

		spawnPosition.z = 0;
	}
}
