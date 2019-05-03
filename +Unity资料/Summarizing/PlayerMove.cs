using UnityEngine;
using System.Collections;
/// <summary>
/// 需要暂停的实际功能脚本类，可以是单位等任何需要暂停功能的对象脚本
/// //继承MyGameControllor，并复写更新方法
/// </summary>
public class PlayerMove : MyGameControllor
{
    private Transform son;//用来获取自身 transform组件
    public bool moveToLeft = true;
    public float speed = 8;//速度比时间缩放加成高
    /// <summary>
    /// 标识单位所属阵营
    /// </summary>
    public string Camp = "";
    /// <summary>
    /// 标志自身是否受暂停影响，传值给父类等待接收的 ParentPause
    /// </summary>
    public bool subPause = true;

    private void Start()
    {
        son = this.transform;
        //ParentPause = subPause;
    }

    //一个简单移动的方法，用来观察测试
    public void Move()
    {
        //transform.Translate(new Vector3(Random.Range(-1, 1), Random.Range(0, 0), Random.Range(0, 0)) * 8 * Time.deltaTime);
        if (son.position.x <= -3 && moveToLeft)//来回移动
        {
            moveToLeft = false;
        }
        else if (son.position.x >= 3 && !moveToLeft)//来回移动
            moveToLeft = true;
        son.position += (moveToLeft ? Vector3.left : Vector3.right) * Time.deltaTime * speed;//
    }

    public override void UpdateGame()//复写UpdateGame
    {
        Move();  
    }
    public override void FixedUpdateGame()//复写FixedUpdateGame
    {
        //Move();     
    }
    public override void PauseEnter()//暂停开始时会调用该方法.运行一次
    {
        
    }
    public override void PauseExit()//暂停结束时会调用该方法.运行一次
    {
        
    }
}