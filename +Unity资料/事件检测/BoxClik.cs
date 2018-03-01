using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;//TODO Unity里的点击或接触事件需引入这个名称空间
//TODO 弹出窗口的鼠标事件检测类

//TODO 调用引擎系统里的鼠标事件必须满足4个条件（继承下面接口、场景视图里必须有一个EventSystem对象、相机要加[Physics Raycaster组件、触发事件的对象身上必须有碰撞体）
public class BoxClik : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public  GameObject _record;//用来获取“记住密码”复选框的按钮对象
    public UILabel _newLabel;//获取加载情况的Label对象
    //UserAccount ua= new UserAccount();//创建用户账号类以获得对里面成员的控制权
    public void OnPointerDown(PointerEventData data)//鼠标按下时...
    {
        //string name = this.name;没用到
        if (UICamera.isOverUI == true)
        {
            //TODO localScale是获取Transform组件下的Scale(就是调整对象大小那个)属性
            transform.localScale = new Vector3(1.2f, 1.2f, 1);//...让按钮变大为1.2倍

            //Debug.Log(UICamera.lastHit.collider.gameObject.name);

        }

    }
    public void OnPointerUp(PointerEventData data)//鼠标弹起时...
    {
        transform.localScale = new Vector3(1, 1, 1);//...还原按钮大小
        if(name == "OK")
        {
            _newLabel.text = "正在加载。。。if";

        _record.SetActive(true);//用户确定记住密码时就将复选框勾选上
        }
        else
        {

            _newLabel.text = "正在加载。。。else";
        }
            

        transform.parent.gameObject.SetActive(false);//鼠标弹起后隐藏弹窗

    }
}
