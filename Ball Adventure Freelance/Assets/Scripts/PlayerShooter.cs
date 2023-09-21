using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] SoundScriptableObject shootingSound;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void Shoot()
    {
        Projectile projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        soundManager.PlaySound(shootingSound);
        Destroy(projectile.gameObject, 3);
    }
}
