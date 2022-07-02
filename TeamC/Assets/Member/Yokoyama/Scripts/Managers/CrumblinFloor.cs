using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblinFloor : MonoBehaviour
{
    int num = 0;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            num++;

            Destroy(this.gameObject, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
