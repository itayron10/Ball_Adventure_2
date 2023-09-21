using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerDeathManager : MonoBehaviour
{
    [SerializeField] GameObject deathPopup, hitEffect;
    [SerializeField] SoundScriptableObject hitSound;
    private SoundManager soundManager;
    public delegate void OnDeath();
    public OnDeath onDeath;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void Die()
    {
        // sounds and effects
        soundManager.PlaySound(hitSound);
        ParticleManager.InstanciateParticleEffect(hitEffect, transform.position, Quaternion.identity);
        deathPopup.SetActive(true);
        gameObject.SetActive(false);
        onDeath?.Invoke();
    }
}
