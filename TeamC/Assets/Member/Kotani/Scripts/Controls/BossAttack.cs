using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    ////////////////////////////////
    ///落ちて来る注射器の管理（プーリング）
    ///laserの挙動の制御
    ////////////////////////////////
    [SerializeField]
    private GameObject needle = null;
    //弾を保持する空のオブジェクト
    private Transform needles;
    [SerializeField]
    private GameObject laser = null;
    void Start()
    {
        needles = new GameObject("narsnider").transform;
    }

    public void BulletStart()
    {
        for(int a=0;a <=2 ;a++)
        {
        //弾生成関数を呼び出し
        InstBullet();
        }
    }
    public IEnumerator LaserStart()
    {
        //trueにしてから1秒後に発射
        laser.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        laser.transform.Find("laser").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        laser.SetActive(false);
        laser.transform.Find("laser").gameObject.SetActive(false);
    }

    void InstBullet()
    {
        //アクティブでないオブジェクトをneedleの中から探索
        foreach(Transform t in needles)
        {
            if (!t.gameObject.activeSelf)
            {
                //アクティブにする
                t.gameObject.SetActive(true);
                return;
            }
        }
        //生成時にneedleの子オブジェクトにする
        Instantiate(needle,needles);
    }
}
