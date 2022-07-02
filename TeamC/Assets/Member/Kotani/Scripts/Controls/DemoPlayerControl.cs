using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerControl : MonoBehaviour
{
    #region 移動関連
    private Vector3 movingDirecion;
    private Vector3 movingVelocity;
    [SerializeField]
    private float speed = 1000f;
    [SerializeField]
    private float JumpPower = 1000f;
    [SerializeField]
    private int jumpMax=2;
    #endregion

    // PlayerのRigidbody取得
    [SerializeField]
    private Rigidbody2D player;
    
    #region 移動関連
    public void Playerwalk()
    {
      #region 移動関連
      float x = Input.GetAxisRaw("Horizontal");
      float z = Input.GetAxisRaw ("Vertical");
      movingDirecion = new Vector2(x,z);
	  movingDirecion.Normalize();
	  movingVelocity = movingDirecion * speed;
      if (Input.GetKeyDown(KeyCode.Space)) {Jump();}
      //new input systemで使ってたやつ
      /*if (Gamepad.current != null)
      {
        if (Gamepad.current.buttonSouth.wasPressedThisFrame){Jump();}
      }*/
       
      player.velocity = new Vector2(movingVelocity.x, player.velocity.y);
      #endregion
    }

    void Jump()
    {
      player.AddForce(transform.up * JumpPower, ForceMode2D.Impulse);
    }
    #endregion
}
