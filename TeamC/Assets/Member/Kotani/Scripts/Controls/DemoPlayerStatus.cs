using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int Hp=6;
    private int MaxHp;
    [SerializeField]
    private DemoHelsChanger _demoHelsChanger;

    public void SetHp(int Value)
    {
        Hp=Value;
    }
    public int GetHp()
    {
        return Hp;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Qキーで全回復");
        MaxHp = Hp;
        _demoHelsChanger.helsChange(Hp);
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Q))
        {
            Hp=MaxHp;
            _demoHelsChanger.helsChange(Hp);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Hp-=1;
        Debug.Log("hit");
        _demoHelsChanger.helsChange(Hp);
    }
}
