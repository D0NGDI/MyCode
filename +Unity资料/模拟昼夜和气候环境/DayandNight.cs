using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO 昼夜系统
//这个脚本挂在一个子物体是平行光的空物体上
public class DayandNight : MonoBehaviour
{
    
    void Start()
    {
       
    }

    //void Update()
    //{
    //        transform.Rotate(Vector3.left * Time.deltaTime*3);//模拟太阳以每秒3度进行旋转
    //}

    //public float smooth = 2.0F;
    //public float tiltAngle = 30.0F;
    /////// <summary>
    /////// TODO 平滑围绕目标旋转 ***未实现
    /////// </summary>
    //void Update()
    //{
    //    float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
    //    float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
    //    Quaternion target = Quaternion.Euler(-tiltAroundX, tiltAroundZ, 0);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    //}


}
