using UnityEngine;
using System.Collections;
//using UnityEngine.AI;

public class MyAI : PausingBehaviour//MonoBehaviour
{
    protected override void OnUpdate()
    {
        
        Debug.Log("{OnUpdate} pause = " + PausingBehaviour.pause);
        //transform.rotation = Quaternion.AngleAxis(180 , Vector3.up);
        transform.Rotate(0, 8, 0, Space.Self);//自身坐标Z轴旋转

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PausingBehaviour.pause = !PausingBehaviour.pause;
        }

    }
}
