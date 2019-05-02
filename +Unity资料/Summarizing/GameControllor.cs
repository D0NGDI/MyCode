using UnityEngine;
/// <summary>
/// 一个抽象的更新函数主框架，用来声明接管系统更新函数的自定义的更新函数
/// </summary>
public abstract class GameControllor : MonoBehaviour
{
    /// <summary>
    /// 接管 系统FixedUpdate的自定义更新函数
    /// </summary>
    public abstract void FixedUpdateGame();//一个按照FixedUpdate更新的函数，当然你可以自己定义或者添加，在子类中复写就行了，注意你的需求是基于哪个更新
    /// <summary>
    /// 接管 系统Update的自定义更新函数
    /// </summary>
    public abstract void UpdateGame();//一个按照Update更新的函数，同上
    /// <summary>
    /// 接管 系统LateUpdate的自定义更新函数
    /// </summary>
    public abstract void LateUpdateGame();//一个按照LateUpdate更新的函数，同上
    /// <summary>
    /// 暂停开始时会调用该方法.
    /// </summary>
    public abstract void PauseEnter();
    /// <summary>
    /// 暂停结束时会调用该方法.
    /// </summary>
    public abstract void PauseExit();



}



