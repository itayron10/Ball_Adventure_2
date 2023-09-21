using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Obstacle
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int speed;
    [SerializeField] SoundScriptableObject deathSound;
    [SerializeField] GameObject hitEffect;


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RunPlayerCollisionCheck(collision.gameObject);
    }

    private void OnDestroy()
    {
        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if (!soundManager) return;
        soundManager.PlaySound(deathSound);
        ParticleManager.InstanciateParticleEffect(hitEffect, transform.position, Quaternion.identity);
    }


}
