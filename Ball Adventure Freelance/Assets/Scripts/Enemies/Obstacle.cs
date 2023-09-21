using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RunPlayerCollisionCheck(collision.gameObject);
        if (collision.TryGetComponent<Zombie>(out Zombie zombie)) Destroy(zombie.gameObject);
    }

    protected static void RunPlayerCollisionCheck(GameObject collision)
    {
        if (collision.TryGetComponent<PlayerDeathManager>(out PlayerDeathManager deathManager))
        {
            deathManager.Die();
        }
    }
}
