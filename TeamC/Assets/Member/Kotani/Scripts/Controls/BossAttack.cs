using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject needle = null;
    //弾を保持（プーリング）する空のオブジェクト
    Transform needles;
    
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
        //非アクティブなオブジェクトがない場合新規生成

        //生成時にneedleの子オブジェクトにする
        Instantiate(needle,needles);
    }

    #region ボスの攻撃
    private void AttackEnemy()
    {
        //注射器振らせるやつ
            //降らせる場所と速度を入れて呼ぶ

            
        //機雷設置
            //設置する場所を入れて呼ぶ（出現時間は固定）
        //正面レーザー
            //どっち方向へレーザーを出すか呼ぶだけでOK
    }
    #endregion
}
