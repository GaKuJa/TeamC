using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 0.05f;
    private float time = 0.0f;
    private int timeCount = 1;
    private Rigidbody2D enemyRb = null;
    private Ray ray;
    private RaycastHit hit;
    void Start()
    {
        enemyRb = this.GetComponent<Rigidbody2D>();


        ray = new Ray(this.transform.position,this.transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        enemyRb.velocity = new Vector2(x: speed, enemyRb.velocity.y);

        if (time > timeCount * 5.0f)
        {
            speed *= -1;
            timeCount++;
        }

        Vector2 position = this.transform.position;
        
        if(Input.GetKey(KeyCode.RightArrow))
            {
            Debug.Log("0");
            enemyRb.velocity = new Vector2(x: speed, enemyRb.velocity.y);
            }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("1");
            enemyRb.velocity = new Vector2(-speed, enemyRb.velocity.y);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Attack");

            if(Physics.Raycast(ray,out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.SetActive(false);
            }

            
            
        }

 }

}
