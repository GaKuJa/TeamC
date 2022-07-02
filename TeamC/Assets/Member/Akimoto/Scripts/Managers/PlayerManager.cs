using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStatusScript _playerStatusScript = null;
    private bool plyaerLiveFlag { set; get; } = true;

    private void Update()
    {
        ChangeLiveFlag(_playerStatusScript._PlayerStatus);
        
    }

    private void ChangeLiveFlag(PlayerStatusScript.PlayerStatus playerStatus)
    {
        if (playerStatus == PlayerStatusScript.PlayerStatus.die)
            plyaerLiveFlag = false;
        else
            plyaerLiveFlag = true;
    }
    
}
