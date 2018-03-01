using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO 控制物体旋转类(鼠标视觉)
public class MyRotate : MonoBehaviour {

private float maxYRotation = 360;//Y轴最大旋转角度
private float minYRotation = 0;//Y轴最小旋转角度
private float maxXRotation = 180;//X轴最大旋转角度
private float minXRotation = 0;//X最小旋转角度

private float shootTime = 1;//定义时间计时器
private float shootTimer = 0;//

	void Start () {
        Cursor.visible = false;//设置鼠标指针隐藏
    }

    void Update () {
        //给计时器赋值每秒计时
        shootTime += Time.deltaTime;
        if (shootTimer >= shootTime)
        {
            //1000： 可以射击
        }
        //取得鼠标X轴在屏幕上的中心点(起始)
        float xPosPrecent = Input.mousePosition.x / Screen.width;
        //取得鼠标Y轴在屏幕上的中心点(起始点)
        float yPosPrecent = Input.mousePosition.y / Screen.height;
        //利用数学函数限制鼠标在X轴上可旋转角度
        float xAngle = -Mathf.Clamp(yPosPrecent * maxXRotation,minXRotation,maxXRotation) + 90;
        ////利用数学函数限制鼠标在轴上可旋转角度
        //float yAngle = Mathf.Clamp(xPosPrecent * maxYRotation, minYRotation, maxYRotation) - 180;
        //这里定义了Y轴上可旋转角度为360度
        float yAngle = xPosPrecent * 360 ;
        //旋转当前角度
        transform.eulerAngles = new Vector3(xAngle * Time.deltaTime * 20, yAngle * Time.deltaTime * 20,0);
    }
}