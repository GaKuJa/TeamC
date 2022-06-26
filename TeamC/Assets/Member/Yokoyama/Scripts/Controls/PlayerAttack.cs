using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject prefabBullet;

    public Transform bulletPoint;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefabBullet, bulletPoint.position, bulletPoint.rotation);
        }
    }
}
