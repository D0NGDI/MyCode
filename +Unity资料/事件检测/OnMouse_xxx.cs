using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//TODO Unity里的点击或接触事件需引入这个名称空间
//TODO 鼠标点击事件类
//TODO 调用引擎系统里的鼠标事件必须满足4个条件（继承下面接口、场景视图里必须有一个EventSystem对象、相机要加[Physics Raycaster组件、触发事件的对象身上必须有碰撞体）

//TODO 自定义事件类
public class OnMouseClick : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler//,IPointerClickHandler 
{
    public GameObject B2;//一个UI对象
    public Button yourButton;//定义一个按钮

    void Start()
    {
        //给按钮赋值
        //Button btn = yourButton.GetComponent<Button>();
        //给这个按钮将下面的自定义点击事件注册进点击事件监听里
       // btn.onClick.AddListener(TaskOnClick);
    }
    
    //TODO 1种：自定义点击事件
    //void TaskOnClick()//自定义的点击事件
    //{
    //    Debug.Log("你点击了按钮!");
    //    //B2.GetComponent<Image>().color = Color.red;//触发点击后更改UI的颜色
    //}
    
    //TODO 2种：NGUI里点击事件
    void OnClick()//NGUI的鼠标点击事件,todo 只对NGUI管用
    {
        Debug.Log("你点击了：" + name);
    }

    //TODO 3种：Unity自带对象点下事件
    void OnMouseDown(){
        
    }
}

//TODO 鼠标接触事件类
public class OnMouseHover : MonoBehaviour {
    
    
    //TODO 1. NGUI鼠标接触事件
    private bool isEnter = false;//鼠标进出的标志位
    //这是NGUI里的函数,todo 对NGUI和游戏物体都有用
    void OnHover()//因为这个函数在鼠标进入移出都会触发一次，所以这里利用这个性质写了一个伪OnMouseEnter的功能
    {
        isEnter = !isEnter;
        if (isEnter)//如果标志位为进入
        {
            OnMouseEn();
        }
        else
        {
            OnMouseEx();
        }
    }
    private void OnMouseEn()//伪OnMouseEnter的进入功能
    {
        Debug.Log("鼠标进入" + name);
    }
    private void OnMouseEx()//伪OnMouseExit的移出事件函数
    {
        Debug.Log("鼠标移出" + name);
    }
    
    //TODO 2.Unity自带对象鼠标进入事件
    void OnMouseEnter(){
        
    }
}