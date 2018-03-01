using UnityEngine;
using System.Collections;
//TODO 新用户注册类
//TODO 鼠标点击链接打开网址，相当重要啊
public class UserRegistration : MonoBehaviour {
    /*(uniform resource locator) URL     
     * 统一资源定位地址，URL 地址,一个网站地址
     */

    void OnClick()
    {
        UILabel lbl = GetComponent<UILabel>();//将当前所挂脚本对象的UILabel组件赋值给UILabel对象

        if (lbl != null)//如果对象上存在UILabel组件
        {
            //在指定的世界空间位置下直接检索URL
            string url = lbl.GetUrlAtPosition(UICamera.lastHit.point);//射线撞击碰撞体的世界坐标中的冲击点，lastHit对2D碰撞体无效
            if (!string.IsNullOrEmpty(url))//如果网址不为空
            {
                //TODO 重要： {[url=http://www.baidu.com/] [u] "新用户注册" [/u][/url]} 这是在Text里贴网址的方法
                Application.OpenURL(url);//在浏览器中打开url（网址）。
                Debug.Log("你点击了我");
            }
        }
    }
}
