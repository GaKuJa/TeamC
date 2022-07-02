using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    [SerializeField]
    private PlayerMoveManager playerMoveManager;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
            playerMoveManager.JumpFlag = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            playerMoveManager.JumpFlag = true;
    }

}
