using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 弾のタイプ
    /// 0だったら通常弾、１なら治す玉
    /// </summary>
    public int bulletType = 0;

    /// <summary>
    /// BulletManagerのObjectpool
    /// </summary>
    public ObjectPool<GameObject> objectPool;

    /// <summary>
    /// 動き終わって返却される際の場所
    /// </summary>
    public Transform poolPos;

    /// <summary>
    /// 弾の速さ
    /// </summary>
    public float bulletSpeed;


    /// <summary>
    /// 何かにあたった時
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        objectPool.Release(gameObject);
    }

    /// <summary>
    /// 画面外に出た時リリース
    /// </summary>
    private void OnBecameInvisible()
    {
        objectPool.Release(gameObject);
    }
    
}