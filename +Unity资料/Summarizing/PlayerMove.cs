using UnityEngine;
using System.Collections;

    //继承MyGameControllor，并复写UpdateGame方法
public class PlayerMove : MyGameControllor
{
    private Transform son;
    public bool moveToLeft = true;
    private float speed = 8;

    private void Start()
    {
        son = this.transform;
    }
    public void Move()
    {
        //一个简单移动的方法，用来观察测试
        //transform.Translate(new Vector3(Random.Range(-1, 1), Random.Range(0, 0), Random.Range(0, 0)) * 8 * Time.deltaTime);
        if (son.position.x <= -3 && moveToLeft)
        {
            moveToLeft = false;
        }
        else if (son.position.x >= 3 && !moveToLeft)
            moveToLeft = true;
            son.position += (moveToLeft ? Vector3.left : Vector3.right) * Time.deltaTime * speed;
    }
    public override void UpdateGame()
    {
        //复写UpdateGame
        Move();
    }
}