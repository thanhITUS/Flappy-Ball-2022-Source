using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidbodybird;
    public float jumpForce;
    private bool levelStart;
    public GameObject gameController;
    public GameObject message;
    private int score;
    public Text scoreText;

    private void Awake()
    {
        rigidbodybird = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        rigidbodybird.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Update()
    {
        //Kiem tra xem phim Space co duoc bam khong?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundController.instance.PlayThisSound("wing", 0.5f);
            if (levelStart == false)
            {
                levelStart = true;
                rigidbodybird.gravityScale = 3;
                gameController.GetComponent<PipeGenerator>().enablePipe = true;
                message.GetComponent<SpriteRenderer>().enabled = false;
            }
            BirdMoveUp();
        }
    }

    private void BirdMoveUp() //Lam chim bay len 1 khoang
    {
        rigidbodybird.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSound("hit", 0.5f);
        Thread.Sleep(500);
        ReloadScene();
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundController.instance.PlayThisSound("point", 0.5f);
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
