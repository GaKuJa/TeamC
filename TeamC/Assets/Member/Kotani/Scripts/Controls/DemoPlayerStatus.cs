using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int hp=6;
    private int maxHp;
    private Vector3 fastPoj;
    [SerializeField]
    private DemoHelsChanger _demoHelsChanger;
    
    #region Set
    public void SetHp(int Value)
    {
        hp=Value;
    }
    #endregion

    #region Get
    public Vector3 GetFastPoj()
    {
        return fastPoj;
    }
    public int GetMaxHp()
    {
        return maxHp;
    }
    public int GetHp()
    {
        return hp;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Qキーで全回復");
        maxHp = hp;
        _demoHelsChanger.helsChange(hp);
        fastPoj = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {//HPの確認用
    if (Input.GetKeyDown(KeyCode.Q))
        {
            hp=maxHp;
            _demoHelsChanger.helsChange(hp);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //当たったら１減少
        hp-=1;
        Debug.Log("hit");
        _demoHelsChanger.helsChange(hp);
    }
}
