using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private Transform playerTransform;
    private Rigidbody2D playerRig;
    private bool isOnGround = true;

    [Header("Player Movement")]
    [SerializeField] private int speed;
    [SerializeField] private int jumpForce;

    void Awake()
    {
        instance = this;
        playerRig = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        playerTransform.Translate(moveX, 0, 0);

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            playerRig.AddForce(new Vector2(0, 1) * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;

        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DestroyPlayer());
        }
    }

    IEnumerator DestroyPlayer()
    {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(.02f);
        }

        playerTransform.position = new Vector3 (0, 0, 0);
        c.a = 1;

    }

}
