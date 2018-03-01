using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public float speed = 3;
    private float inputX;//通过鼠标或者触摸滑动输入的X值
    private float inputY;//通过鼠标或者触摸滑动输入的Y值
    public Transform mainCamera;//主相机位置组件
    private Vector3 targetPos; //目标位置
    Vector3 setp;//这里是代表标量
    CharacterController controller;//定义一个角色控制器对象
    float distance;//距离(向量)
    void Start()
    {
        //Plane.GetComponent<MeshRenderer>().enabled = false;//对象的网格渲染为false,也就是不显示，但对象是存在的
        //Debug.Log(Mathf.Clamp(10, 1, 3));
        controller = GetComponent<CharacterController>();//将组件赋值给角色控制器
        GetComponent<Rigidbody>().AddForce(Vector3.forward*20);//给刚体添加一个向前运动的力

    }

    void Update()
    {
        //TODO 以下是一般的按键控制移动旋转
        float H = Input.GetAxis("Horizontal") * Time.deltaTime * speed;//垂直轴向的移动输入
        float V = Input.GetAxis("Vertical") * Time.deltaTime * speed;//水平轴向的移动输入
        float cz = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * speed*18;//Mouse ScrollWheel是鼠标滑轮输入
        transform.Translate(H, cz, V, Space.Self);//按自身坐标向前后左右上下移动
        float xz = Input.GetAxis("Vertical1") * Time.deltaTime * 30;//另一个水平轴向表示Z轴旋转的如何
        transform.Rotate(0, 0, xz, Space.Self);//自身坐标Z轴旋转

        //TODO 以下是以鼠标滑动为屏幕旋转的视角
        inputX = Input.GetAxis("Mouse X") * speed;//获取鼠标水平滑动距离
        inputY += Input.GetAxis("Mouse Y") * -speed;//获取鼠标竖直滑动距离
        inputY = Mathf.Clamp(inputY, -45f, 90f);//用数学函数限制可以旋转的角度
        //在相对于父变换的旋转中，欧拉角的旋转
        mainCamera.transform.localEulerAngles = new Vector3(inputY, 0, 0);//以鼠标在Y轴上的偏移量来确定主相机在X轴上的旋转
        transform.Rotate(0, inputX, 0);//以鼠标在X轴上的偏移量来确定整个物体在Y轴上的旋转


        //TODO 以下是发送射线，让物体移动到碰撞点
        if (Input.GetMouseButtonDown(0))
        {   
            // Debug.Log(Input.mousePosition);
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 300)) //300为射线的长度，限制用户瞎点击。在300以外点击无效
        //    {
        //        if (hit.collider.name == "Plane")//如果碰撞到的物体是平面就执行以下代码
        //        {
        //            targetPos = hit.point;//将射线所碰撞到的点(位置)赋给目标位置
        //            //Vector3 lookPos = targetPos - transform.position;//定义自身到目标位置的向量
        //            //transform.LookAt(targetPos - transform.position);//面朝目标这条向量，看向目标位置
        //            transform.rotation = Quaternion.LookRotation(targetPos - transform.position);//当前旋转看向自身到目标的向量，这个更准确
        //            cursor.SetActive(true); //显示图片：图片一开始是隐藏的。
        //            //cursor.transform.position = mousePos;//??
        //            //cursorState = true;//?
        //        }
        //    }

        //}
        //// 目标到当前坐标的向量
        //distance = (float)Vector3.Distance(targetPos, transform.position);
        //if (distance > 1.08f)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Debug.Log("标量 " + setp);
        //        Debug.Log("速度 " + speed);
        //        Debug.Log("向量 " + distance);

        //    }
        //    //控制向量长度在 speed 范围在内
        //    setp = Vector3.ClampMagnitude(targetPos - transform.position, speed);

            //charController.Move(setp*0.3f); //开始我用这个方法。不是我想要的效果
            /*
             *这里要区别于：Move() 一个更加复杂的运动函数，每次都绝对运动             
             * SimpleMove:以一定的速度移动角色
             */
            //cursorState = false;//??
            //controller.SimpleMove(setp);
        }


        //transform.Translate(new Vector3(0, 0,Input.GetAxis("Fire1") * Time.deltaTime));
        // transform.Translate(new Vector3(0, 0, Input.GetAxis("Fire2") * Time.deltaTime * 12));

    }






}