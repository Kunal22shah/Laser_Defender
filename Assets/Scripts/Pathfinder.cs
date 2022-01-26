using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    EnemySpwaner enemySpwaner;
    WavesConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpwaner = FindObjectOfType<EnemySpwaner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        waveConfig = enemySpwaner.getCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;

    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();

    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }


        }
        else
        {
            Destroy(gameObject);
        }
    }
}
