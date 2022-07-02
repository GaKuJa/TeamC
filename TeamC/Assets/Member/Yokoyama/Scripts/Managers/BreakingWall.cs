using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingWall : MonoBehaviour
{
    int num = 0;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            num++;
            Destroy(other.gameObject);
            if (num == 2)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
