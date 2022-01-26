using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projSpeed = 10f;
    [SerializeField] float projLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField] AudioPlayer adp;

    Coroutine firingCoroutine;

    [HideInInspector] public bool isFiring;

    void Awake()
    {
        adp = FindObjectOfType<AudioPlayer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projSpeed;
            }

            Destroy(instance, projLifeTime);

            float timeToNextProj = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextProj = Mathf.Clamp(timeToNextProj, minimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(baseFiringRate);
            
            adp.playShootingClip();

        }

    }
}
