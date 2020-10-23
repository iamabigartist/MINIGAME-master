using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float TimeScale;
    public bool timeToggle = false;
    private float defaultTimeScale = 1;
    private float defaultfixedDeltaTime = 0.02f;
    private GameObject camera;
    public Vector3 TargetPosition;
    public bool skill = true;
    public float SkillCooldown;
    public float time;
    //public GameObject bullet;

    // Start is called before the first frame update
    private void Start()
    {
        camera = GameObject.Find("Orbit Camera");
    }
    // Update is called once per frame
    void Update()
    {
        if(!skill)
        {
            time = time + Time.deltaTime;
            if(time >=SkillCooldown)
            {
                skill = !skill;
            }
        }
        if (skill)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))//进入技能状态，进入子弹时间
            {
                skill = false;
                time = 0;
                timeToggle = !timeToggle;
                Time.timeScale = timeToggle ? TimeScale : defaultTimeScale;
                Time.fixedDeltaTime = defaultfixedDeltaTime * Time.timeScale;
            }
            /*if (timeToggle && Input.GetMouseButtonDown(0))//完成技能释放，并退出子弹时间
            {
                TargetPosition = transform.position + 12 * camera.transform.forward;
               // GameObject.Instantiate(bullet, transform.position, Quaternion.identity);//生成子弹
                timeToggle = !timeToggle;
                Time.timeScale = timeToggle ? TimeScale : defaultTimeScale;
                Time.fixedDeltaTime = defaultfixedDeltaTime * Time.timeScale;
                //Ray CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Ray CameraRay = new Ray(transform.position, camera.transform.forward);
                //Debug.DrawRay(transform.position,10*camera.transform.forward, Color.green);
                //RaycastHit hit1;
               // bool isHit = Physics.Raycast((Ray)CameraRay, 10);
            }*/
        }
            if (timeToggle && Input.GetKeyDown(KeyCode.A))//完成技能释放，并退出子弹时间
            {
            time = 0;
            Ray ray = new Ray(transform.position, -camera.transform.right);
                RaycastHit hit;
                bool ishit = Physics.Raycast(ray, out hit, 4f);
                if (ishit)
                {
                    TargetPosition = hit.point;
                }
                if (!ishit)
                {
                    TargetPosition = transform.position - 4 * camera.transform.right;
                }
                //TargetPosition = transform.position - 5*camera.transform.right;
                transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, TargetPosition.x, 1f), Mathf.SmoothStep(transform.position.y,
                    TargetPosition.y, 1f), Mathf.SmoothStep(transform.position.z, TargetPosition.z, 1f));
                Invoke("timescale", 0.02f);
            }
            if (timeToggle && Input.GetKeyDown(KeyCode.D))//完成技能释放，并退出子弹时间
            {
            time = 0;
            Ray ray = new Ray(transform.position, camera.transform.right);
                RaycastHit hit;
                bool ishit = Physics.Raycast(ray, out hit, 4f);
                if (ishit)
                {
                    TargetPosition = hit.point;
                }
                if (!ishit)
                {
                    TargetPosition = transform.position + 4 * camera.transform.right;
                }
                //TargetPosition = transform.position + 5 * camera.transform.right;
                transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, TargetPosition.x, 1f), Mathf.SmoothStep(transform.position.y,
                    TargetPosition.y, 1f), Mathf.SmoothStep(transform.position.z, TargetPosition.z, 1f));
                Invoke("timescale", 0.02f);
            }
            if (timeToggle && Input.GetKeyDown(KeyCode.W))//完成技能释放，并退出子弹时间
            {
            time = 0;
            Ray ray = new Ray(transform.position, camera.transform.forward);
                RaycastHit hit;
                bool ishit = Physics.Raycast(ray, out hit, 4f);
                if (ishit)
                {
                    TargetPosition = hit.point;
                }
                if (!ishit)
                {
                    TargetPosition = transform.position + 4 * camera.transform.forward;
                }
                //TargetPosition = transform.position + 5 * camera.transform.forward;
                transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, TargetPosition.x, 1f), Mathf.SmoothStep(transform.position.y,
                    TargetPosition.y, 1f), Mathf.SmoothStep(transform.position.z, TargetPosition.z, 1f));
                Invoke("timescale", 0.02f);
            }
            if (timeToggle && Input.GetKeyDown(KeyCode.S))//完成技能释放，并退出子弹时间
            {
            time = 0;
            Ray ray = new Ray(transform.position, -camera.transform.forward);
                RaycastHit hit;
                bool ishit = Physics.Raycast(ray, out hit, 4f);
                if (ishit)
                {
                    TargetPosition = hit.point;
                }
                if (!ishit)
                {
                    TargetPosition = transform.position - 4 * camera.transform.forward;
                }
                //TargetPosition = transform.position - 5 * camera.transform.forward;
                transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, TargetPosition.x, 1f), Mathf.SmoothStep(transform.position.y,
                    TargetPosition.y, 1f), Mathf.SmoothStep(transform.position.z, TargetPosition.z, 1f));
                Invoke("timescale", 0.02f);
            }
        
    }
    void timescale ()
    {
        timeToggle = !timeToggle;
        Time.timeScale = timeToggle ? TimeScale : defaultTimeScale;
        Time.fixedDeltaTime = defaultfixedDeltaTime * Time.timeScale;
    }
}
