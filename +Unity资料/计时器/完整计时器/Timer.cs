using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//注意不继承于MonoBehavior
public class Timer
{
    
    public float StartTime { get; private set; }//开始时间
    
    public float Duration { get; private set; }//持续时间
    
    public float EndTime { get; private set; }//结束时间
    
    public float CurTime { get; private set; }//当前时间

    
    public bool IsStart { get; private set; }//运行标识

    //开始和结束事件，这里直接用System.Action（相当于空返回值无参数委托）
    public Action OnStart { get; set; }
    public Action OnEnd { get; set; }
    public Action OnUpdate { get; set; }

    //构造函数，设置计时器
    public Timer(float duration)
    {
        Duration = duration;
    }

    //开始计时 Timer类不继承于MonoBehaviour，该方法不会在任何对象开始时被调用。
    public void Start()
    {
        IsStart = true;
        StartTime = Time.time;
        CurTime = StartTime;
        EndTime = StartTime + Duration;
        //新增这一行↓
        CenterTimer.AddTimer(this);
        StartCount++;
        if (OnStart != null) OnStart();
    }

    //更新时间，并检查状态。Timer类不继承于MonoBehaviour，该方法将在中心计时器每帧调用。
    public void Update()
    {
        if (!IsStart) return;
        CurTime += Time.deltaTime;
        if (IsPause) EndTime += Time.deltaTime;
        if (CurTime > EndTime)
        {
            End();
        }
        else if (OnUpdate != null) OnUpdate();
    }

    //计时器结束
    void End()
    {
        IsStart = false;
        FinishCount++;
        if (OnEnd != null) OnEnd();
        //新增这一行↓
        CenterTimer.RemoveTimer(this);
    }

    //取消事件
    public Action OnCancel { get; set; }

    //取消接口。
    public void Cancel()
    {
        IsStart = false;
        if (OnCancel != null) OnCancel();
    }

    //事件
    public Action OnPause { get; set; }
    public Action OnContinue { get; set; }

    //属性
    public bool IsPause { get; private set; }

    //取消接口
    public void Pause()
    {
        IsPause = false;
        if (OnCancel != null) OnCancel();
    }

    //继续接口
    public void Continue()
    {
        IsPause = true;
        if (OnContinue != null) OnContinue();
    }

    //重置接口
    public void Reset()
    {
        IsStart = false;
        IsPause = false;
        //新增这一行↓
        CenterTimer.RemoveTimer(this);
    }

    //计时器已经完成的百分比
    public float Ratio
    {
        get
        {
            if (!IsStart)
            {
                return 0;
            }
            else
            {
                return 1 - (EndTime - CurTime) / Duration;
            }
        }
    }

    //计时器次数，可用于循环计时、检测是否已经完成等。（常规循环计时推荐新定义循环计时器）
    public int StartCount { get; private set; }//开始次数
    public int FinishCount { get; private set; }//完成次数



}
