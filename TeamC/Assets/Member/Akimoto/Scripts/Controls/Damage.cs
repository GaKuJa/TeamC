using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : GunStatus
{
    private PlayerStatus playerStatus;

    private void OnTriggerEnter2D(Collider2D col)
    {
        playerStatus.playerHp = OnDamage(playerStatus.playerHp, bulletAttackNum);
    }

    private int OnDamage(int playerHP,int damage)
    {
        return playerHP -= damage;
    }
}
