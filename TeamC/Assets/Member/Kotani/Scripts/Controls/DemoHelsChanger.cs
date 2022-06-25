using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoHelsChanger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> helspict = new List<GameObject>();

    public void helsChange(int hp)
    {
        //this.gameObject.SetActive(false);
        for(int i=0;i <= 5;i++)
        {
            helspict[i].SetActive(false);
        }
        for(int a=0;a <= hp-1;a++)
        {
            helspict[a].SetActive(true);
        }
    }
}
