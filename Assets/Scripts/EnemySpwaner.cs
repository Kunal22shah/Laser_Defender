using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] List<WavesConfigSO> wavesConfig;
    [SerializeField] float timeBetweenWaves = 0f;
    WavesConfigSO currentWave;
    [SerializeField] bool isLooping;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpwanEnemyWaves());

    }

    public WavesConfigSO getCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpwanEnemyWaves()
    {
        do
        {
            foreach (WavesConfigSO wave in wavesConfig)
            {
                currentWave = wave;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++) //ini all enemies together
                {

                    Instantiate(currentWave.GetEnemyPrefab(i),
                    currentWave.GetStartingWayPoint().position,
                    Quaternion.Euler(0, 0, 180), transform);

                    yield return new WaitForSeconds(currentWave.getRandomSpwanTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);

            }
        } while (isLooping);



    }


}
