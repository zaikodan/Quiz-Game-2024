using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool onGround, doubleJump, jumping;
    float lowJumpMultiplier = 1.5f, fallMultiplier = 2.5f;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] LayerMask groundMask;

    void Jump()
    {
        if (onGround)
        {
            rigidbody2D.velocity = new Vector2(0, 8);
        }
        else if (doubleJump)
        {
            rigidbody2D.velocity = new Vector2(0, 8);
            doubleJump = false;
        }
    }
    
    void CheckGround()
    {
        onGround = Physics2D.OverlapCircle(transform.position, 0.2f, groundMask);

        if(onGround)
        {
            doubleJump = true;
        }
    }

    void UpdateGravity()
    {
        if(rigidbody2D.velocity.y > 0 && !jumping)
        {
            rigidbody2D.velocity += Physics2D.gravity * lowJumpMultiplier * Time.deltaTime;
        }
        else if(rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.velocity += Physics2D.gravity * fallMultiplier * Time.deltaTime;
        }
    }

    private void Update()
    {
        CheckGround();
        UpdateGravity();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            jumping = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
        }
    }

    void GameOver()
    {
        if(GameManager.instance.Score > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", GameManager.instance.Score);
        }

        Time.timeScale = 0;

        WindowManager.instance.GameOverWindow.SetActive(true);
        WindowManager.instance.FinalScoreText.text = "Score: " + GameManager.instance.Score;
        WindowManager.instance.RecordText.text = "Record: " + PlayerPrefs.GetInt("Record");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            GameOver();
        }
        else if (collision.CompareTag("Point"))
        {
            GameManager.instance.Score++;
            WindowManager.instance.ScoreText.text = "Score: " + GameManager.instance.Score;
        }
    }
}
