using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    enum EnemyType
    {
        human,
        zombie,
    }

    private EnemyType enemyType;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemyMove(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.human:
                break;
            case EnemyType.zombie:
                break;
        }
    }
}
