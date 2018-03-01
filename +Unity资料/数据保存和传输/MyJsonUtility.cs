using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;//TODO 加载场景需引入此命名空间
//TODO 用Unity内置类转换Json,配合 User 类使用的

public class MyJsonUtility : MonoBehaviour {

    public GameObject _name;//这个类的用户名
    public GameObject _Passlab;//这个类的密码
 
    void Start ()
    {
        User[] user1 = new User[3]//实例化三个对象存储用户名、密码、等级
        {

            new User() {_userName = "花千骨", _Password = "123456", _grade = 180},
            new User() {_userName = "秦始皇", _Password = "654321", _grade = 1000},
            new User() {_userName = "老顽童", _Password = "654321", _grade = 880 },
        };
        for (int i = 0; i < user1.Length; i++)
        {
            Debug.Log(user1[i]);//输出每一个对象的信息
        }
        Debug.Log(user1);
        //Application.LoadLevel(0);//旧式加载场景
        //SceneManager.LoadScene(0);//新式加载场景
    }
    
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            User user1 = new User();
            user1._userName = _name. GetComponent<UIInput>().value;//将用户名输入框的值赋给对象的用户名
            user1._Password = _Passlab.GetComponent<UIInput>().value;//将密码输入框的值赋给对象的密码
            string jsonStr = JsonUtility.ToJson(user1);//将对象的信息转换为Json todo
            Debug.Log(jsonStr);
            
        }
    }
	
	
}

public class lllll
{

}

public class aaaa
{
    
}
