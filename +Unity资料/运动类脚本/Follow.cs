using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO 目标跟随
public class Follow : MonoBehaviour {
    Vector2 player2DPosition;//定义一个2D坐标存储目标对象的屏幕坐标
    void Start () {
	}

    public float xOffset = 6f;//在目标X轴上的偏移量
    public float yOffset = 30f;//在目标Y轴上的偏移量
    public RectTransform recTransform;//定义坐标组件好调整自身坐标

    void Update()
    {
        //todo 以下两种从世界坐标转屏幕坐标的方法
        //player2DPosition;//= Camera.main.WorldToScreenPoint(transform.position);
        player2DPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);//当前坐标等于目标坐标加上X,Y轴上的偏移量

        //todo 血条超出屏幕就不显示
        if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        {
            recTransform.gameObject.SetActive(false);
        }
        else
        {
            recTransform.gameObject.SetActive(true);
        }
    }
}
