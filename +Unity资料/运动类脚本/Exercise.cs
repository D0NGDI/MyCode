using UnityEngine;
using System.Collections;

public class Exercise : MonoBehaviour {

    void Reset() { }//在用户点击检视面板的Reset按钮或者首次添加该组件时被调用。此函数只在编辑模式下被调用。Reset最常用于在检视面板中给定一个默认值。
    void Awake() { }//(一次)Awake在所有对象被初始化之后调用，用于在游戏开始之前初始化变量或游戏状态。Awake不能用来执行协同程序。每个游戏物体上的Awake以随机的顺序被调用。所以在一般时候，用Awake来设置脚本间的引用，然后用Start来传递信息。
    void OnEnable() { }//在Awake之后调用。控制脚本中组件的启动与禁用。例如：this.enable=false，则会直接跳转到OnDisable方法执行一次，其它的任何方法，将不再被执行。
    void Start () { }//(一次)Start函数总是在Awake函数之后调用。Start和Awake的不同是Start只在脚本实例被启用时调用。你可以按需调整延迟初始化代码，协调初始化顺序。
    void FixedUpdate() { }//(每帧)固定帧（固定的时间间隔，不受帧率(FPS)影响）更新，更新频率默认为0.02s。FixedUpdate比较适用于物理引擎的计算，因为是跟每帧渲染有关。
    void Update() { }//(每帧)正常帧更新，每一帧都执行，用于更新逻辑。Update比较适合做控制。如果卡帧了Update就不会再执行，而FixedUpdate则继续执行。
    void LateUpdate() { }//(每帧)在所有Update函数调用后被调用，和fixedupdate一样都是每一帧都被调用执行。LateUpdate可用于调整脚本执行顺序。
    //例如：相机跟随就可以用这个函数，即人物移动在Update中实现，相机跟随在LateUpdate()中实现，播放后的效果是：角色移动发生在前，相机移动紧跟其后。
    //（如果相机也在Update里执行，就可能出现摄像机已经推进了，但是视角里还未有角色的空帧出现。）
    void OnGUI() { }//(每帧)在渲染和处理GUI事件时调用。每帧都执行。在界面显示一个button或label时常常用到它。
    void OnDisable() { }//脚本被卸载时，OnDisable将被调用（脚本不会被销毁）。OnDisable不能用于协同程序。常用于一些用于清理的事件。
    void OnDestroy() { }//当MonoBehaviour将被销毁时，这个函数被调用。OnDestroy只会在预先已经被激活的游戏物体上被调用。OnDestroy也不能用于协同程序。
    /*函数执行顺序：
     *Awake→OnEable→ Start → FixedUpdate→Update →LateUpdate →OnGUI →Reset → OnDisable →OnDestroy
     */


}
