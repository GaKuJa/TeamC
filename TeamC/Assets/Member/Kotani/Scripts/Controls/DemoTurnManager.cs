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
    private GameObject GameOverMask;
    // Start is called before the first frame update
    void Start()
    {
        GameOverMask.SetActive(false);
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
            GameOverMask.SetActive(true);
        }
    }
}
