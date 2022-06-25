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
        #region 敵の行動制御
        StartCoroutine(EnemyMotion());
        #endregion
    }
    void Update()
    {
        t += Time.deltaTime;
    }
    private IEnumerator EnemyMotion()
    {
        while (true) // このGameObjectが有効な間実行し続ける
        {
            int r = Random.Range(0, 2);
            switch(r)
            {
            case 0:
            //注射器が振ってくる攻撃
            _bossAttack.BulletStart();
            break;
            
            case 1:
            //Enemyが移動する
            if(_bossMove.GetMoveFlag() == false && t >= 10f)
            {
                _bossMove.BossMoveStart();
                t=0;
            }
            else
            {
                _bossAttack.BulletStart();
            }
            break;

            default:
            break;
            }
            
            yield return new WaitForSeconds(_bossMoveSpeed);
        }
    }
}
