using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private int moveSpeed = 0;

    private float moveTime = 0;
    public void ZombieMove()
    {
        moveTime += Time.deltaTime;
        var nowPosition = (player.transform.position - enemy.transform.position)/(moveSpeed*moveTime);
        // 差/(スピード*時間)
        enemy.transform.position = Vector3.Lerp(enemy.transform.position,player.transform.position,nowPosition)
        
    }
}
