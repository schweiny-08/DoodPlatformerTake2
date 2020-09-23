using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
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
        RaycastHit2D wallDetect = Physics2D.Raycast(detector.position, Vector2.left, 0.1f);
        if (wallDetect.transform.gameObject.tag == "Ground")
        {
            if (isRight)
                isRight = false;
            else
                isRight = true;
        }
    }
}
