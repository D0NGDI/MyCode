using UnityEngine;
using System.Collections;
using System;
//用户类
[Serializable]//加上这个内置的Json才能用
public class User
{
    public string _userName;
    public string _Password;
    public int _grade;

    public override string ToString()//重写ToString用来返回外部调用对象时的输出
    {
        return string.Format("_userName: {0}, _Password: {1}, _grade: {2}",_userName,_Password,_grade );
    }
}
