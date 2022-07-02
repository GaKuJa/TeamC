using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletScript : MonoBehaviour
{
    /// <summary>
    /// �e�̃^�C�v
    /// 0��������ʏ�e�A�P�Ȃ玡����
    /// </summary>
    public int bulletType = 0;

    /// <summary>
    /// BulletManager��Objectpool
    /// </summary>
    public ObjectPool<GameObject> objectPool;

    /// <summary>
    /// �����I����ĕԋp�����ۂ̏ꏊ
    /// </summary>
    public Transform poolPos;

    /// <summary>
    /// �e�̑���
    /// </summary>
    public float bulletSpeed;

    /// <summary>
    /// �����ɂ���������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        objectPool.Release(gameObject);
    }

    /// <summary>
    /// ��ʊO�ɏo���������[�X
    /// </summary>
    private void OnBecameInvisible()
    {
        objectPool.Release(gameObject);
    }

}
