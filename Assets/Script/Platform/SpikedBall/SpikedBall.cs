using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : SceneObj
{
    private LineRenderer lineRender;
    public Transform start;
    public Transform end;

    public override void Start()
    {
        base.Start();
        lineRender = GetComponent<LineRenderer>();
    }

    public override void Update()
    {
        base.Update();
        lineRender.SetPosition(0, start.position);
        lineRender.SetPosition(1, end.position);
    }
}
