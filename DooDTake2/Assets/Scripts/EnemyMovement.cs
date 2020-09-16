using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;
    private GroundDetector gd;
    //private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gd.isRight)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.eulerAngles = new Vector3(0,0,0);

        } else{
            rb.velocity = new Vector2(-speed, 0);
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }
}
