using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int scoreValue = 150;
    [SerializeField]float health = 10; 

    [Header("Shooting")]
    [SerializeField]float shotCounter;
    [SerializeField]float minTimeBetweenShots = 0.2f;
    [SerializeField]float maxTimeBetweenShots = 3f;
    [SerializeField]GameObject projectile;
    [SerializeField]float projectileSpeed = 10f;

    [Header("Enemy effects")]
    [SerializeField]GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField]AudioClip deathSFX;
    [SerializeField][Range(0,1)] float deathSFXVolume = 0.5f;

     [SerializeField]AudioClip shootSound;
    [SerializeField][Range(0,1)] float shootSoundVolume = 0.15f;
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();
    }


    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }  
    
    void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
         AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
    
    
    
    
      public void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer){return;}
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSesson>().AddToScore(scoreValue);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(gameObject);
        
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }
}
