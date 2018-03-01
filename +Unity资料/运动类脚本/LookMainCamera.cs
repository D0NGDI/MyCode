using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO 让物体看向自身(最好的看向)，必须配合血条跟随(BloodBar)使用在看高处和嫡出时才不会变位
public class LookMainCamera : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        //TODO 以下是Vector3转换为Quaternion
        //任意方向（向量）转换为当前物体坐标看向的方向===
        //Vector3 relativePos = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(-relativePos);
        //transform.rotation = rotation;
        //一句话版===
        transform.rotation = Quaternion.LookRotation(-(target.position - transform.position));

        //TODO 将transform中的rotation修改成(0,30,0)
        //Vector3 rotationVector3 = new Vector3(0f, 30f, 0f);
        //Quaternion rotation = Quaternion.Euler(rotationVector3);
        //transform.rotation = rotation;
        //TODO Quaternion.eulerAngles直接输出Quaternion的Vector3值
    }
}

//TODO 血条在物体上的坐标（世界坐标中的血条跟随）
//public class BloodBar : MonoBehaviour
//{
//    public GameObject character;//要跟随的对象
//    void Update()
//    {
//        transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 0.8f, character.transform.position.z);
//    }
//}
