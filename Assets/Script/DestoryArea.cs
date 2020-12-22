using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryArea : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            //销毁
            Destroy(collision.gameObject);
        }
    }
}
