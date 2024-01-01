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

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && rigid.velocity.y ==0)
        {
            anim.SetBool("isJump", true);
            rigid.AddForce(Vector2.up * jumpForce);
        }

        // 좌우 이동
        float direction = Input.GetAxisRaw("Horizontal");
        float speedx = Mathf.Abs(rigid.velocity.x);

        if (speedx < maxWalkSpeed)
            rigid.AddForce(Vector2.right * direction * walkForce);

        // 이동 방향에 따른 이미지 좌우 반전
        if (direction != 0)
            transform.localScale = new Vector3(direction, 1, 1);

        // 이동 속도에 따른 애니메이션 속도 조정
        if (rigid.velocity.y == 0)
            anim.speed = speedx / 2.0f;
        else anim.speed = 1.0f;

        // 플레이어가 화면 밖으로 사라졌을 시 처음 위치로 복귀
        if (transform.position.y < -10 || Mathf.Abs(transform.position.x) > 3)
            SceneManager.LoadScene("GameScene");
    }

    // 깃발과의 충돌 판정
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
