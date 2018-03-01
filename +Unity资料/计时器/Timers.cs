using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO 计时器类
    
    //TODO 方法①：使用变量在Update中计时，也是各种书中最常见的方法。
public class Timers : MonoBehaviour {
    private float lastTime;//定义上一次时间
    private float curTime;//current单词的缩写：现在的时间

    void Start()
    {
        lastTime = Time.time;//将一开始的系统时间赋值给上一次时间
    }

    void Update()
    {
        curTime = Time.time;//当前时间为系统时间
        if (curTime - lastTime >= 3)//当前时间大于等于上一次记录时间3秒执行
        {
            Debug.Log("work");
            lastTime = curTime;//接着将当前时间又赋值给时间记录
        }
    }
}

//TODO 方法②：使用协程Coroutine
//public class Timers : MonoBehaviour
//{
//    void Start()
//    {
//        StartCoroutine(Do()); // 开启协程
//    }

//    IEnumerator Do()
//    {
//        while (true) // 还需另外设置跳出循环的条件
//        {
//            yield return new WaitForSeconds(3.0f);
//            Debug.Log("work");
//        }
//    }
//}

//TODO 方法③：使用InvokeRepeating
//public class Timers : MonoBehaviour
//{
//    void Start()
//    {
//        InvokeRepeating("Do", 3.0f, 3.0f);//游戏开始后3秒执行，之后每3秒执行一次（引号里面的方法）
//    }

//    void Do()
//    {
//        Debug.Log("work");
//        Debug.Log("秒数 "+second);

//    }
//}
