using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO 碰撞检测类
public class MyCollider : MonoBehaviour {
   
    //TODO 进入区域时检测一次(不发生碰撞)
    //private void OnTriggerEnter(UnityEngine.Collider other)//参数是碰撞到的对象
    //{
    //    Debug.Log(other + "发生撞击");
    //}

    //TODO 进入区域时检测一次(发生碰撞)
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name + "碰撞了我");
        //Destroy(collision.gameObject);
    }
}
