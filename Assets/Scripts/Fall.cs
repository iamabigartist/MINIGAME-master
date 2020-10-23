using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFall = false;
    private GameObject Trigger;
    public float RotateSpeed;
    public float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isFall = GameObject.Find("fallTrigger").GetComponent<FallTrigger>().fall;
        if (isFall == true)
        {
            transform.Rotate(0, 0, RotateSpeed * Time.deltaTime, Space.Self);
            Invoke("distroy",time);
        }
    }
    void distroy ()
    {
        GameObject.Destroy(this);
    }
}
