using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TODO 血条显示和功能类

//TODO 这里实现的是用UGUI按钮做的血条
public class XueTiao : MonoBehaviour
{
		//这上面的字段只是定义
    public GameObject text;//显示血量的文本对象
    public RectTransform xuetiao;//血条背景，这里直接用场景物体上的组件进行定义让这个对象可以直接设置物体的长宽高等属性 TODO
    public GameObject xuetiao1;//血条对象
    //Vector2 vec2 ;
    float HP ;//当前血量
    float zHP = 300f;//最大血量
    float xtWidth;//血条背景对象的宽度
    float xt1Width;//血条对象的宽度



    void Start()
    {
        HP = 300f;
        //一开始的初始化将血条，血条背景与血量文本的显示都隐藏掉
        xuetiao.GetComponent<Image>().enabled = false;
        text.GetComponent<Text>().enabled = false;
        xuetiao1.GetComponent<Image>().enabled = false;

				//给血条背景宽度赋值
        xtWidth = xuetiao.rect.width;
       
        
    }
   
    void Update()
    {
    		//赋值血条的宽度
        xt1Width = xuetiao1.GetComponent<RectTransform>().rect.width;
        //算出当前血量(血条宽度)与最大血量(血条背景宽度)的比例并加以百分比赋值给血量文本
        text.GetComponent<Text>().text=(xt1Width / xtWidth*100).ToString("f0")+"%" ;
        //按下空格随机减血
        if (Input.GetKeyDown("space"))
        {
            HP -= Random.Range(8,18);
            
        }
        //TODO 根据当前血量动态改变血条宽度
        xuetiao1. GetComponent<RectTransform>().sizeDelta = new Vector2(xtWidth*HP/zHP, 30f);
        //todo 下面是将世界坐标转换为屏幕坐标
        //vec2 = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        //xuetiao.anchoredPosition = new Vector2(vec2.x - Screen.width / 2 + 0f, vec2.y - Screen.height / 2 + 60f);
        //血量<=10就销毁当前对象
        if (HP <= 0)
            Destroy(gameObject);
    }
		
		//鼠标移到对象上时(每帧持续检测)
    private void OnMouseOver()
    {
				//就显示血条和血量数字
        xuetiao.GetComponent<Image>().enabled = true;
        text.GetComponent<Text>().enabled = true;
        xuetiao1.GetComponent<Image>().enabled = true;

    }
		
		//当鼠标移出对象区域时
    private void OnMouseExit()
    {
    		//就隐藏血条和血量数字
        xuetiao.GetComponent<Image>().enabled = false;
        text.GetComponent<Text>().enabled = false;
        xuetiao1.GetComponent<Image>().enabled = false;
    }
}