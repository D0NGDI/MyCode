using UnityEngine;
using System.Collections;
//TODO 背景移动类
public class BackGroundMove : MonoBehaviour {
    public  GameObject target;//目标对象(拖动对象赋值) TODO 

    void Start()
    {
       
    }
    void FixedUpdate()
    {                       
                                       //TODO Lerp适合做移动，都是先快后慢
       transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 0.15f);
                                      //TODO Slerp适合做旋转，都是先快后慢
        transform.rotation = Quaternion.Slerp(transform.rotation , target.transform.rotation, Time.deltaTime * 0.15f);

    }
}
