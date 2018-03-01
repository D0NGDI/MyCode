using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;//TODO 对引擎做的任何扩展都需引入这个名称空间
using NUnit.Framework;
public class FindMissingScriptsRecursively : EditorWindow
{
    //这三个整数分别表示1.查找了多少对象，2.遍历的所有组件数，3.找到的丢失的脚本数
    static int go_count = 0, components_count = 0, missing_count = 0;
    static List<Transform> results = new List<Transform>();//定义列表来存储查找对象

    [MenuItem("MyWindow/ScriptDetects/MyFindMissing")]
    static void Init()
    {
        // 返回当前在屏幕上的参数类型t的第一个EditorWindow。
        EditorWindow.GetWindow(typeof(FindMissingScriptsRecursively));//参数是窗口的类型(也就是本类)，必须从EditorWindow派生
    }

    private int js = 0;
    private int vs = 0;
    void OnGUI()
    {
        if (GUILayout.Button("Find Missing Scripts in selected GameObjects"))//开始查找
        {
           // results.Clear();//清空列表 ~这里不需要了
            FindInSelected();//调用赋值和查找方法
            vs = 1;
        }
        if (EditorWindow.GetWindow(typeof(FindMissingScriptsRecursively)) == true)
        {
            if (js < 1)
            {
                Debug.Log("Clear");
                results.Clear(); //清空列表
                js++;
            }
            else if (results.Count > 0)//TODO 对象列表长度大于0时遍历对象列表
            {
                foreach (Transform t in results)//TODO 这里一整步加上列表的创建很重要，这部是为了在窗口内Find按钮下显示所查找到的对象
                {
                    EditorGUILayout.ObjectField(t, typeof(Transform), false);//在本窗口的Find按钮下面显示查找到的所有对象
                }
            }

            if (vs == 0)
            {
                GUILayout.Label("无数据");//没找到数据或没有数据时就显示这个
            }
        }
    }

    //赋值所选并遍历要查找的所有对象并传到查找方法里
    private static void FindInSelected()
    {
        GameObject[] go = Selection.gameObjects;//TODO 返回实际的游戏对象选择（就是你在层次面板里所要点击查询的物体，可以多选但子物体箭头要收起来不然不准）。包括预制,non-modifyable对象。
        go_count = 0; //查找的对象数
         components_count = 0;//遍历的所有组件数
        missing_count = 0; //找到的丢失的的脚本数
        foreach (GameObject g in go)//遍历要查找的游戏对象（物体）数组
        {
            FindInGO(g);//这里才是调用查找方法
        }
        //一切都结束后就打印下面的总数日志分别是1.查找了多少对象，2.遍历的所有组件数，3.找到的丢失的的脚本数
        Debug.Log(string.Format("Searched {0} GameObjects, {1} components, found {2} missing", go_count, components_count, missing_count));
    }

    //真正的查找方法
    private static void FindInGO(GameObject g)//参数接收遍历方法里要查找的每一个对象(物体)
    {
        go_count++;//每查找一个对象计数加一
        Component[] components = g.GetComponents<Component>();//将对象的组件这个类型赋给组件数组对象

        for (int i = 0; i < components.Length; i++)
        {
            components_count++; //所遍历的组件数加一
            if (components[i] == null)//TODO 如果哪个组件为空就将找到的丢失的脚本数加一并执行下面的操作（注意这里很重要，这里的组件为空就能找到空脚本）
            {
                missing_count++;//丢失的脚本数加一
                string s = g.name;//把挂空脚本的对象名存给一个字符串
                results.Add(g.transform);//TODO 接着将这个对象添加到列表中去
                Transform t = g.transform;//同时将对象的transform村给一个Transform对象
                while (t.parent != null)//对象的父物体不为空就执行循环
                {
                    s = t.parent.name + "/" + s;//把当前对象(挂空脚本的对象)的名字加上其父物体的名字再赋给s变量
                    t = t.parent;//？？这个必须存在
                }
                //Debug.Log(s + " 的位置上有一个空的脚本: " + i, g);
            }
        }
        // 现在递归遍历每个对象的子对象(如果有的话):    
        foreach (Transform childT in g.transform)
        {
            //Debug.Log("Searching " + childT.name  + " " );    
            FindInGO(childT.gameObject);//递归调用并传入下一个子对象
        }
    }
}