using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

//public interface IHit
//{
//    void 
//}


public class BulletManager : MonoBehaviour
{
    /// <summary>
    /// ObjectPool
    /// </summary>
    public ObjectPool<GameObject> bulletObjectPool;

    [SerializeField, Header("�����̃I�u�W�F�N�g������")]
    private int defaultCapacity = 20;

    [SerializeField, Header("�v�[���̍ő�T�C�Y")]
    private int poolMaxSize = 100;

    [SerializeField, Header("�v�[������e�I�u�W�F�N�g")]
    private GameObject bulletObj;

    [SerializeField, Header("�e���o���ʒu")]
    private Transform playerTransform;

    [SerializeField, Header("�ԋp���ꂽ�ۂ̈ʒu")]
    private Transform poolPosition;

    [SerializeField, Header("�e�̑���")]
    private float bulletSpeed;

    [SerializeField, Header("���̏����œ����e�̋���")]
    private float distance = 0.01f;

    private void Start()
    {
        // �I�u�W�F�N�g�v�[�����쐬
        bulletObjectPool = new ObjectPool<GameObject>(
        OnCreatePoolObject,
        OnTakeFromPool,
        OnReturnedToPool,
        OnDestroyPoolObject,
        true,
        defaultCapacity,
        poolMaxSize);

    }

    /// <summary>
    /// ��������
    /// </summary>
    /// <returns>���������I�u�W�F�N�g</returns>
    private GameObject OnCreatePoolObject()
    {
        // ��������
        GameObject bullet = Instantiate(bulletObj, poolPosition.position, Quaternion.identity);
        //PooledObject�X�N���v�g��get
        BulletScript pooled = bullet.GetComponent<BulletScript>();

        //�v�[�������I�u�W�F�N�g�̕ϐ��ɏ�����
        pooled.objectPool = bulletObjectPool;
        pooled.poolPos = poolPosition;
        pooled.bulletSpeed = bulletSpeed;

        return bullet;
    }

    /// <summary>
    /// �v�[��������o������
    /// </summary>
    private void OnTakeFromPool(GameObject obj)
    {
        //�v�[��������o���ꂽ��e���v���C���[�̈ʒu��
        obj.transform.position = playerTransform.position;
        obj.SetActive(true);
    }

    /// <summary>
    /// �v�[���ɖ߂�����
    /// </summary>
    private void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    /// <summary>
    /// �v�[���̋��e�ʂ𒴂����ꍇ�̔j������
    /// </summary>
    private void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }

}
