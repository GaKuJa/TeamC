using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

//public interface IHit
//{
//    void 
//}


public class BulletManager : MonoBehaviour
{
    /// <summary>
    /// ObjectPool
    /// </summary>
    public ObjectPool<GameObject> bulletObjectPool;

    [SerializeField, Header("初期のオブジェクト生成量")]
    private int defaultCapacity = 20;

    [SerializeField, Header("プールの最大サイズ")]
    private int poolMaxSize = 100;

    [SerializeField, Header("プールする弾オブジェクト")]
    private GameObject bulletObj;

    [SerializeField, Header("弾を出す位置")]
    private Transform playerTransform;

    [SerializeField, Header("返却された際の位置")]
    private Transform poolPosition;

    [SerializeField, Header("弾の速さ")]
    private float bulletSpeed;

    [SerializeField, Header("一回の処理で動く弾の距離")]
    private float distance = 0.01f;

    private void Start()
    {
        // オブジェクトプールを作成
        bulletObjectPool = new ObjectPool<GameObject>(
        OnCreatePoolObject,
        OnTakeFromPool,
        OnReturnedToPool,
        OnDestroyPoolObject,
        true,
        defaultCapacity,
        poolMaxSize);

    }

    /// <summary>
    /// 生成処理
    /// </summary>
    /// <returns>生成したオブジェクト</returns>
    private GameObject OnCreatePoolObject()
    {
        // 生成処理
        GameObject bullet = Instantiate(bulletObj, poolPosition.position, Quaternion.identity);
        //PooledObjectスクリプトをget
        Bullet pooled = bullet.GetComponent<Bullet>();

        //プールしたオブジェクトの変数に情報を代入
        pooled.objectPool = bulletObjectPool;
        pooled.poolPos = poolPosition;
        pooled.bulletSpeed = bulletSpeed;

        return bullet;
    }

    /// <summary>
    /// プールから取り出す処理
    /// </summary>
    private void OnTakeFromPool(GameObject obj)
    {
        //プールから取り出されたら弾をプレイヤーの位置へ
        obj.transform.position = playerTransform.position;
        obj.SetActive(true);
    }

    /// <summary>
    /// プールに戻す処理
    /// </summary>
    private void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    /// <summary>
    /// プールの許容量を超えた場合の破棄処理
    /// </summary>
    private void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }

}
