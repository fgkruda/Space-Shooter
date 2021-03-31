using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

[SerializeField] GameObject enemyPrefab;
[SerializeField] GameObject pathPrefab;
[SerializeField] float timeBetweenSpaws = 0.5f;
[SerializeField] float spawnRandomFactor = 0.3f;
[SerializeField] int numberOfEnemies = 5;
[SerializeField] float moveSpeed = 2f; 


public GameObject GetEnemyPrefab()
{
    return enemyPrefab;
}

public List<Transform>  GetWayPoints()
{
    var waveWaitPoints = new List<Transform>();
    foreach (Transform child in pathPrefab.transform)
    {
        waveWaitPoints.Add(child);
    }
    return waveWaitPoints;
}

public float GetTimeBetweenSpawns()
{
    return timeBetweenSpaws;
}

public float GetSpawnRandomFactor()
{
    return spawnRandomFactor;
}

public int GetNumberOfEnemies()
{
    return numberOfEnemies;

}

public float GetMoveSpeed()
{
    return moveSpeed;
}
    
}

