using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO 绘制准星类
public class SightBead : MonoBehaviour {
    //[System.Runtime.InteropServices.DllImport("user32.dll")] //引入dll
    //public static extern int SetCursorPos(int x, int y);
    public Texture2D sightbead;//准星贴图
    public CursorMode cursorMode = CursorMode.ForceSoftware;//设置光标渲染模式为软件渲染
    public Vector2 hotSpot = Vector2.zero;//hotSpot： 纹理左上角的偏移量作为目标点(必须在光标的范围内)。
    void Start() {
        //光标锁定模式_Cursor.lockState： 确定硬件指针是否被锁定到视图的中心(.Locked)、限制在窗口(.Confined)、或者根本不受约束(.None)
        //Cursor.lockState = CursorLockMode.Locked;
        /*Cursor.SetCursor(sightbead, hotSpot, cursorMode);//TODO 将鼠标光标设置为给定的纹理
         *hotSpot： 纹理左上角的偏移量作为目标点(必须在光标的范围内)。
         */
        //Cursor.visible = true;//隐藏光标
    }

    //TODO 这里是全时绘制
    private void OnGUI()
    {
        if (sightbead)//如果贴图存在
        {
            //就绘制准星贴图
            GUI.DrawTexture(new Rect(Screen.width/2-(sightbead.width>>1)/2, Screen.height/2-(sightbead.height>>1)/2-20, sightbead.width>>1, sightbead.height>>1), sightbead);
        }

        //if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 30, 60, 60), "退出"))
        //{
        //    //Application.Quit();//游戏退出
        //}
    }

    ////TODO 这里是当鼠标移至某区域上时绘制或者更换纹理
    ////TODO 在下面的例子中，当OnMouseEnter被调用时，鼠标光标被更改为给定的纹理，当OnMouseExit被调用时，它会被重设为默认值。
    //public Texture2D cursorTexture;//准星贴图
    //public CursorMode cursorMode = CursorMode.Auto;//设置光标渲染模式为允许该光标在受支持的平台上呈现为硬件光标
    ////public Vector2 hotSpot = new Vector2(50, 50);//hotSpot： 纹理左上角的偏移量作为目标点(必须在光标的范围内)。

    //void OnMouseEnter()
    //{
    //    //将鼠标光标设置为给定的纹理 TODO 很重要的实例
    //    Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width >> 1, cursorTexture.height >> 1), cursorMode);
    //}

    //void OnMouseExit()
    //{
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);//null表示设置默认的光标
    //}
    ////TODO ===End===

}