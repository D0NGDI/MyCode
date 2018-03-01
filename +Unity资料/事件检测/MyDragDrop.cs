using UnityEngine;
using System.Collections;
//TODO NGUI的一系列鼠标拖拽事件类，必须继承自下面的 UIDragDropItem 类

public class MyDragDrop : UIDragDropItem
{
    //拖拽开始时执行的方法 todo
    //protected override void OnDragDropStart()
    //{
    //    transform.localScale = new Vector3(1.2f, 1.2f, 1);
    //}

    //拖拽松开时执行的方法 todo
    protected override void OnDragDropRelease(GameObject surface) 
    {
        base.OnDragDropRelease(surface);//这里调用父类方法必须存在 TODO

        //Debug.Log(surface);
        if (surface.tag == "Bag")
        {
            //todo 相对于父物体的坐标位置， 如果该变换没有父级，那么等同于Transform.position
            transform.localPosition = Vector3.back;//todo 这里Z轴的位置必须为负数要不然鼠标事件识别不到
        }
        else if (surface.tag == "Slot")
        {
            transform.parent = surface.transform;
            transform.localPosition = Vector3.back;//这些都表示归位到当前父物体中

        }
        else if (surface.tag  == "Goods")//TODO 如何下面有东西就进行位置交换（交换父物体并归位就相当于交换了两者的位置）
        {
            
            Transform  temp = surface.transform.parent;
            surface.transform.parent = transform.parent;
            transform.parent = temp;//这个交换已经讲过很多了，比如数组的排序
            transform.localPosition = Vector3.back;
            surface.transform.localPosition = Vector3.back;

        }
        else if (UICamera.isOverUI == true)
        {
                Debug.Log("您确定要丢弃物品吗？");
                transform.localPosition = Vector3.back;
        }
    }
}
