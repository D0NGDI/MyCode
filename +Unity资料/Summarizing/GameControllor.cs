using UnityEngine;

public abstract class GameControllor : MonoBehaviour
{


    //先写一个主框架，用来声明更新的函数
    public abstract void FixedUpdateGame();//一个按照FixedUpdate更新的函数，当然你可以自己定义或者添加，在子类中复写就行了，注意你的需求是基于哪个更新
    public abstract void UpdateGame();//一个按照Update更新的函数，同上
    public abstract void LateUpdateGame();//一个按照LateUpdate更新的函数，同上




}



