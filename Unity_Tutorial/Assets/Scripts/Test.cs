using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rigid;
    private BoxCollider col;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layerMask;

    private bool isMove;
    private bool isJump;
    private bool isFall;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        TryWalk();
        TryJump();
    }

    //점프 함수
    private void TryJump()
    {
        if(isJump)
        {
            if(rigid.velocity.y<=-0.1f&&!isFall)
            {
                isFall = true;
                anim.SetTrigger("Fall");

            }
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, -transform.up, out hitInfo, col.bounds.extents.y + 0.1f, layerMask))
            {
                anim.SetTrigger("Land");
                isJump = false;
                isFall = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)&&!isJump)
        {
            isJump = true;
            rigid.AddForce(Vector3.up * jumpForce);
            anim.SetTrigger("Jump");
        }
    }
    //이동 함수
    private void TryWalk()
    { 
        float _dirX = Input.GetAxisRaw("Horizontal");   //우측키 1, 좌측키 -1, else 0 반환
        float _dirZ = Input.GetAxisRaw("Vertical");     //상 1, 하 -1, 0

        Vector3 direction = new Vector3(_dirX, 0, _dirZ);

        isMove = false;
        // anim.SetBool("Right", false);
        // anim.SetBool("Left", false);
        // anim.SetBool("Up", false);
        // anim.SetBool("Down", false);

        if (direction != Vector3.zero)
        {
            isMove = true;
            this.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime); //normalized: 대각선으로 이동할때 속도가 빨라지지 않도록 방향만 설정해줌

            // //우측키가 눌렸냐
            // if (direction.x > 0)
            //     anim.SetBool("Right", true);
            // //좌측키
            // else if (direction.x < 0)
            //     anim.SetBool("Left", true);
            // //상
            // else if (direction.z > 0)
            //     anim.SetBool("Up", true);
            // //하
            // else if (direction.z < 0)
            //     anim.SetBool("Down", true);

        }
        anim.SetBool("Move", isMove);
        anim.SetFloat("DirX", direction.x);
        anim.SetFloat("DirZ", direction.z);
    }

}
