using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusScript : MonoBehaviour
{
    public enum PlayerStatus
    {
        alive,
        die,
    }
    public enum PlayerMovementStatus
    {
        walk,
        jump,
        attack,
    }
    public PlayerStatus         _PlayerStatus         { set; get; }
    public PlayerMovementStatus _PlayerMovementStatus { set; get; }
    protected int                  hp     { set; get; }
    protected int                  attack { set; get; }
}
