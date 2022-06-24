using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    right,
    left
}


public class Gun : MonoBehaviour
{
    [SerializeField, Header("BulletManager")]
    private BulletManager bulletManager;

    [SerializeField, Header("弾の打ち出す方向v2")]
    private Vector2 bulletForce;

    private Direction playerDirection;

    private Coroutine shootCoroutine;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerDirection = Direction.right;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerDirection = Direction.left;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            shootCoroutine = StartCoroutine(Shoot());
        }
        if(Input.GetKeyUp(KeyCode.Z))
        {
            StopCoroutine(shootCoroutine);
        }
    }

    IEnumerator Shoot(int id = 0)
    {
        while(true)
        {
            ShootByID(id);
            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// 弾を出す
    /// 弾のスクリプトに番号を渡す
    /// 0:通常弾、1：人間化する弾？
    /// </summary>
    public void ShootByID(int id = 0)
    {
        var obj = bulletManager.bulletObjectPool.Get();
        obj.GetComponent<Bullet>().bulletType = id;

        switch(playerDirection)
        {
            case Direction.left:
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletForce.x, bulletForce.y));

                break;
            case Direction.right:
                obj.GetComponent<Rigidbody2D>().AddForce(bulletForce);

                break;
            default:
                break;
        }
    }

}
