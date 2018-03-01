using UnityEngine;
using System.Collections;

public class OnGUIClass : MonoBehaviour {
   
    void Start () {
	
	}
	
	
	void Update () {
	
	}

    //GUILayout：类是用于(Unity gui)的接口，具有自动布局。
    public Texture tex;//测试贴图
    void OnGUI()
    {
        if (!tex)
            //这个是输出错误日志
            Debug.LogError("没有找到纹理，请在检查器上指定纹理");
        if (GUILayout.Button(tex))
            Debug.Log("点击图片");

        if (GUILayout.Button("我是一个常规的自动布局按钮"))
            Debug.Log("点击按钮");
    }
}
