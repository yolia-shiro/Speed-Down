using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myRigidbody;

    [Header("Player Basic Message")]
    public float blood;

    [Header("Movement Message")]
    public float velocity;

    [Header("Ground Check")]
    public float groundCheckRadius;
    public Transform groundCheckPoint;
    public LayerMask groundCheckMask;

    [Header("Player State")]
    public bool isGround;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        anim.SetFloat("speed", Mathf.Abs(myRigidbody.velocity.x));
        anim.SetBool("fall", !isGround);
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        PhysicCheck();
        Filp();
        Movement();
    }
    public void Filp()
    {
        if (myRigidbody.velocity.x == 0) return;
        transform.rotation = myRigidbody.velocity.x < 0 ? Quaternion.Euler(0, 180, 0) :  Quaternion.Euler(0, 0, 0);
    }

    public void Movement() 
    {
        float xAxis = Input.GetAxis("Horizontal");

        myRigidbody.velocity = new Vector2(velocity * xAxis, myRigidbody.velocity.y);

    }
    public void PhysicCheck()
    {
        //物理射线检测是否在地面上
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckMask);
    }

    public void GetDamage(float damgae)
    {
        //正在播放受伤动画
        if (isDead || anim.GetCurrentAnimatorStateInfo(0).IsName("hit"))
        {
            return;
        }
        blood -= damgae;
        if (blood <= 0)
        {
            //Dead
            blood = 0;
            isDead = true;
            //GameOver(UIManager控制)
            UIManager.instance.CreateGameOverUI();
        }
        anim.SetTrigger("hit");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edge"))
        {
            GetDamage(blood);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    //}
}
