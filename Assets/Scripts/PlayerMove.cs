using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameManager gameManager;

    public Rigidbody2D rigid;

    public float spped = 5f;
    public float jumpForce = 10f;
    private bool isGround = false;
    private int jumpCount = 0;
    private int maxJumpCount = 1;
    
    private void Update()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, spped);
        int which = (transform.position.x > 0) ? 2 : -2;
        if (rigid.gravityScale != which) rigid.gravityScale = which;

        if (gameManager.isStart)
        {
            if (Input.touchCount > 0)
            {
                Debug.Log("click");
                for(int i = 0; i < Input.touches.Length; i++)
                {
                    switch (Input.touches[i].phase)
                    {
                        case TouchPhase.Began:
                            if (jumpCount < maxJumpCount)
                            {
                                rigid.AddForce(new Vector2(jumpForce * which, 0));
                                gameManager.TouchEffect(Convert.ToBoolean(which+2));
                            }
                            break;
                        case TouchPhase.Ended:

                            break;
                        case TouchPhase.Stationary:

                            break;
                        case TouchPhase.Moved:

                            break;
                    }
                }
            }
        }
    }
}
