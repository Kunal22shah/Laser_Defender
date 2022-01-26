using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    AudioPlayer adp;
    ScoreKeeper sk;
    LevelManager lm;

    void Awake()
    {
        adp = FindObjectOfType<AudioPlayer>();
        sk = FindObjectOfType<ScoreKeeper>();
        lm = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            //take damage
            takeDamage(damageDealer.getDamage());
            playHitEffect();
            //tell damage dealer it hit something
            adp.playDamageClip();
            damageDealer.Hit();

        }
    }

    public int getHealth()
    {

        return health;

    }

    void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            sk.modifyScore(score);
        }
        else
        {
            lm.LoadGameOver();

        }
    }

    void playHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

}


