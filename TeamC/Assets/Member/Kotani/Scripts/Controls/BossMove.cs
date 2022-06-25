using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    //ボスの動きを書くやつ
    //呼ばれる前提
    [SerializeField]
    private bool MoveFlag = false;

    public bool GetMoveFlag()
    {
        return MoveFlag;
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
        MoveFlag = true;
    }

    private void Update()
    {
        if(MoveFlag && topFlag == false)
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
        //画面外まで飛んで右なら左へ 左なら右へ行く
        /*if(this.transform.localPosition == leftpoj)
        {
            i=0;
            EnemyPojFlag=true;
        }
        if(this.transform.localPosition == rightpoj)
        {
            i=0;
            EnemyPojFlag=false;
        }*/

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
            MoveFlag = false;
            topFlag=false;
            EnemyPojFlag = !EnemyPojFlag;
            i=0;
        }
    }
    #endregion

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
