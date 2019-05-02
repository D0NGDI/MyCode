using UnityEngine;
/// <summary>
/// 暂停功能实现类
/// 为什么要写成抽象类的，因为这个控制器本身没有具体的意义，只是控制时间，而且直接控制属性就行了。
/// </summary>
public abstract class MyGameControllor : GameControllor
{
    private static bool isStopGame;//= false;//控制是否暂停
    /// <summary>
    /// 控制是否暂停(全局暂停)
    /// </summary>
    public static bool IsStopGame
    {
        get { return MyGameControllor.isStopGame; }
        set { MyGameControllor.isStopGame = value; }
    }
    private static float gameTime = 0;//脚本更新的时间，0为正常更新，1代表1秒更新一次
    /// <summary>
    /// 脚本(暂停)更新的时间，0为正常更新，1代表1秒更新一次(用于慢动作)
    /// </summary>
    public static float GameTime
    {
        get { return MyGameControllor.gameTime; }
        set { MyGameControllor.gameTime = value; }
    }
    private   bool parentPause = true;//用于接收子类脚本里受不受暂停影响的标志
    /// <summary>
    /// 接收子类脚本是否受暂停影响的标志位
    /// </summary>
    public  bool ParentPause
    {
        get { return parentPause; }
        set { parentPause = value; }
    }
    
    private static float runtime = 0;//计时器
    private bool IsOnTime = false;//控制三个更新方法是否暂停的标志位，受 IsStopGame影响
    private bool isPausing;//暂停状态，是否正在暂停中
    static MyGameControllor()
    {
        IsStopGame = false;
    }

    void OnEnable()
    {
        isPausing = IsStopGame;
    }

    void Update()//UpdateGame更新
    {
        if (IsOnTime )//开始更新
        {     
            if(ParentPause == true)//过滤子类受影响的脚本
            {
                UpdateGame();

            }
            if (isPausing)
            {
                this.PauseExit();//暂停结束     
                isPausing = false;
            }
        }
        else
        {
            if (!isPausing)
            {
                this.PauseEnter();//暂停开始
                isPausing = true;
            }
        }
    }
    void FixedUpdate()//FixedUpdateGame更新
    {
        if (IsOnTime = (IsRun()))//TODO重点：这里是将方法返回的值赋值给IsOnTime
        {          
            if(ParentPause == true)//过滤子类受影响的脚本
            {
                FixedUpdateGame();

            }
        }
    }

    void LateUpdate()//LateUpdateGame更新
    {
        if (IsOnTime)
        {
            if(ParentPause == true)//过滤子类受影响的脚本
            {
                LateUpdateGame();

            }
        }


    }
    /// <summary>
    /// 这个判断是否到了更新的时间
    /// </summary>
    /// <returns></returns>
    private bool LateTime()
    {
        if (GameTime <= 0) return true;
        runtime += Time.fixedDeltaTime;
        if (runtime >= GameTime)
        {
            runtime = 0;
            return true;
        }
        return false;
    }
    /// <summary>
    /// 判断是否暂停的方法，由此返回值给 IsOnTime
    /// </summary>
    /// <returns></returns>
    private bool IsRun()
    {
        if (!IsStopGame)
        {
            if (LateTime())//不是暂停时判断是否到了更新的时间
            {
                return true;
            }
        }
        return false;
    }
    public override void FixedUpdateGame() { }//按例重写，必须要重写，尽管功能在其下子类完成
    public override void UpdateGame() { }
    public override void LateUpdateGame() { }
    public override void PauseEnter() { }
    public override void PauseExit() { }
}