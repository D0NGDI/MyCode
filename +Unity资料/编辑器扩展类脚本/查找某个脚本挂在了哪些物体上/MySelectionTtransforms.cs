//TODO 下面是一种
/*static var transforms : Transform[]
Description 描述
returns the top level selection, excluding prefabs.
返回顶层的选择物，不包括预设体。
This is the most common selection type when working with scene objects.
当工作与场景物体时，这是最常用的选择类型。*/
// C# example
// Select Objects and make them look to the main Camera by pressing 'l' //选择物体并使它们指向主摄像机通过按"l"
using UnityEngine;
using UnityEditor;
public class LookAtMainCamera : ScriptableObject
{
    [MenuItem("MyWindow/Selection looks at Main Camera _l")]
    static void Look()
    {
        Camera camera = Camera.main;
        if (camera)
        {
            foreach (Transform transform in Selection.transforms)
            {
                //todo 下面的方法记录在RecordObject函数之后对对象所做的任何更改。
                //Undo.RegisterUndo(transform,transform.name + " Looks at Main Camera");//已过时，不过还可以用
                //Undo.RecordObject(transform, transform.name );//+ " 看向主相机"
                Debug.Log(transform.name);
                transform.LookAt(camera.transform);
            }
        }
    }
    //The menu item will be disabled if nothing, is selected. //菜单项目将会失去效用，如果没有事物被选择。

    [MenuItem("MyWindow/Selection looks at Main Camera _l", true)]
    static bool ValidateSelection()
    {
        return Selection.transforms.Length != 0;
    }

}
///////=====================================

//TODO 下面是第二种
/*Selection.GetTransforms 获取变换列表
static function GetTransforms (mode : SelectionMode) : Transform[]
Description描述
Allows for fine grained control of the selection type using the SelectionMode bitmask.
允许对选择类型进行精细的控制，使用SelectionMode枚举类型。*/
// C# Example
// Creates a new parent for the selected transforms
// 为选择的变换创建一个新的父级

//using UnityEngine;
//using UnityEditor;

//public class CreateParentForTransforms : ScriptableObject
//{
//    [MenuItem("MyWindow/Create Parent For Selection _p")]
//    static void MenuInsertParent()
//    {
//        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);
//        GameObject newParent = new GameObject("Parent");

//        foreach (Transform t in selection)
//            t.parent = newParent.transform;
//    }
//    // Disable the menu if there is nothing selected
//    // 如果什么都没有选择将禁用菜单功能

//    [MenuItem("MyWindow/Create Parent For Selection _p", true)]
//    static bool ValidateSelection()
//    {
//        return Selection.activeGameObject != null;
//    }
//}