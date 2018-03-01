using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;//TODO 对引擎做的任何扩展都需引入这个名称空间
using NUnit.Framework;

/////////////////////////////////////////////////////////////////////////////  
///TOOD 查找节点及所有子节点中,是否有指定的脚本组件  
/////////////////////////////////////////////////////////////////////////////  
public class MonoFinder : EditorWindow// 从这个类派生出一个编辑器窗口。
{
    Transform root = null;//定义要查找的对象（父物体，父节点）
    MonoScript scriptObj = null;//定义要查找的脚本
    int loopCount = 0;//循环次数(查找次数)
    EditorWindow aWindow = new EditorWindow();//要用到这个类的非静态方法
    List<Transform> results = new List<Transform>();//定义列表来存储查找对象

    [MenuItem("MyWindow/ScriptDetects/对象&脚本")]//在引擎菜单栏显示自定义菜单
    static void Init()//系统内置初始化
    {
        // 返回当前在屏幕上的参数类型t的第一个EditorWindow。
        EditorWindow.GetWindow(typeof(MonoFinder));//参数是窗口的类型(也就是本类)，必须从EditorWindow派生
    }
     
    void OnGUI()
    {
        //aWindow.BeginWindows();//标记所有弹出窗口的开始区域。
        GUILayout.Label("节点:");
        //.ObjectField创建一个接收任何对象类型的字段。
        //第一个参数：字段显示的对象。
        //第二个参数：可以分配的对象的类型。
        //第三个参数：是否允许分配场景对象,为false就拖不进对象节点里
        //返回值：由用户设置的对象
        root = (Transform)EditorGUILayout.ObjectField(root, typeof(Transform), true);//给要查找的对象赋值
        GUILayout.Label("脚本类型:");
        scriptObj = (MonoScript)EditorGUILayout.ObjectField(scriptObj, typeof(MonoScript), true);//给要查找的脚本赋值
        if (GUILayout.Button("Find"))
        {
            results.Clear();//清空列表
            loopCount = 0;//查找前结果计数归零
            Debug.Log("开始查找.");
            FindScript(root);//调用查找
        }
        if (results.Count > 0)//对象列表长度大于0时
        {
            foreach (Transform t in results)//遍历对象列表
            {
                EditorGUILayout.ObjectField(t, typeof(Transform), false);//在本窗口的Find按钮下面显示查找到的所有对象
            }
        }
        else
        {
            GUILayout.Label("无数据");//没找到数据或没用数据时就显示这个
        }
    }

    //递归查找方法，参数传入要查找的对象
    void FindScript(Transform root)//参数是查找的物体对象
    {
        if (root != null && scriptObj != null)//对不为空，脚本不为空就开始查找
        {
            loopCount++; //查找次数次数加一
            Debug.Log(string.Format(".." + loopCount + ":" + root.gameObject.name));//输出每个查找日志
            //TODO 这里的GetClass()方法返回由该脚本实现的类的（system.type）对象
            if (root.GetComponent(scriptObj.GetClass()) != null)//TODO 这里是查找核心 如果查找的脚本不是继承自 MonoBehaviour 就会报错，不过也没必要管，因为其本身也没挂载到对象上也就无法运行
            {
                results.Add(root);//添加对象到集合里
            }
            foreach (Transform t in root)//遍历父节点(父物体)下的下一个节点(子物体)，再起一个循环调用自身的作用
            {
                FindScript(t);//递归
            }
        }
    }
}