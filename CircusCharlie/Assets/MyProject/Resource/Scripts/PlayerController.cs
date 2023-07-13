using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player = default;
    public GameObject lion = default;
    public Rigidbody2D playerRigid = default;
    public float jumpForce = 0f;
    public int jumpCount = 0;

    private Animator pAnimator = default;
    private Animator lAnimator = default;

    int score = 0;
    void Start()
    {
        pAnimator = player.GetComponent<Animator>();
        lAnimator = lion.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && jumpCount < 1)
        {
            jumpCount += 1;

            Jump();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pAnimator.SetBool("isMove", true);
            lAnimator.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            pAnimator.SetBool("isMove", true);
            lAnimator.SetBool("isBack", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            pAnimator.SetBool("isMove", false);
            lAnimator.SetBool("isRun", false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            pAnimator.SetBool("isMove", false);
            lAnimator.SetBool("isBack", false);
        }
    }

    private void Die()
    {
        pAnimator.SetTrigger("Die");
        lAnimator.SetTrigger("Die");

        playerRigid.velocity = Vector2.zero;

        GameManager.instance.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Finish"))
        {
            pAnimator.SetTrigger("Win");
            return;
        }

        GameManager.instance.AddScore(score);
        score = 0;
        jumpCount = 0;

        pAnimator.SetBool("isMove", false);
        lAnimator.SetBool("isJump", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead"))
        {
            Die();
        }

        if (collision.tag.Equals("Ring"))
        {
            score += 50;
        }
        if (collision.tag.Equals("Pot"))
        {
            score += 150;
        }
        if (collision.tag.Equals("Gold"))
        {
            score += 500;
        }
    }

    private void Jump()
    {
        pAnimator.SetBool("isMove", false);
        lAnimator.SetBool("isRun", false);
        lAnimator.SetBool("isBack", false);

        lAnimator.SetBool("isJump", true);

        playerRigid.velocity = Vector3.zero;
        playerRigid.AddForce(new Vector2(0, jumpForce));
    }
}
