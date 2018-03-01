using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//TODO 实例化，鼠标事件类

public class MyClik : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler//,IPointerClickHandler
{


    Object[] textureAll;//用来存入所加载文件夹下的全部文件，最好是Object类型的
    //private UITexture button;
    void Start()
    {
        //button = this.gameObject.GetComponent<UITexture>();
        //todo 以下是在资源文件夹中的路径中加载所有资源
        //第一个参数是目标文件夹的路径名。当使用空字符串时(例如:“”)函数将加载资源文件夹的全部内容
        //第二个参数是要查找文件的类型（要查找什么类型的文件）
        //_texture = Resources.Load("enemy", typeof(Texture2D));//单个载入
        textureAll = Resources.LoadAll("DengLuUI", typeof(Texture2D));//全部载入
        foreach (var t in textureAll)
            Debug.Log(t);
        //button.mainTexture = textureAll[2] as Texture2D;//更换按钮的主纹理

        // 在任何资源中实例化一个名为“敌人”的预制体
        // 项目资源文件夹中的文件夹.
        //GameObject instance = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;

    }






    //++：UGUI、游戏物体、NGUI(相机要加[Physics Raycaster组件])都可用,但场景中必须有【EventSystem】物体和碰撞体-----------------------------Start--------------------------
    //public void OnPointerClick(PointerEventData pointerEventData)//点下弹起为一次点击
    //{
    //    //Debug.Log(name + "图片");

    //    if (UICamera.isOverUI == true)//鼠标是否停留在了UI上。他是一个bool值,适用于UI
    //    {
    //        Debug.Log(name + "： UI_ Clicked!");

    //    }
    //    else
    //    {
    //        Debug.Log(name + "： Cube_ Clicked!");

    //    }
    //    //if (UICamera.hoveredObject != null)//检测到由UICamera发出的射线所碰触的最后一个UI，适用于物体
    //    //{
    //    //    Debug.Log(name + "： Cube_ Clicked!");
    //    //}
    //}

    private UISprite aUiSprite = new UISprite();
    public void OnPointerDown(PointerEventData data)//点下
    {
        Debug.Log(name);
        if (UICamera.isOverUI == true)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1);
            aUiSprite.depth = this.GetComponent<UISprite>().depth;
            this.GetComponent<UISprite>().depth += 1;
        }

        //button.mainTexture = textureAll[1] as Texture2D;
        //Debug.Log(textureAll[1].name);
    }

    public void OnPointerEnter(PointerEventData data)//移入鼠标（开始接触）
    {
        //Debug.Log(name + "：OnPointerEnter called.");
        // button.mainTexture = textureAll[3] as Texture2D;
        //Debug.Log(textureAll[3].name);
    }

    public void OnPointerExit(PointerEventData data)//移出鼠标（离开接触）
    {
        //Debug.Log(name + "：OnPointerExit called.");
        // button.mainTexture = textureAll[2] as Texture2D;
        //Debug.Log(textureAll[2].name);
    }

    public void OnPointerUp(PointerEventData data)//鼠标弹起
    {
        transform.localScale = new Vector3(1, 1, 1);
        
        this.GetComponent<UISprite>().depth = aUiSprite.depth;


        //Debug.Log(name + "：OnPointerUp called.");
        //button.mainTexture = textureAll[3] as Texture2D;
        //Debug.Log(textureAll[3].name);
    }
    //++：UGUI、游戏物体、NGUI-----------------------------End--------------------------

    //++：游戏物体专用-----------------------------Start--------------------------
    //private void OnMouseEnter()//移入鼠标（开始接触）
    //{
    //    //大按钮 - 创建人物 - 高亮
    //    button.mainTexture = textureAll[3] as Texture2D;
    //    Debug.Log(textureAll[3].name);
    //}
    //private void OnMouseExit()//移出鼠标（离开接触）
    //{
    //    //大按钮 - 创建人物 - 普通
    //    button.mainTexture = textureAll[2] as Texture2D;
    //    Debug.Log(textureAll[2].name);
    //}
    //void OnMouseDown()//点下
    //{
    //    //大按钮 - 创建人物 - 按下
    //    button.mainTexture = textureAll[1] as Texture2D;
    //    Debug.Log(textureAll[1].name);
    //}
    //++：游戏物体专用-----------------------------End--------------------------

}


