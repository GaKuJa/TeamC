using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    //ボスの動きを書くやつ
    //呼ばれる前提
    [SerializeField]
    private bool moveFlag = false;

    public bool GetMoveFlag()
    {
        return moveFlag;
    }
    [SerializeField]
    private bool topFlag = false;
    [SerializeField]
    private bool EnemyPojFlag = false;



    private Vector3 leftpoj = new Vector3(269f,-95f,0f);
    private Vector3 rightpoj = new Vector3(-269f,-95f,0f);
    private Vector3 nowpoj;
    private int i=0;

    [SerializeField]
    private float Speed=1;

    void Start()
    {
        this.transform.localPosition = leftpoj;
    }

    public void BossMoveStart()
    {
        moveFlag = true;
    }

    private void Update()
    {
        if(moveFlag && topFlag == false)
        {
            StartCoroutine(UpEnemy());
        }
        else if(topFlag)
        {
            StartCoroutine(DownEnemy());
        }
        
    }
    #region ボスの移動
    #region Up
    private IEnumerator UpEnemy()
    {
        if(EnemyPojFlag)
        {
            if(this.transform.localPosition.y >= 500f)
            {
                //既定の高さになったので場所を入れ替え
                nowpoj = this.transform.localPosition;
                nowpoj.x = -269f;
                this.transform.localPosition = nowpoj;
                while(i==0)
                {
                    Vector3 scale = this.transform.localScale;
                    scale.x = scale.x*-1; // 反転する（左向き）
                    transform.localScale = scale;
                    i = 1;
                    topFlag=true;
                }
            }
            else
            {
                nowpoj = this.transform.localPosition;
                nowpoj.y += 1f*Speed;
                this.transform.localPosition = nowpoj;
            }
        }
        else
        {
            //画面外まで飛ぶ500
            if(this.transform.localPosition.y >= 500f)
            {
                //既定の高さになったので場所を入れ替え
                nowpoj = this.transform.localPosition;
                nowpoj.x = 269f;
                this.transform.localPosition = nowpoj;
                while(i==0){
                    Vector3 scale = this.transform.localScale;
                    scale.x = scale.x*-1; // 反転する（左向き）
                    transform.localScale = scale;
                    i = 1;
                    topFlag=true;
                }
            }
            else
            {
                nowpoj = this.transform.localPosition;
                nowpoj.y += 1f*Speed;
                this.transform.localPosition = nowpoj;
            }
        }
        yield return null;
    }
    #endregion

    private IEnumerator DownEnemy()
    {
        if(this.transform.localPosition.y >= -90f)
        {
        nowpoj = this.transform.localPosition;
        nowpoj.y -= 1f*Speed;
        this.transform.localPosition = nowpoj;
        yield return null;
        }
        else
        {
            moveFlag = false;
            topFlag=false;
            EnemyPojFlag = !EnemyPojFlag;
            i=0;
        }
    }
    #endregion
}
