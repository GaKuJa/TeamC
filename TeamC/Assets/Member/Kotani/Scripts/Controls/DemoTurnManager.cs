using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTurnManager : MonoBehaviour
{
    [SerializeField]
    private DemoPlayerControl _demoPlayerControl;
    [SerializeField]
    private DemoPlayerStatus _demoPlayerStatus;
    [SerializeField]
    private GameObject gameOverMask;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_demoPlayerStatus.GetHp()>=1)
        {
            _demoPlayerControl.Playerwalk();
        }
        else
        {
            gameOverMask.SetActive(true);
        }
    }
    public void OnClick()
    {
        //HPを回復させて初期座標に戻す
            //仮なので数字を直に入れています
        _demoPlayerStatus.SetHp(_demoPlayerStatus.GetMaxHp());
        _demoPlayerStatus.transform.localPosition =_demoPlayerStatus.GetFastPoj();
        gameOverMask.SetActive(false);
        
    }
}
