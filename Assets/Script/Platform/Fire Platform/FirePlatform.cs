using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlatform : SceneObj
{
    [Header("Fire Message")]
    public float lastTime;
    public float waitTime;
    private float curTime;

    private Animator anim;

    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        curTime = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if (Time.time > curTime + waitTime)
        {
            anim.Play("fire_platform_on");
            curTime = Time.time + lastTime;
        }
        else if (Time.time > curTime)
        {
            anim.Play("fire_platform_off");
        }
    }
}
