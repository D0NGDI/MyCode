using UnityEngine;
public abstract class MyGameControllor : GameControllor
{
    //为什么要写成抽象类的，因为这个控制器本身没有具体的意义，只是控制时间，而且直接控制属性就行了。
    private static bool isStopGame = false;//控制是否暂停

    public static bool IsStopGame
    {
        get { return MyGameControllor.isStopGame; }
        set { MyGameControllor.isStopGame = value; }
    }
    private static float gameTime = 0;//脚本更新的时间，0为正常更新，1代表1秒更新一次

    public static float GameTime
    {
        get { return MyGameControllor.gameTime; }
        set { MyGameControllor.gameTime = value; }
    }
    private static float runtime = 0;//计时器
    private bool IsOnTime = false;

    void Update()//Update更新
    {
        if (IsOnTime)
        {
            UpdateGame();

        }
    }
    void FixedUpdate()//FixedUpdate更新
    {
        if (IsOnTime = (IsRun()))//这里是将方法返回的值赋值给IsOnTime
        {
           
            FixedUpdateGame();
        }
    }

    void LateUpdate()
    {
        if (IsOnTime)
        {
            LateUpdateGame();
        }


    }
    private bool LateTime()//这个判断是否到了更新的时间
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
    private bool IsRun()//判断是否暂停
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
    public override void FixedUpdateGame() { }
    public override void UpdateGame() { }
    public override void LateUpdateGame() { }
}
