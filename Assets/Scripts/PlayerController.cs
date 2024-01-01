using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isJump", false);

        // ����
        if (Input.GetKeyDown(KeyCode.Space) && rigid.velocity.y ==0)
        {
            anim.SetBool("isJump", true);
            rigid.AddForce(Vector2.up * jumpForce);
        }

        // �¿� �̵�
        float direction = Input.GetAxisRaw("Horizontal");
        float speedx = Mathf.Abs(rigid.velocity.x);

        if (speedx < maxWalkSpeed)
            rigid.AddForce(Vector2.right * direction * walkForce);

        // �̵� ���⿡ ���� �̹��� �¿� ����
        if (direction != 0)
            transform.localScale = new Vector3(direction, 1, 1);

        // �̵� �ӵ��� ���� �ִϸ��̼� �ӵ� ����
        if (rigid.velocity.y == 0)
            anim.speed = speedx / 2.0f;
        else anim.speed = 1.0f;

        // �÷��̾ ȭ�� ������ ������� �� ó�� ��ġ�� ����
        if (transform.position.y < -10 || Mathf.Abs(transform.position.x) > 3)
            SceneManager.LoadScene("GameScene");
    }

    // ��߰��� �浹 ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
