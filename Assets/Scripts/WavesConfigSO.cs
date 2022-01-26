using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WavesConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpwan = 1f;
    [SerializeField] float spwanTimevariance = 0f;
    [SerializeField] float minSpwanTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];

    }

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public float getRandomSpwanTime()
    {
        float spwanTime = Random.Range(timeBetweenEnemySpwan - spwanTimevariance, timeBetweenEnemySpwan + spwanTimevariance
        );

        return Mathf.Clamp(spwanTime, minSpwanTime, float.MaxValue);
    }


}
