using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public int speed;      //移动速度
    public float tilt;     //旋转时的参数，控制旋转幅度
    public Boundary boundary;
    public GameObject shot;     //获取子弹预制体
    public Transform shotSpawn; //子弹生成的父类
    public float fireRate;      //子弹发射率

    private float nextFire;     //计时器，下一次发射
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        //移动控制代码
        float moveHorizontal = Input.GetAxis("Horizontal");      //水平方向
        float moveVertical = Input.GetAxis("Vertical");          //垂直方向
        Vector3 moveMent = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = moveMent * speed;
        //位置限制使用Mathf.clamp范围
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
        //飞行时的飞机旋转由水平方向速度控制旋转幅度
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}


