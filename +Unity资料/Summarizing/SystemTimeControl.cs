using UnityEngine;
using System.Collections;
/// <summary>
/// 暂停控制器类
/// </summary>
public class SystemTimeControl : MonoBehaviour
{
    //以下脚本获取是用于手动控制暂停的，自动的在下面的碰撞检测里实现
    public PlayerMove _PlayerMove;
    public MyGameControllor _MyGameControllor;
    void Start()
    {
        //Time.timeScale = 0;    
        _MyGameControllor.ParentPause = _PlayerMove.subPause;//初始化子类的是否受暂停影响标志位的值给父类
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyGameControllor.IsStopGame = !MyGameControllor.IsStopGame;//暂停开关，全局的
            //if (Time.timeScale == 0)
            //{
            //    Time.timeScale = 1;
            //}
            //else if(Time.timeScale == 1)
            //{
            //    Time.timeScale = 0;
            //}     
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _MyGameControllor.ParentPause = !_PlayerMove.subPause;//手动将子类的暂停影响标志位的值给父类
            _PlayerMove.subPause = !_PlayerMove.subPause;//子类标志位开关
        }


    }
    //TODO 以下碰撞检测函数自动检测到并设置敌我双方的暂停、速度等
    //进入区域时检测一次(不发生碰撞)
    private void OnTriggerEnter(UnityEngine.Collider other)//参数是碰撞到的对象
    {
        
        if(other.gameObject.GetComponent<PlayerMove>().Camp == "123")//标签为玩家
        {
            other.gameObject.GetComponent<PlayerMove>().speed = 18;//加速

        }
        if (other.gameObject.GetComponent<PlayerMove>().Camp == "321")//标签为敌人
        {
            other.gameObject.GetComponent<PlayerMove>().subPause = false;
        other.gameObject.GetComponent<MyGameControllor>().ParentPause = other.gameObject.GetComponent<PlayerMove>().subPause;//暂停敌方

        }
        Debug.Log(other.gameObject.GetComponent<PlayerMove>().subPause + other.gameObject.name);
    }
    //离开区域时检测一次(不发生碰撞)
    void OnTriggerExit(Collider other)//参数是碰撞到的对象
    {
        // 摧毁所有离开触发范围的东西
        //Destroy(other.gameObject);
        if (other.gameObject.GetComponent<PlayerMove>().Camp == "123")//标签为玩家
        {
            other.gameObject.GetComponent<PlayerMove>().speed = 2;//还回原速度

        }
        if (other.gameObject.GetComponent<PlayerMove>().Camp == "321")//标签为敌人
        {
            other.gameObject.GetComponent<PlayerMove>().subPause = true;
            other.gameObject.GetComponent<MyGameControllor>().ParentPause = other.gameObject.GetComponent<PlayerMove>().subPause;//不在暂停敌方

        }
        Debug.Log(other.gameObject.GetComponent<PlayerMove>().subPause + other.gameObject.name);
    }

}
