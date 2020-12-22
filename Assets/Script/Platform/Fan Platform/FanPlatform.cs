using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatform : SceneObj
{
    private Animator anim;

    public override void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            //如果玩家踩在当前平台上
            //打开动画
            anim.Play("fan_platform_on");
        }
    }
}
