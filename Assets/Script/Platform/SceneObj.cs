using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObj : MonoBehaviour
{
    public Vector3 speed;

    public virtual void Start() 
    { 
    
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Movement();
    }

    public void Movement() 
    {
        //GameManager中设置随时间变化的变量，对整局游戏进行控制
        transform.position = transform.position + speed * Time.deltaTime * GameManager.instance.globalTime;
    }
}
