using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinePlatform : SceneObj
{
    private Animator anim;

    [Header("Message")]
    public float elasticity;

    public override void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Update()
    {
        base.Update();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("trampoline_platform_jump")
            && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            anim.Play("trampoline_platform_idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            anim.Play("trampoline_platform_jump");
            //为玩家施加力
            collision.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, elasticity), ForceMode2D.Impulse);
        }
    }
}
