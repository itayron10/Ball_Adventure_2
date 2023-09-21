using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public ParticleSystem thrustEffect;
    private bool usedJetpack;
    private HudManager hudManager;

    private void Start()
    {
        hudManager = FindObjectOfType<HudManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (usedJetpack) { return; }
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            playerMovement.jetpackMode = usedJetpack = playerMovement.GetRb.freezeRotation = true;
            playerMovement.jetpackObject = this;
            playerMovement.transform.rotation = Quaternion.identity;
            hudManager.inputButtonsAnimator.SetTrigger(hudManager.hideTrigger);
            Destroy(GetComponent<Animator>());
        }
    }

    public void DestroyJetpack(PlayerMovement playerMovement)
    {
        playerMovement.jetpackMode = playerMovement.GetRb.freezeRotation = false;
        playerMovement.StopJetpack();
        hudManager.inputButtonsAnimator.SetTrigger(hudManager.showTrigger);
        Destroy(gameObject, 1f);
    }
}
