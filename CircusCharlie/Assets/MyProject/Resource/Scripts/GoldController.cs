using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    public AudioSource audioSource = default;
    public AudioClip bonusClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.clip = bonusClip;
        audioSource.Play();
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void ActivateGold()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }
}
