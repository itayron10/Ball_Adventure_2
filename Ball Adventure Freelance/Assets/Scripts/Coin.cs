using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject collectEffect;
    [SerializeField] SoundScriptableObject collectSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerCoinManager>(out PlayerCoinManager coinManager))
        {
            coinManager.AddCoinAmount(1);
            // Effects and sound
            FindObjectOfType<SoundManager>().PlaySound(collectSound);
            ParticleManager.InstanciateParticleEffect(collectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
