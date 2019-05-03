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

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PausingBehaviour.pause = !PausingBehaviour.pause;
        }

    }
    /// <summary>
    /// 暂停开始时会调用该方法.
    /// </summary>
    protected override void OnPauseEnter()
    {
        //Debug.Log("OnPauseEnter = " + PausingBehaviour.pause);

    }

    /// <summary>
    /// 暂停结束时会调用该方法.
    /// </summary>
    protected override void OnPauseExit()
    {
        //Debug.Log("OnPauseExit = " + PausingBehaviour.pause);

    }
}
