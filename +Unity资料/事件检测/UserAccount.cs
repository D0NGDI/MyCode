using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.EventSystems;
//TODO 封装好的登陆框交互事件类

public class UserAccount : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler,  IPointerUpHandler
{
    public GameObject[] _user;//保存交互控件
    UIInput _Unlab;//保存用户名输入框
    UIInput _Passlab;//保存密码输入框
    void Start()
    {
        _Unlab = _user[0].GetComponent<UIInput>();//给输入框赋值
        _Passlab = _user[1].GetComponent<UIInput>();
    }
    void Update()
    {
        //if（isPause）return;//只能这样实现全局暂停
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputBoxDetection();//输入框交互逻辑
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            InputBoxDetection();
            if (_Passlab.value != "" && _Passlab.isSelected)
            {
                _Passlab.isSelected = false;//输入框不被选中（清除焦点）

                _user[3].SetActive(true);//显示提示框
            }
        }
    }

    void FixedUpdate()
    {

    }


    //输入框交互逻辑(上面键盘按键调用的)
    void InputBoxDetection()
    {
        if (!_Unlab.isSelected && _Unlab.value == "请输入用户名" || !_Unlab.isSelected && _Unlab.value == "")
        {
            User(_Unlab);
            _Unlab.isSelected = true;//输入框选中（获取焦点）
        }
        else if (!_Passlab.isSelected && _Unlab.value != "")
        {
            User(_Passlab);
            _Passlab.isSelected = true;
        }
    }


    //输入框交互逻辑(鼠标点击)
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //判断鼠标所点击的UI名称方法（判断鼠标点击的UI）
        //Debug.Log(UICamera.lastHit.collider.gameObject);//显示当前所点击碰撞体所属UI对象（物体）及其子对象名称
        //Debug.Log(gameObject. name);//当前所挂脚本的对象
        if (UICamera.isOverUI == true && _Unlab.isSelected)//是否在UI上并且是否被选中 TODO
        {
            User(_Unlab);
            if (_Passlab.value == "")
                _Passlab.value = "请输入密码";

        }
        else if (UICamera.isOverUI == true && _Passlab.isSelected)
        {
            User(_Passlab);
            if (_Unlab.value == "")
                _Unlab.value = "请输入用户名";
        }
    }
    void User(UIInput user)//参数为传入的是那个输入框
    {
        user.value = "";
        user.caretColor = Color.blue;//更改光标颜色为蓝色
        user.GetComponent<UIWidget>().depth = 2;//输入框的UI层提高一层
        //限制输入字符数
        user.characterLimit = user.name == "UserName" ? 6 : 12;
    }


    ////判断鼠标是是否在UI界面上，仅供参考
    //public static bool IsMouseOverUI
    //{
    //    get
    //    {

    //        Vector3 mousePostion = Input.mousePosition;
    //        GameObject hoverobject = UICamera.Raycast(mousePostion) ? UICamera.lastHit.collider.gameObject : null;
    //        if (hoverobject != null)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}

    /// <summary>
    /// TODO 输入数据提交事件，非常重要
    /// TODO EventDelegate 代表事件函数，类，NGUI的UI事件交互类，这里是用来监听并触发
    /// </summary>
    public UIInput input;//输入框
    void OnEnable()
    {
        EventDelegate.Add(input.onSubmit, ReturnCallBack);//第一个参数传入一个委托事件，第二个参数是你要回调的函数
    }

    void OnDisable()
    {
        EventDelegate.Remove(input.onSubmit, ReturnCallBack);//从列表中删除现有的事件委托。
        EventDelegate.Execute(input.onSubmit);//执行完整的委托列表
    }

    public UILabel txt_content;
    public void ReturnCallBack()//待监听并处理的事件函数
    {
        txt_content.text = input.value;
    }


}
