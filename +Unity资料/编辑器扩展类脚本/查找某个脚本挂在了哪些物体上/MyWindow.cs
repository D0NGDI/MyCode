using UnityEngine;
using System.Collections;
using UnityEditor;
public class MyWindow : EditorWindow
{
    string myString = "你好世界";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    // 在窗口中添加名为“我的窗口”的菜单
    [MenuItem("MyWindow/One：")]
    static void Init()
    {
        // 打开现有的窗口，如果没有，新建一个窗口:
        MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
        window.Show();
        //EditorWindow.GetWindow(typeof(MyWindow));
    }

    void OnGUI()
    {
        GUILayout.Label("基本设置", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("文本框", myString);//输入框

        groupEnabled = EditorGUILayout.BeginToggleGroup("可选设置", groupEnabled);//上级复选框
        myBool = EditorGUILayout.Toggle("开关", myBool);//复选框
        myFloat = EditorGUILayout.Slider("滑块", myFloat, -3, 3);//滑动条
        EditorGUILayout.EndToggleGroup();
    }
}
