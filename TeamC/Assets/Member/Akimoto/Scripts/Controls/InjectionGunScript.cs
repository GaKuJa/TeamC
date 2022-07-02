using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectionGunScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject Injection;

    [SerializeField]
    private GameObject plaeyr;
    [SerializeField]
    private float   shotSpeed = 0;
    private Vector2 shotVec;
    [SerializeField]
    private int     maxMagazin = 120;
    [SerializeField]
    private int     maxBullet  = 30;
    private int     shotCount  = 0;

    [SerializeField]
    private Transform magazin;

    private void Start()
    {
        shotVec = plaeyr.transform.right * shotSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& shotCount >= 0)
        {
            shotCount++;
            maxBullet--;
            InjectionBulletInstanice();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            maxMagazin -= shotCount;
            maxBullet  += shotCount;
            shotCount  =  0;
        }
    }

    private void InjectionBulletInstanice()
    {
        GameObject  InjectionBullet = Instantiate(bullet, new Vector2(Injection.transform.position.x,Injection.transform.position.y), Quaternion.identity,magazin);
        Rigidbody2D bulletrb        = InjectionBullet.GetComponent<Rigidbody2D>();
        bulletrb.AddForce(shotVec);

    }
}
