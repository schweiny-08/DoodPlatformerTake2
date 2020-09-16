using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isRight;
    public Transform detector;

    //private RaycastHit2D groundDetect;
    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundDetect = Physics2D.Raycast(detector.position, Vector2.down, 1f);
        if (groundDetect.collider == null){
            if (isRight)
                isRight = false;
            else
                isRight = true;
        }
    }
}
