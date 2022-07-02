using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;

    private float time      = 0.0f;
    private int   timeCount = 1;

    private Rigidbody2D enemyRb = null;

    private Ray        ray;

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start() 
    {
        enemyRb = this.GetComponent<Rigidbody2D>();
        ray   = new Ray(this.transform.position, this.transform.right * 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        time             += Time.deltaTime;
        enemyRb.velocity =  new Vector2(speed, enemyRb.velocity.y);
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hello");
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
