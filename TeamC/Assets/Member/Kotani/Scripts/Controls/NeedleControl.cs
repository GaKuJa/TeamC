using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleControl : MonoBehaviour
{
    public int Speed = 1;
    private Vector3 mypoj;
    private float Fauleint=0;

    void Start()
    {
        int n = Random.Range(0, 9);
        NeedleStart(n,Speed);
        mypoj = this.transform.localPosition;
        mypoj.y =10f+n;
        this.transform.localPosition = mypoj;
    }

    public void NeedleStart(int i,int s)
    {
        switch(i)
        {
            case 0:
            Fauleint =6f;
            break;
            case 1:
            Fauleint =4.5f;
            break;
            case 2:
            Fauleint =3f;
            break;
            case 3:
            Fauleint =1.5f;
            break;
            case 4:
            Fauleint =0f;
            break;
            case 5:
            Fauleint =-1.5f;
            break;
            case 6:
            Fauleint =-3f;
            break;
            case 7:
            Fauleint =-4.5f;
            break;
            case 8:
            Fauleint =-6f;
            break;
            default:
            Debug.Log("例外:52");
            break;
        }
        Speed=s;
    }

    void Update()
    {
        StartCoroutine (NeedleMove(Fauleint));
    }


    private IEnumerator NeedleMove(float f)
    {
        mypoj = this.transform.localPosition;
        mypoj.y -= 0.01f*Speed;
        mypoj.x = f;
        this.transform.localPosition = mypoj;
        if(mypoj.y <= -10f)
        {
            int n = Random.Range(0, 9);
            NeedleStart(n,Speed);
            mypoj.y =10+n;
            this.transform.localPosition = mypoj;
            this.gameObject.SetActive(false);
        }
        yield return null;
    }
}
