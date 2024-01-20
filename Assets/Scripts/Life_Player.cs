using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life_Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator aim;
    private Rigidbody2D rb;
    private void Start()
    {
        aim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        aim.SetBool("death", true);
    }
    private void ResetLv()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
