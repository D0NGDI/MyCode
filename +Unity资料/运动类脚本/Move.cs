using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//移动类，路标移动
public class Move : MonoBehaviour
{
    
    public float speed = 0.1f;
    
   
    void Start()
    {
        PATH = GameObject.Find("PATH").transform;//~Start()里调用

    }


    void Update()
    {
        LabelMove();
    }
    //TODO ++++++按标签移动
    Vector3 temp1;//当前向量(下一个目标位置到自身位置的向量)
    int i = 0;//记录当前所移动到的目标位置的一个标志位
    private Transform PATH;//路标
    Vector3 direction = new Vector3(0, 0, 0).normalized;//TODO 向量的标量,没用着
    void LabelMove()
    {
        if (i < PATH.childCount)
        {
            temp1 = PATH.GetChild(i).transform.position - transform.position;
        }
        else
        {
            return; //当前目标位置的索引>=最后路标时就退出

        }

        if (temp1.magnitude > 0.5f)
        {
            //TODO 以下特别重要，有关标量normalized
            transform.rotation = Quaternion.LookRotation(temp1);//始终看向当前目标位置（向量）
            transform.position = transform.position + temp1.normalized  * Time.deltaTime * speed;
        }
        else
        {
            i++;
            Debug.Log(i);
        }
    }
}
