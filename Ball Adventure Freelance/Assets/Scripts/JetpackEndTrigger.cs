using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackEndTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            playerMovement.jetpackObject.DestroyJetpack(playerMovement);
        }
    }
}
