using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour
{
    [SerializeField]
    private PlayerMoveManager playerMoveManager = null;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
            playerMoveManager._HitColliderStatus = PlayerMoveManager.HitColliderStatus.HitLeft;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            playerMoveManager._HitColliderStatus = PlayerMoveManager.HitColliderStatus.NonHit;
    }
}
