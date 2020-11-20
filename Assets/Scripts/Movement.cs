using Assets.HeroEditor.Common.CharacterScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 10f;

    //SimpleInput simpleI;
    Rigidbody2D rb;
    Character character;
    // Test 
    private bool isGrounded, isJump = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask Ground;
    //  public Button btnJump;
    private int score = 0;
    private bool facingRight;

    public TextMeshProUGUI  txtScore;
    //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    //    btnJump.onClick.AddListener(ClickJump_Event);
        facingRight = true;
    }

    private void ClickJump_Event()
    {
        isJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Xoay mặt
        float h = Input.GetAxis("Horizontal");
        Flip(h);

        Jump();

    }
    private void FixedUpdate()
    {
        Walk();
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, Ground); // Kiểm tra xem nhân vật có đang đứng trên mặt đất không ?

        //if (isGrounded && isJump)
        //{
        //    rb.velocity = Vector2.up * jumpForce;

        //    character.Animator.SetBool("Jump", true);
        //}
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // rb.AddForce(Vector2.up * jumpForce);
            rb.velocity = Vector2.up * jumpForce;
        }
        isJump = false;
        character.Animator.SetBool("Jump", false);


    }


    void Walk()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += move * speed * Time.deltaTime;
        if (move.sqrMagnitude > 0.3)
            character.Animator.SetBool("Run", true);
        else
            character.Animator.SetBool("Run", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score = score++;
            Debug.Log(score++);
            ScoreManager.instance.ChangeScore(score);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene("NgumCuToi");
            File.WriteAllText(Environment.CurrentDirectory + @"/Score.txt", txtScore.text);
        }
    }
    private void Flip(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;

            transform.localScale = temp;
        }
    }
}
