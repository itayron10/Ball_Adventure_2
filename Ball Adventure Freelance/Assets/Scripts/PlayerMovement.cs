using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int speed;
    [SerializeField] int jumpForce;
    [SerializeField] float fallMultiplier = 2.5f, lowJumpMultiplier = 2f;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject landEffect;
    [SerializeField] SoundScriptableObject landSound, jumpSound, jetpackSound;
    [SerializeField] ScreenShakeSettingsSO shakeSettingsSO;
    private bool grounded, hasLanded, jetpackActive;
    public bool jetpackMode;
    private CinemachineShake shake;
    private SoundManager soundManager;
    private InputManager inputManager;
    private const float VELOCITY_THEROSHOLD = 2.5f;
    public Rigidbody2D GetRb => rb; 

    [Header("Jetpack")]
    public Jetpack jetpackObject;
    [SerializeField] float jetpackPower;
    [SerializeField] Transform jetpackPoint;

    private void Start()
    {
        SaveManager saveManager = SaveManager.instance;
        soundManager = FindObjectOfType<SoundManager>();
        soundManager = FindObjectOfType<SoundManager>();
        shake = CinemachineShake.instance;

        inputManager = InputManager.instance;
        inputManager.inputActions.Player.Jump.performed += JetpackJumpStart;
        inputManager.inputActions.Player.Jump.canceled += Jump_canceled;

        saveManager.numberOfLevelsPlayedBeforeAd++;
        if (saveManager.numberOfLevelsPlayedBeforeAd > 3)
        {
            AdmobManager.instance.ShowInterstitialAd();
            saveManager.numberOfLevelsPlayedBeforeAd = 0;
        }
    }

    private void OnDestroy()
    {
        inputManager.inputActions.Player.Jump.performed -= JetpackJumpStart;
        inputManager.inputActions.Player.Jump.canceled -= Jump_canceled;
    }

    void FixedUpdate()
    {
        if (!jetpackMode) HandleGroundCheck();
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (!jetpackMode) HandleJumpGravity();
    }

    private void Update()
    {
        if (jetpackMode)
        {
            jetpackObject.transform.position = jetpackPoint.position;
            if (jetpackActive)
            {
                if (transform.position.y < 10) rb.AddForce(Vector2.up * jetpackPower);
                ParticleManager.StartParticle(jetpackObject.thrustEffect);
            }
            else
                ParticleManager.StopParticle(jetpackObject.thrustEffect);
        }
    }


    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!jetpackMode) { return; }
        StopJetpack();
    }

    private void JetpackJumpStart(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!jetpackMode) { return; }
        jetpackActive = true;
        rb.gravityScale = rb.gravityScale / 2;
        soundManager.PlaySound(jetpackSound);
    }

    public void StopJetpack()
    {
        jetpackActive = false;
        rb.gravityScale = 1;
        soundManager.StopSound(jetpackSound);
    }

    private void HandleGroundCheck()
    {
        if (!grounded) hasLanded = false;

        grounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        
        if (grounded && !hasLanded)
        {
            // landed
            hasLanded = true;

            if (rb.velocity.y >= -VELOCITY_THEROSHOLD) { return; }
            PlayLandEffects();
        }
    }

    private void PlayLandEffects()
    {
        shake.Shake(shakeSettingsSO);
        ParticleManager.InstanciateParticleEffect(landEffect, transform.position, Quaternion.identity);
        soundManager.PlaySound(landSound);
    }

    public void Jump()
    {
        if (!grounded) return;
        rb.velocity += Vector2.up * jumpForce;
        // Effects and Sound
        soundManager.PlaySound(jumpSound);
    }

    private void HandleJumpGravity()
    {
        if (rb.velocity.y < -0.5f)
            rb.gravityScale = fallMultiplier;
        else if (rb.velocity.y > 0.5f)
            rb.gravityScale = lowJumpMultiplier;
        else
            rb.gravityScale = 1f;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);  
    }
#endif
}
