﻿using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    [Header("SFX")]
    [SerializeField] private AudioClip firetrapSound;

    private bool triggered; //kích hoạt bẫy 
    private bool active; //bẫy hoạt động 

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerHealth != null && active)
            playerHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();

            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerHealth = null;
    }
    private IEnumerator ActivateFiretrap()
    {
        //biến bẫy thành màu đỏ chuẩn bị kích hoạt bẫy 
        triggered = true;
        spriteRend.color = Color.red;

        //chờ độ trễ kích hoạt bẫy 
        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(firetrapSound);
        spriteRend.color = Color.white; //biến sprite trở thành màu ban đầu 
        active = true;
        anim.SetBool("activated", true);

        
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}