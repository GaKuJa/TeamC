using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private BossAttack _bossAttack;
    [SerializeField]
    private BossMove _bossMove;
    [SerializeField]
    private float _bossMoveSpeed=1;
    [SerializeField]
    private float t=0;

    void Start()
    {
        StartCoroutine(EnemyMotion());
    }
    void Update()
    {
        //ボスが何秒ごとに移動するか
        t += Time.deltaTime;
    }

    private IEnumerator EnemyMotion()
    {
        while (true) // このGameObjectが有効な間実行し続ける
        {
            int r = Random.Range(0, 3);
            switch(r)
            {
            case 0:
            //注射器が振ってくる攻撃
            _bossAttack.BulletStart();
            break;
            
            case 1:
            //Enemyが移動する
            if(_bossMove.GetMoveFlag() == false && t >= 5f)
            {
                _bossMove.BossMoveStart();
                t=0;
            }
            else
            {
                _bossAttack.BulletStart();
            }
            break;
            
            case 2:
            //レーザー
            StartCoroutine(_bossAttack.LaserStart());
            break;

            default:
            break;
            }
            
            yield return new WaitForSeconds(_bossMoveSpeed);
        }
    }
}
