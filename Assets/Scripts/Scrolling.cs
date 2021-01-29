using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    Rigidbody2D obj = null;
    public float verticalSpeed  = 10;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null) return;
        
        Vector3 movement = Vector3.up * -verticalSpeed;
        obj.velocity = movement;
    }
}
