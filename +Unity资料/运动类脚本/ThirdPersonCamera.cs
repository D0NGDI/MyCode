using UnityEngine;
using System.Collections;

//TODO 第三人称摄像机
public class ThirdPersonCamera : MonoBehaviour
{
 public float distanceAway;			//从目标到相机的水平距离
	public float distanceUp;			//从目标到相机的垂直距离
	public float smooth;				//平滑跟随系数
	
	private GameObject hovercraft;		// to store the hovercraft
	private Vector3 targetPosition;		//定义一个需移动到的位置坐标
	
	Transform follow;//跟随的目标
	
	void Start(){
		follow = GameObject.FindWithTag ("Player").transform;	//给目标赋值为玩家
	}
	
	//相机跟随适合写在这个系统方法里
	void LateUpdate ()
	{
	 //目的地坐标等于玩家坐标向上的偏移量减去玩家到相机的距离  
		targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
		
		//插值移动更平滑
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		
		//始终看向目标
		transform.LookAt(follow);
	}
}