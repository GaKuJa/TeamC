using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMoveManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStatusScript playerStatusScript = null;

    [FormerlySerializedAs("plyaerGameObject")]
    [SerializeField]
    private GameObject playerGameObject = null;

    [SerializeField]
    private int moveSpeed = 0;

    [SerializeField]
    private int jumpPawer = 0;
    public bool JumpFlag { set; get; } = false;
    public enum HitColliderStatus
    {
        NonHit,
        HitRight,
        HitLeft,
    }
    public  HitColliderStatus _HitColliderStatus { set; get; }
    private Rigidbody2D       playerRigidbody2D = null;

    private void Start()
    {
        playerRigidbody2D = playerGameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMove(_HitColliderStatus);
        PlayerJump();
    }

    private void PlayerMove(HitColliderStatus hitColliderStatus)
    {
        switch(hitColliderStatus)
        {
            case HitColliderStatus.HitRight:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    playerGameObject.transform.Translate(-moveSpeed,0,0);
                    playerStatusScript._PlayerMovementStatus = PlayerStatusScript.PlayerMovementStatus.walk;
                }
                break;
            case HitColliderStatus.HitLeft:
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    playerGameObject.transform.Translate(moveSpeed,0,0);
                    playerStatusScript._PlayerMovementStatus = PlayerStatusScript.PlayerMovementStatus.walk;
                }
                break;
            case HitColliderStatus.NonHit:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    playerGameObject.transform.Translate(-moveSpeed,0,0);
                    playerStatusScript._PlayerMovementStatus = PlayerStatusScript.PlayerMovementStatus.walk;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    playerGameObject.transform.Translate(moveSpeed,0,0);
                    playerStatusScript._PlayerMovementStatus = PlayerStatusScript.PlayerMovementStatus.walk;
                }
                break;
            default:
                break;
        }
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
            if(!JumpFlag)
                playerRigidbody2D.AddForce(playerGameObject.transform.up * jumpPawer,ForceMode2D.Impulse);
    }
}
