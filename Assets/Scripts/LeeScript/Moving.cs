using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 rotation;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += velocity*Time.deltaTime;
        transform.Rotate(rotation);
    }
}
