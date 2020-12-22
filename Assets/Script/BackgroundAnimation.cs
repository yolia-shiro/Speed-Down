using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    private Material material;
    private Vector2 movement;

    public Vector2 speed;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        movement = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        movement += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", movement);
    }
}
