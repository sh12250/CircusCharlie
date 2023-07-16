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


    public int score = 0;
    public int detect = 0;

    public bool isDead = false;

    private Animator pAnimator = default;
    private Animator lAnimator = default;


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

        if (detect == 16)
        {
            PlayerController_Goal pCon_Goal = gameObject.GetComponent<PlayerController_Goal>();
            pCon_Goal.enabled = true;

            PlayerController pCon = gameObject.GetComponent<PlayerController>();
            pCon.enabled = false;
        }
    }

    private void Die()
    {
        pAnimator.SetTrigger("Die");
        lAnimator.SetTrigger("Die");

        playerRigid.gravityScale = 0;

        playerRigid.velocity = Vector2.zero;

        isDead = true;
        GameManager.instance.isPlayerDead = isDead;

        PlayerController_Goal pCon_Goal = GetComponent<PlayerController_Goal>();
        pCon_Goal.enabled = false;
        enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Finish"))
        {
            pAnimator.SetTrigger("Win");
            GameManager.instance.AddScore(GameManager.instance.bonusNum);
            GameManager.instance.bonusNum = 0;
            return;
        }

        GameManager.instance.AddScore(score);
        score = 0;

        pAnimator.SetBool("isMove", false);
        lAnimator.SetBool("isJump", false);
        jumpCount = 0;
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
            detect += 1;
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
