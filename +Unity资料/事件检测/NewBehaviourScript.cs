using UnityEngine;
using System.Collections;
//TODO 暂停功能类
public class NewBehaviourScript : MonoBehaviour
{

    bool isP;//是否暂停，的标志位

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//把这个封装成方法就方便了
        {

            if (isP)
            {
                Time.timeScale = 0;//TODO 这个暂停是基于时间的，在Update里不管用，可以用于运动相关和物理系统
                isP = false;
            }
            else
            {
                Time.timeScale = 1;
                isP = true;
            }
        }

        transform.Translate(Vector3.forward * Time.deltaTime* 2f);//TODO 在Update里要加Time.deltaTime暂停才有效

    }

    void FixedUpdate()
    {
        //暂停一般要放在这里
    }
}

