using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Goal : MonoBehaviour
{
    public GameObject player = default;
    public GameObject lion = default;
    public Rigidbody2D playerRigid = default;
    public float speed = 0f;
    public float jumpForce = 0f;
    public int jumpCount = 0;

    public GameObject joyStickHandle = default;

    public AudioSource audioSource = default;
    public AudioClip jumpClip = default;

    public bool isClear = false;

    private Animator pAnimator = default;
    private Animator lAnimator = default;

    private void Awake()
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

        // if (Input.GetKey(KeyCode.RightArrow))
        if (joyStickHandle.transform.localPosition.x > 0)
        {
            pAnimator.SetBool("isMove", true);
            lAnimator.SetBool("isRun", true);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        // else if (Input.GetKey(KeyCode.LeftArrow))
        else if (joyStickHandle.transform.localPosition.x < 0)
        {
            pAnimator.SetBool("isMove", true);
            lAnimator.SetBool("isBack", true);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (joyStickHandle.transform.localPosition.x == 0)
        {
            pAnimator.SetBool("isMove", false);
            lAnimator.SetBool("isRun", false);
            lAnimator.SetBool("isBack", false);
        }

        // if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    pAnimator.SetBool("isMove", false);
        //    lAnimator.SetBool("isRun", false);
        //}
        // else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    pAnimator.SetBool("isMove", false);
        //    lAnimator.SetBool("isBack", false);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Finish"))
        {
            pAnimator.SetTrigger("Win");

            isClear = true;
            GameManager.instance.isPlayerClear = isClear;

            GameManager.instance.bonusNum = 0;
            return;
        }

        pAnimator.SetBool("isMove", false);
        lAnimator.SetBool("isJump", false);
        jumpCount = 0;
    }

    public void Jump()
    {
        audioSource.clip = jumpClip;
        audioSource.Play();

        pAnimator.SetBool("isMove", false);
        lAnimator.SetBool("isRun", false);
        lAnimator.SetBool("isBack", false);

        lAnimator.SetBool("isJump", true);

        playerRigid.velocity = Vector3.zero;
        playerRigid.AddForce(new Vector2(0, jumpForce));
    }
}
