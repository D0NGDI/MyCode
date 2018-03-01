using UnityEngine;
using System.Collections;

public class APISummarizing : MonoBehaviour
{
    //TODO 以下是一些说明：
    //***Camera类用来控制游戏中虚拟场景的展示，以左下角为屏幕的(0,0)点坐标，以右上角为屏幕的(camera.pixelWidth，camera.pixelHeight)点坐标。如果用单位化方式表示，则左下角为(0,0)点，右上角为(1,1)点。
    GameObject a = new GameObject();
    void Start()
    {
        a.SetActive(true);
    }

    void Update()
    {
    }

    //TODO 【Application】类开始：
    //todo 数据文件路径：
    void Start_1()
    {
        //四种不同的path功能说明，都返回应用程序的数据或文件路径，都为只读
        //dataPath和streamingAssetsPath的路径位置一般是相对程序的安装目录位置，这两个属性非常适用于在多平台移植中设置要读取的外部数据文件的路径。
        //persistentDataPath和temporaryCachePath的路径位置一般是相对所在系统(平台)的固定位置(绝对路径)，适合存放程序运行过程中产生的一些数据文件。
        Debug.Log("dataPath:" + Application.dataPath); //此属性用于返回程序的数据文件所在文件夹的路径（只读）。返回路径为相对路径，
        Debug.Log("persistentDataPath:" +
                  Application.persistentDataPath); //此属性用于返回一个持久化数据存储目录的路径（只读），可以在此路径下存储一些持久化的数据文件。
        Debug.Log("streamingAssetsPath:" +
                  Application.streamingAssetsPath); //此属性用于返回流数据的缓存目录，返回路径为相对路径，适合设置一些外部数据文件的路径。
        Debug.Log("temporaryCachePath:" + Application.temporaryCachePath); //此属性用于返回一个临时数据的缓存目录（只读）。
    }

    //todo  loadedLevel属性：关卡（场景）索引
    void Start_2()
    {
        //返回当前场景的索引值
        Debug.Log("loadedLevel:" + Application.loadedLevel);
        //返回当前场景的名字
        Debug.Log("loadedLevelName:" + Application.loadedLevelName);
        //是否有场景正在被加载
        //在使用Application类的静态方法LoadLevel或LoadLevelAdditive加载一个新的场景时，
        //常常需要持续一段时间才能加载完毕，当场景加载完毕时，isLoadingLevel返回true，//否则返回false
        Debug.Log("isLoadingLevel:" + Application.isLoadingLevel);
        //返回游戏中可被加载的场景数量
        Debug.Log("levelCount:" + Application.levelCount);
        //返回当前游戏的运行平台
        //游戏的运行平台有很多种，例如手机、电脑、游戏机等，具体类型可在枚举类：RuntimePlatform中查看
        Debug.Log("platform:" + Application.platform);
        //当前游戏是否正在运行
        Debug.Log("isPlaying:" + Application.isPlaying);
        //当前游戏是否处于Unity编辑模式
        Debug.Log("isEditor:" + Application.isEditor);
    }

    //todo CaptureScreenshot方法：截屏
    //基本语法 (1) public static void CaptureScreenshot(string filename);
    //(2) public static void CaptureScreenshot(string filename, int superSize);
    //其中参数filename为截屏文件名称，superSize为放大系数，默认为0，即不放大。
    //功能说明：此方法用于截取当前游戏画面(实时截取程序屏幕)并将截取的图片保存为PNG格式。截屏后文件会默认保存在根目录下，如果根目录下已存在同名文件，将会被替换。当superSize大于1时，截屏文件的宽度和高度将同时被放大superSize倍。
    //提示：此方法在Web模式下无效。    当放大系数小于0时，按默认值0处理，即图片不放大也不缩小。
    int tp = -1;

    void Update_1()
    {
        if (tp == 0)
        {
            //默认值，不放大
            Application.CaptureScreenshot("test01.png", 0);
        }
        else if (tp == 1)
        {
            //放大系数为1，即不放大
            Application.CaptureScreenshot("test02.png", 1);
        }
        else
        {
            //放大系数为2，即放大2倍
            Application.CaptureScreenshot("test03.png", 2);
            Debug.Log("放大2倍");
        }
        tp++;
    }

    //在下面Update方法中，依次调用了3次CaptureScreenshot方法，试图生成3个不同放大系统的图片，但是在同一帧中，只有最后一次调用才能生效，故此段程序的运行结果只能生成一张PNG图片，即test03.png。
    void Update_2()
    {
        Application.CaptureScreenshot("test01.png", 0);
        Application.CaptureScreenshot("test02.png", 1);
        Application.CaptureScreenshot("test03.png", 2);
    }

    //todo LoadLevelAdditiveAsync方法：异步加载关卡
    //基本语法(1) public static AsyncOperation LoadLevelAdditiveAsync(int index); //其中参数index是被加载关卡的索引值，可以在菜单File→BuildSettings中查看关卡的索引值。
    //(2) public static AsyncOperation LoadLevelAdditiveAsync(string levelName); //其中参数levelName是被加载关卡的名字，可以在菜单File→BuildSettings中查看关卡的名字。
    //功能说明：此方法用于按照关卡名字在后台异步加载关卡到当前场景中，此方法只是将新关卡加载到当前场景，当前场景的原有内容不会被销毁。此方法仅专业版可用。
    /*
     * 代码在第15章，具体运行情况请结合第15章查看。
     */


    //TODO RegisterLogCallback 方法：注册委托 类
    //基本语法 public static void RegisterLogCallback(Application.LogCallback handler);//其中参数handler是委托方法的名字。
    //功能说明：此方法用于注册一个委托来调用日志信息。
    //提示：RegisterLogCallbackThreaded方法与此方法的功能相似，不同之处在于RegisterLogCallbackThreaded方法是在一个新的线程中调用委托。
    public class RegisterLogCallback_ts : MonoBehaviour
    {
        string output = ""; //日志输出信息
        string stack = ""; //堆栈跟踪信息
        string logType = ""; //日志类型

        int tp = 0;

        //打印日志信息
        void Update()
        {
            Debug.Log("stack:" + stack);
            Debug.Log("logType:" + logType);
            Debug.Log("tp:" + (tp++));
            Debug.Log("output:" + output);
        }

        void OnEnable()
        {
            //注册委托
            Application.RegisterLogCallback(MyCallback);
        }

        void OnDisable()
        {
            //取消委托
            Application.RegisterLogCallback(null);
        }

        //委托方法
        //方法名字可以自定义，但方法的参数类型要符合Application.LogCallback中的参数类型
        void MyCallback(string logString, string stackTrace, LogType type)
        {
            output = logString;
            stack = stackTrace;
            logType = type.ToString();
        }
    }
    //TODO 【Application】类结束。  ======================================================

    //TODO 【Camera】类开始：
    //todo aspect属性：设置摄像机视口比例
    //基本语法 public float aspect { get; set; }
    //功能说明：此属性用于获取或设置Camera视口的宽高比例值。例如，设camera.aspect=2.0f，则camera视口的宽度/高度=2.0f，但是当硬件显示器屏幕的宽度与高度比例不为2.0f时，视图的显示将会发生变形。
    //...aspect只处理摄像机Camera可以看到的视图的宽高比例，而硬件显示屏的作用只是把摄像机Camera看到的内容显示出来，当硬件显示屏的宽高比例与aspect的比例值不同时，视图将发生变形。关于此属性的更多内容请参考2.3节。
    void Start_3()
    {
        //camera.aspect的默认值即为当前硬件的aspect值
        Debug.Log("camera.aspect的默认值：" + GetComponent<Camera>().aspect);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10.0f, 10.0f, 200.0f, 45.0f), "aspect=1.0f"))
        {
            GetComponent<Camera>().ResetAspect();
            GetComponent<Camera>().aspect = 1.0f;
        }
        if (GUI.Button(new Rect(10.0f, 60.0f, 200.0f, 45.0f), "aspect=2.0f"))
        {
            GetComponent<Camera>().ResetAspect();
            GetComponent<Camera>().aspect = 2.0f;
        }
        if (GUI.Button(new Rect(10.0f, 110.0f, 200.0f, 45.0f), "aspect还原默认值"))
        {
            GetComponent<Camera>().ResetAspect();
        }
    }

    //todo cameraToWorldMatrix属性：变换矩阵
    //基本语法 public Matrix4x4 cameraToWorldMatrix { get; }
    //功能说明：此属性的功能是返回从摄像机的局部坐标系到世界坐标系的变换矩阵（只读）。
    //提示：Camera中的forward方向为其自身坐标系的-z轴方向，一般其他GameObject对象的forward方向为自身坐标系的z轴方向。
    void Start_4()
    {
        Debug.Log("Camera旋转前位置：" + transform.position);
        Matrix4x4 m = GetComponent<Camera>().cameraToWorldMatrix;
        //v3的值为沿着Camera局部坐标系的-z轴方向前移5个单位的位置在世界坐标系中的位置
        Vector3 v3 = m.MultiplyPoint(Vector3.forward * 5.0f);
        //v4的值为沿着Camera世界坐标系的-z轴方向前移5个单位的位置在世界坐标系中的位置
        Vector3 v4 = m.MultiplyPoint(transform.forward * 5.0f);
        //打印v3、v4
        Debug.Log("旋转前，v3坐标值：" + v3);
        Debug.Log("旋转前，v4坐标值：" + v4);
        transform.Rotate(Vector3.up * 90.0f);
        Debug.Log("Camera旋转后位置：" + transform.position);
        m = GetComponent<Camera>().cameraToWorldMatrix;
        //v3的值为沿着Camera局部坐标系的-z轴方向前移5个单位的位置在世界坐标系中的位置
        v3 = m.MultiplyPoint(Vector3.forward * 5.0f);
        //v3的值为沿着Camera世界坐标系的-z轴方向前移5个单位的位置在世界坐标系中的位置
        v4 = m.MultiplyPoint(transform.forward * 5.0f);
        //打印v3、v4
        Debug.Log("旋转后，v3坐标值：" + v3);
        Debug.Log("旋转后，v4坐标值：" + v4);
    }

    //todo cullingMask属性：摄像机按层渲染
    //基本语法 public int cullingMask { get; set; }
    //功能说明：此属性用于按层（即GameObject.layer）有选择性地渲染场景中的物体。通过cullingMask可以使得当前摄像机有选择性地渲染场景中的部分物体，
    //...默认cullingMask=-1即渲染场景中任何层物体，当cullingMask=0时不渲染场景中任何层。若只渲染分别位于2、3、4层的物体，则可以使用代码cullingMask=(1<<2)+ (1<<3)+ (1<<4)来实现。
    void OnGUI_1()
    {
        //默认CullingMask=-1，即渲染任何层
        if (GUI.Button(new Rect(10.0f, 10.0f, 200.0f, 45.0f), "CullingMask=-1"))
        {
            GetComponent<Camera>().cullingMask = -1;
        }
        //不渲染任何层
        if (GUI.Button(new Rect(10.0f, 60.0f, 200.0f, 45.0f), "CullingMask=0"))
        {
            GetComponent<Camera>().cullingMask = 0;
        }
        //仅渲染第0层
        if (GUI.Button(new Rect(10.0f, 110.0f, 200.0f, 45.0f), "CullingMask=1<<0"))
        {
            GetComponent<Camera>().cullingMask = 1 << 0;
        }
        //仅渲染第8层
        if (GUI.Button(new Rect(10.0f, 160.0f, 200.0f, 45.0f), "CullingMask=1<<8"))
        {
            GetComponent<Camera>().cullingMask = 1 << 8;
        }
        //渲染第8层与第0层
        if (GUI.Button(new Rect(10.0f, 210.0f, 200.0f, 45.0f), "CullingMask=0&&8"))
        {
            //注：不可大意写成camera.cullingMask = 1 << 8+1;或
            //camera.cullingMask = 1+1<<8 ;因为根据运算符优先次序其分别等价于：
            //camera.cullingMask = 1 << (8+1)和camera.cullingMask = (1+1)<<8;
            GetComponent<Camera>().cullingMask = (1 << 8) + 1;
        }
        //另外需要注意渲染多个层时的代码写法，如以上代码所示，在渲染第8层和第0层时，请勿将代码写成camera.cullingMask = 1 << 8+1或camera.cullingMask = 1+1<<8的形式。
    }

    //todo eventMask属性：按层响应事件 类
    //基本语法 public int eventMask { get; set; }
    //功能说明 此属性的功能是选择哪个层（layer）的物体可以响应鼠标事件，其使用说明如下。
    //如果要使物体响应鼠标事件必须首先满足如下两个条件。
    //第一，物体在摄像机的视野范围内。
    //第二，在2的layer次方的值与eventMask进行与运算（&）后结果为仍为2的layer次方的值，例如当前物体的层为Default ，即layer值为0 ，则2的0次方为1 ，如果1与eventMask进行与运算后结果仍为1，则此物体便会响应鼠标事件。由于当eventMask为奇数时，与1的与运算结果都为1，所以若物体的层为Default并且eventMask为奇数时物体便会响应鼠标事件。
    //如果想要多个不同层的物体都响应鼠标事件，则需要把所有层的2的layer次方值相加，再与eventMask做与运算。例如，现有两个物体，它们的layer值分别为1和3，则当eventMask与9（因为2+23=9）进行与运算后若结果仍为9，则这两个物体都会响应鼠标事件。
    //此属性有一个特殊情况，当物体的layer选择IgnoreRaycast（其为系统内置，值为2）时，无论eventMask值为多少，物体都无法响应鼠标事件。原因很简单，因为这个层的物体都忽略了射线碰撞，鼠标就探测不到物体的存在，因而也就无法响应鼠标事件了。
    //提示：此属性的计算比较消耗资源，在不使用鼠标事件时建议将值设为零。
    public class EventMask_ts : MonoBehaviour
    {
        bool is_rotate = false; //控制物体旋转

        public Camera c; //指向场景中摄像机

        //记录摄像机的eventMask值，可以在程序运行时在Inspector面板中修改其值的大小
        public int eventMask_now = -1;

        //记录当前物体的层
        int layer_now;

        int tp; //记录2的layer次方的值
        int ad; //记录与运算（&）的结果
        string str = null;

        void Update()
        {
            //记录当前对象的层，可以在程序运行时在Inspector面板中选择不同的层
            layer_now = gameObject.layer;
            //求2的layer_now次方的值
            tp = (int) Mathf.Pow(2.0f, layer_now);
            //与运算（&）
            ad = eventMask_now & tp;
            c.eventMask = eventMask_now;
            //当is_rotate为true时旋转物体
            if (is_rotate)
            {
                transform.Rotate(Vector3.up * 15.0f * Time.deltaTime);
            }
        }

        //当鼠标左键按下时，物体开始旋转
        void OnMouseDown()
        {
            is_rotate = true;
        }

        //当鼠标左键抬起时，物体结束旋转
        void OnMouseUp()
        {
            is_rotate = false;
        }

        void OnGUI()
        {
            GUI.Label(new Rect(10.0f, 10.0f, 300.0f, 45.0f), "当前对象的layer值为：" + layer_now + " , 2的layer次方的值为" + tp);
            GUI.Label(new Rect(10.0f, 60.0f, 300.0f, 45.0f), "当前摄像机eventMask的值为：" + eventMask_now);
            GUI.Label(new Rect(10.0f, 110.0f, 500.0f, 45.0f),
                "根据算法，当eventMask的值与" + tp + "进行与运算（&）后， 若结果为" + tp + "，则物体相应OnMousexxx方法，否则不响应！");

            if (ad == tp)
            {
                str = " ,所以物体会相应OnMouseXXX方法！";
            }
            else
            {
                str = " ,所以物体不会相应OnMouseXXX方法！";
            }
            GUI.Label(new Rect(10.0f, 160.0f, 500.0f, 45.0f), "而当前eventMask与" + tp + "进行与运算（&）的结果为" + ad + str);
        }

        //在运行程序后，请在脚本所在物体的Inspector面板中选择不同的layer并设置不同的eventMask参数，然后查看界面文字的说明，并用鼠标点击相应的物体，查看物体的变化状态。
    }

    //todo layerCullDistances属性：层消隐的距离 类
    //基本语法 public float[] layerCullDistances { get; set; }
    //功能说明 此属性用来设置摄像机基于层的消隐距离。摄像机可以通过基于层（GameObject.layer）的方式来设置不同层物体的消隐距离，但这个距离必须小于或等于摄像机的farClipPlane才有效。
    public class LayerCullDistances_ts : MonoBehaviour
    {
        public Transform cb1;

        void Start()
        {
            //定义大小为32的一维数组，用来存储所有层的剔除距离
            float[] distances = new float[32];
            //设置第9层的剔除距离
            distances[8] = Vector3.Distance(transform.position, cb1.position);
            //将数组赋给摄像机的layerCullDistances
            GetComponent<Camera>().layerCullDistances = distances;
        }

        void Update()
        {
            //摄像机远离物体
            transform.Translate(transform.right * Time.deltaTime);
        }

        //在使用layerCullDistances功能时，需要先对场景中各个物体所在的层进行设置，例如设置物体Cube1的层
    }

    //todo layerCullSpherical属性：基于球面距离剔除 类
    //基本语法 public bool layerCullSpherical { get; set; }
    //功能说明 此属性用于设置摄像机在基于层剔除物体时，是否采用基于球面距离的剔除方式。此属性默认值为false，即不使用球面剔除方式，此时，只要物体表面上有一点没有超出物体所在层的远视口平面，物体就是可见的。当layerCullSpherical为true时，只要物体的世界坐标点position与摄像机的距离大于所在层的剔除距离，物体就是不可见的，这和值为false时的计算方式不同。
    public class layerCullSpherical_ts : MonoBehaviour
    {
        public Transform cb1, cb2, cb3;

        void Start()
        {
            //定义大小为32的一维数组，用来存储所有层的剔除距离
            float[] distances = new float[32];
            //设置第9层的剔除距离
            distances[8] = Vector3.Distance(transform.position, cb1.position);
            //将数组赋给摄像机的layerCullDistances
            GetComponent<Camera>().layerCullDistances = distances;
            //打印出三个物体距离摄像机的距离
            Debug.Log("Cube1距离摄像机的距离：" + Vector3.Distance(transform.position, cb1.position));
            Debug.Log("Cube2距离摄像机的距离：" + Vector3.Distance(transform.position, cb2.position));
            Debug.Log("Cube3距离摄像机的距离：" + Vector3.Distance(transform.position, cb3.position));
        }

        void OnGUI()
        {
            //使用球形距离剔除
            if (GUI.Button(new Rect(10.0f, 10.0f, 180.0f, 45.0f), "use layerCullSpherical"))
            {
                GetComponent<Camera>().layerCullSpherical = true;
            }
            //取消球形距离剔除
            if (GUI.Button(new Rect(10.0f, 60.0f, 180.0f, 45.0f), "unuse layerCullSpherical"))
            {
                GetComponent<Camera>().layerCullSpherical = false;
            }
        }
    }

    //todo orthographic属性：摄像机投影模式
    //基本语法 public bool orthographic { get; set; }
    //功能说明 此属性用于获取或设置当前摄像机的投影模式，投影模式包括正交投影模式（orthographic）和透视投影模式（perspective）。若值为true则为正交投影，反之为透视投影。正交投影模式下，物体在视口中的大小只与正交视口的大小有关，与摄像机到物体的距离无关，主要用来呈现2D效果。
    //...而在透视投影模式下，物体在视口中的大小与摄像机的视口夹角（fieldofview）以及摄像机与物体的距离都有关系，有远小近大的效果，主要用来呈现3D效果。
    float len = 5.5f; //用于记录Slider的值

    void OnGUI_2()
    {
        if (GUI.Button(new Rect(10.0f, 10.0f, 120.0f, 45.0f), "正交投影"))
        {
            GetComponent<Camera>().orthographic = true;
            len = 5.5f;
        }
        if (GUI.Button(new Rect(150.0f, 10.0f, 120.0f, 45.0f), "透视投影"))
        {
            GetComponent<Camera>().orthographic = false;
            len = 60.0f;
        }
        if (GetComponent<Camera>().orthographic)
        {
            //正交投影模式下，物体没有远大近小的效果，
            //orthographicSize的大小无限制，当orthographicSize为负数时视口的内容会颠倒，
            //orthographicSize的绝对值为摄像机视口的高度值，即上下两条边之间的距离
            len = GUI.HorizontalSlider(new Rect(10.0f, 60.0f, 300.0f, 45.0f), len, -20.0f, 20.0f);
            GetComponent<Camera>().orthographicSize = len;
        }
        else
        {
            //透视投影模式下，物体有远大近小的效果，
            //fieldOfViewd的取值范围为1.0-179.0
            len = GUI.HorizontalSlider(new Rect(10.0f, 60.0f, 300.0f, 45.0f), len, 1.0f, 179.0f);
            GetComponent<Camera>().fieldOfView = len;
        }
        //实时显示len大小
        GUI.Label(new Rect(320.0f, 60.0f, 120.0f, 45.0f), len.ToString());
    }

    //todo pixelRect属性：摄像机渲染区间 类
    //基本语法 public Rect pixelRect { get; set; }
    //功能说明 此属性用于设置camera被渲染到屏幕中的坐标位置。pixelRect与属性rect功能类似，不同的是pixelRect以实际像素大小来设置显示视口的位置，而rect以单位化方式设置显示视口的位置。
    //另外，Screen.width和Screen.height为模拟硬件屏幕的宽高值，不随camera.pixelWidth和camera.pixelHeight的改变而改变。
    public class PixelRect_ts : MonoBehaviour
    {
        int which_change = -1;
        float temp_x = 0.0f, temp_y = 0.0f;

        void Update()
        {
            //Screen.width和Screen.height为模拟硬件屏幕的宽高值,
            //其返回值不随camera.pixelWidth和camera.pixelHeight的改变而改变
            Debug.Log("Screen.width:" + Screen.width);
            Debug.Log("Screen.height:" + Screen.height);
            Debug.Log("pixelWidth:" + GetComponent<Camera>().pixelWidth);
            Debug.Log("pixelHeight:" + GetComponent<Camera>().pixelHeight);
            //通过改变Camera的坐标位置而改变视口的区间
            if (which_change == 0)
            {
                if (GetComponent<Camera>().pixelWidth > 1.0f)
                {
                    temp_x += Time.deltaTime * 20.0f;
                }
                //取消以下注释察看平移状况
                //if (camera.pixelHeight > 1.0f)
                //{
                //    temp_y += Time.deltaTime * 20.0f;
                //}
                GetComponent<Camera>().pixelRect = new Rect(temp_x, temp_y, GetComponent<Camera>().pixelWidth,
                    GetComponent<Camera>().pixelHeight);
            }
            //通过改变Camera的视口宽度和高度来改变视口的区间
            else if (which_change == 1)
            {
                if (GetComponent<Camera>().pixelWidth > 1.0f)
                {
                    temp_x = GetComponent<Camera>().pixelWidth - Time.deltaTime * 20.0f;
                }
                //取消以下注释察看平移状况
                //if (camera.pixelHeight > 1.0f)
                //{
                //    temp_y = camera.pixelHeight - Time.deltaTime * 20.0f;
                //}
                GetComponent<Camera>().pixelRect = new Rect(0, 0, temp_x, temp_y);
            }
        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(10.0f, 10.0f, 200.0f, 45.0f), "视口改变方式1"))
            {
                GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                which_change = 0;
                temp_x = 0.0f;
                temp_y = 0.0f;
            }
            if (GUI.Button(new Rect(10.0f, 60.0f, 200.0f, 45.0f), "视口改变方式2"))
            {
                GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                which_change = 1;
                temp_x = 0.0f;
                temp_y = GetComponent<Camera>().pixelHeight;
            }
            if (GUI.Button(new Rect(10.0f, 110.0f, 200.0f, 45.0f), "视口还原"))
            {
                GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                which_change = -1;
            }
        }
    }

    //TODO projectionMatrix属性：自定义投影矩阵 类
    //TODO 这个案例很重要
    //基本语法 public Matrix4x4 projectionMatrix { get; set; }
    //功能说明 此属性的功能是设置摄像机的自定义投影矩阵。此属性常在一些特效场景下用到，在切换变换矩阵时通常需要先用camera.ResetProjectionMatrix() 重置camera的变换矩阵。
    public class ProjectionMatrix_ts : MonoBehaviour
    {
        public Transform sp, cb;
        public Matrix4x4 originalProjection;
        float q = 0.1f; //晃动振幅
        float p = 1.5f; //晃动频率
        int which_change = -1;

        void Start()
        {
            //记录原始投影矩阵
            originalProjection = GetComponent<Camera>().projectionMatrix;
        }

        void Update()
        {
            sp.RotateAround(cb.position, cb.up, 45.0f * Time.deltaTime); //TODO 围着……旋转 很重要
            Matrix4x4 pr = originalProjection;
            switch (which_change)
            {
                case -1:
                    break;
                case 0:
                    //绕摄像机X轴晃动
                    pr.m11 += Mathf.Sin(Time.time * p) * q;
                    break;
                case 1:
                    //绕摄像机Y轴晃动
                    pr.m01 += Mathf.Sin(Time.time * p) * q;
                    break;
                case 2:
                    //绕摄像机Z轴晃动
                    pr.m10 += Mathf.Sin(Time.time * p) * q;
                    break;
                case 3:
                    //绕摄像机左右移动
                    pr.m02 += Mathf.Sin(Time.time * p) * q;
                    break;
                case 4:
                    //摄像机视口放缩运动
                    pr.m00 += Mathf.Sin(Time.time * p) * q;
                    break;
            }
            //设置Camera的变换矩阵
            GetComponent<Camera>().projectionMatrix = pr;
        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(10.0f, 10.0f, 200.0f, 45.0f), "绕摄像机X轴晃动"))
            {
                GetComponent<Camera>()
                    .ResetProjectionMatrix(); //需要注意的是，在每次选择不同的效果之前需要调用方法ResetProjectionMatrix重置摄像机的投影矩阵。
                which_change = 0;
            }
            if (GUI.Button(new Rect(10.0f, 60.0f, 200.0f, 45.0f), "绕摄像机Y轴晃动"))
            {
                GetComponent<Camera>().ResetProjectionMatrix(); //..
                which_change = 1;
            }
            if (GUI.Button(new Rect(10.0f, 110.0f, 200.0f, 45.0f), "绕摄像机Z轴晃动"))
            {
                GetComponent<Camera>().ResetProjectionMatrix(); //..
                which_change = 2;
            }
            if (GUI.Button(new Rect(10.0f, 160.0f, 200.0f, 45.0f), "绕摄像机左右移动"))
            {
                GetComponent<Camera>().ResetProjectionMatrix(); //..
                which_change = 3;
            }
            if (GUI.Button(new Rect(10.0f, 210.0f, 200.0f, 45.0f), "视口放缩运动"))
            {
                GetComponent<Camera>().ResetProjectionMatrix();
                which_change = 4;
            }
        }
    }

    //todo rect属性：摄像机视图的位置和大小
    //基本语法 public Rect rect { get; set; }
    //功能说明 此属性使用单位化坐标系的方式来设置当前摄像机的视图位置和大小。
    public class Rect_ts : MonoBehaviour
    {
        int which_change = -1;
        float temp_x = 0.0f, temp_y = 0.0f;

        void Update()
        {
            //视口平移
            if (which_change == 0)
            {
                if (GetComponent<Camera>().rect.x < 1.0f)
                {
                    //沿着X轴平移
                    temp_x = GetComponent<Camera>().rect.x + Time.deltaTime * 0.2f;
                }
                //取消下面注释察看平移的变化
                //if (camera.rect.y< 1.0f)
                //{
                //沿着Y轴平移
                //    temp_y = camera.rect.y + Time.deltaTime * 0.2f;
                //}
                GetComponent<Camera>().rect = new Rect(temp_x, temp_y, GetComponent<Camera>().rect.width,
                    GetComponent<Camera>().rect.height);
            }
            //视口放缩
            else if (which_change == 1)
            {
                if (GetComponent<Camera>().rect.width > 0.0f)
                {
                    //沿着X轴放缩
                    temp_x = GetComponent<Camera>().rect.width - Time.deltaTime * 0.2f;
                }
                if (GetComponent<Camera>().rect.height > 0.0f)
                {
                    //沿着Y轴放缩
                    temp_y = GetComponent<Camera>().rect.height - Time.deltaTime * 0.2f;
                }
                GetComponent<Camera>().rect = new Rect(GetComponent<Camera>().rect.x, GetComponent<Camera>().rect.y,
                    temp_x, temp_y);
            }
        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(10.0f, 10.0f, 200.0f, 45.0f), "视口平移"))
            {
                //重置视口
                GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                which_change = 0;
                temp_y = 0.0f;
            }
            if (GUI.Button(new Rect(10.0f, 60.0f, 200.0f, 45.0f), "视口放缩"))
            {
                GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                which_change = 1;
            }
            if (GUI.Button(new Rect(10.0f, 110.0f, 200.0f, 45.0f), "视口还原"))
            {
                GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                which_change = -1;
            }
        }
    }

    //todo renderingPath属性：渲染路径
    //基本语法 public RenderingPath renderingPath { get; set; }
    //功能说明：此属性用于获取或设置摄像机的渲染路径。Unity中渲染路径RenderingPath为枚举类型，共有以下4种设置方式。
    //UsePlayerSettings：使用工程中的设置，即Edit→ProjectSettings→Player中各个平台下的设置，
    //VertexLit：使用顶点光照，最低消耗的渲染路径，不支持实时阴影，适用于移动及老式设备。
    //Forward：使用正向光照，基于着色器的渲染路径，支持逐像素计算光照（包括法线贴图和灯光Cookies）和来自一个平行光的实时阴影，具体请参考官方文档。
    //DeferredLighting：使用延迟光照，支持实时阴影，计算消耗大，对硬件要求高，不支持移动设备，仅专业版可用。
    void OnGUI_3()
    {
        if (GUI.Button(new Rect(10.0f, 10.0f, 120.0f, 45.0f), "UsePlayerSettings"))
        {
            GetComponent<Camera>().renderingPath = RenderingPath.UsePlayerSettings;
        }
        if (GUI.Button(new Rect(10.0f, 60.0f, 120.0f, 45.0f), "VertexLit"))
        {
            GetComponent<Camera>().renderingPath = RenderingPath.VertexLit;
        }
        if (GUI.Button(new Rect(10.0f, 110.0f, 120.0f, 45.0f), "Forward"))
        {
            GetComponent<Camera>().renderingPath = RenderingPath.Forward;
        }
        if (GUI.Button(new Rect(10.0f, 160.0f, 120.0f, 45.0f), "DeferredLighting"))
        {
            GetComponent<Camera>().renderingPath = RenderingPath.DeferredLighting;
        }
    }

    //todo targetTexture属性：目标渲染纹理 很重要
    //基本语法 public RenderTexture targetTexture { get; set; }
    //功能说明 调用Camera此属性可以生成目标渲染纹理，仅专业版可用。此属性的作用是可以把某个摄像机A的视图作为RendererTexture，然后添加到一个Material对象形成一个新的material，再把这个material赋给一个GameObject对象的Renderer组件，
    //...便可以在这个GameObject中实时地看到摄像机A中的视图，此属性可以用来做一些实时跟踪类的功能。
    //todo 这个是画中画的效果，需要看本书Camera类图2-9 targetTexture设置示意图01和02进行设置

    //todo worldToCameraMatrix属性：变换矩阵
    //基本语法 public Matrix4x4 worldToCameraMatrix { get; set; }
    //功能说明 此属性的功能是返回或设置从世界坐标系到当前Camera自身坐标系的变换矩阵。当用camera.worldToCameraMatrix重设摄像机的转换矩阵时，摄像机对应的Transform组件数据不会同步更新，如果想回到Transform的可控状态，需要调用ResetWorldToCameraMatrix方法重置摄像机的转换矩阵。
    public Camera c_test;

    void OnGUI_4()
    {
        if (GUI.Button(new Rect(10.0f, 10.0f, 200.0f, 45.0f), "更改变换矩阵"))
        {
            //使用c_test的变换矩阵
            GetComponent<Camera>().worldToCameraMatrix = c_test.worldToCameraMatrix;
            //也可使用如下代码实现同样功能
            // camera.CopyFrom(c_test);
        }
        if (GUI.Button(new Rect(10.0f, 60.0f, 200.0f, 45.0f), "重置变换矩阵"))
        {
            GetComponent<Camera>().ResetWorldToCameraMatrix();
        }
    }

    //todo RenderToCubemap方法：生成Cubemap静态贴图
    //基本语法(1) public bool RenderToCubemap(Cubemap cubemap);//其中参数cubemap为Cubemap静态贴图。
    //(2) public bool RenderToCubemap(RenderTexture cubemap);//其中参数cubemap为RenderTexture静态贴图。
    //(3) public bool RenderToCubemap(Cubemap cubemap, int faceMask);//其中参数cubemap为Cubemap静态贴图，faceMask 为反射面数量，默认值为63。
    //(4) public bool RenderToCubemap(RenderTexture cubemap, int faceMask); //其中参数cubemap为RenderTexture静态贴图，faceMask为反射面数量，默认值为63。
    //功能说明：此方法的作用是使用摄像机生成一个Cubemap静态贴图。当faceMask值为63时，表示Cubemap的上下左右前后6个面全部反射，这种情况下系统计算耗费也最大。该值是一个二进制计算的参数，默认值为63即111111，表示6个面全开，如果不需要全部反射，则需要修改faceMask的值。

    //todo RenderWithShader方法：使用其他shader渲染
    //基本语法 public void RenderWithShader(Shader shader, string replacementTag);//其中参数shader为要使用的shader，replacementTag 为shader的Tag标示。
    //功能说明：此方法的作用是可以使用指定的shader来代替当前物体的shader渲染一帧。当replacementTag为空时会替换视口中所有物体的shader。
    //提示：SetReplacementShader方法与此方法功能相近，不同之处是，SetReplacementShader方法使用指定的shader来替换物体当前的shader，被替换后每一帧都会用替换的shader来渲染物体，而不是只渲染一帧，具体请查看实例演示。
    bool is_use = false;

    void OnGUI_5()
    {
        if (is_use)
        {
            //使用高光shader：Specular来渲染Camera
            GetComponent<Camera>().RenderWithShader(Shader.Find("Specular"), "RenderType");
        }
        if (GUI.Button(new Rect(10.0f, 10.0f, 300.0f, 45.0f), "使用RenderWithShader启用高光"))
        {
            //RenderWithShader每调用一次只渲染一帧，所以不可将其直接放到这儿
            //camera.RenderWithShader(Shader.Find("Specular"), "RenderType");
            is_use = true;
        }
        if (GUI.Button(new Rect(10.0f, 60.0f, 300.0f, 45.0f), "使用SetReplacementShader启用高光"))
        {
            //SetReplacementShader方法用来替换已有shader，调用一次即可
            GetComponent<Camera>().SetReplacementShader(Shader.Find("Specular"), "RenderType");
            is_use = false;
        }
        if (GUI.Button(new Rect(10.0f, 110.0f, 300.0f, 45.0f), "关闭高光"))
        {
            GetComponent<Camera>().ResetReplacementShader();
            is_use = false;
        }
        //提示：方法RenderWithShader每调用一次只渲染一帧，故不可直接将其放到GUI的Button中，否则看不出效果。
    }

    //TODO ScreenPointToRay方法：近视口到屏幕的射线 重要
    //基本语法 public Ray ScreenPointToRay(Vector3 position); //其中参数position为屏幕位置参考点。
    //功能说明 此方法的作用是可以从Camera的近视口nearClip向前发射一条射线到屏幕上的position点。参考点position用实际像素值的方式来决定Ray到屏幕的位置。
    //...参考点position的x轴分量或y轴分量从0增长到最大值时，Ray从屏幕一边移动到另一边。当Ray未能碰撞到物体时，hit.point返回值为Vector3(0,0,0)。参考点position的z轴分量值无效。
    Ray ray;

    RaycastHit hit;
    Vector3 v3 = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);
    Vector3 hitpoint = Vector3.zero;

    void Update_3()
    {
        //射线沿着屏幕X轴从左向右循环扫描
        v3.x = v3.x >= Screen.width ? 0.0f : v3.x + 1.0f;
        //生成射线
        ray = GetComponent<Camera>().ScreenPointToRay(v3);
        if (Physics.Raycast(ray, out hit, 100.0f)) //100米的范围
        {
            //绘制线，在Scene视图中可见
            Debug.DrawLine(ray.origin, hit.point, Color.green); //让射线看得见(Scene中)很重要
            //输出射线探测到的物体的名称
            Debug.Log("射线探测到的物体名称：" + hit.transform.name);
        }
    }

    //TODO ScreenToViewportPoint方法（屏幕与视口互相转换）：坐标系转换  重要
    //基本语法 public Vector3 ScreenToViewportPoint(Vector3 position);//其中参数position为屏幕参考点。
    //功能说明：此方法的功能是实现坐标点position从屏幕坐标系向摄像机视口的单位化坐标系转换。参考点position的x和y分量为屏幕的实际坐标值，单位为像素，z值无效。
    void Start_5()
    {
        transform.position = new Vector3(0.0f, 0.0f, 1.0f);
        transform.rotation = Quaternion.identity;
        //从屏幕的实际坐标点向视口的单位化比例值转换 todo
        Debug.Log("1:" + GetComponent<Camera>()
                      .ScreenToViewportPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 100.0f)));
        //从视口的单位化比例值向屏幕的实际坐标点转换 todo
        Debug.Log("2:" + GetComponent<Camera>().ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 100.0f)));
        Debug.Log("屏幕宽：" + Screen.width + "  屏幕高：" + Screen.height);
    }

    //TODO ScreenToWorldPoint方法：坐标系转换 重要
    //基本语法 public Vector3 ScreenToWorldPoint(Vector3 position);//其中参数position为屏幕参考点。
    //功能说明 此方法的作用是将参考点position从屏幕坐标系转换到世界坐标系。此方法与方法ViewportToWorldPoint功能类似，只是此方法的参考点position中各个分量值都为实际单位像素值，而非比例值。
    void Start_6()
    {
        transform.position = new Vector3(0.0f, 0.0f, 1.0f);
        GetComponent<Camera>().fieldOfView = 60.0f;
        GetComponent<Camera>().aspect = 16.0f / 10.0f;
        //Z轴前方100处对应的屏幕的左下角的世界坐标值
        Debug.Log("1:" + GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 100.0f)));
        //Z轴前方100处对应的屏幕的中间的世界坐标值
        Debug.Log("2:" + GetComponent<Camera>()
                      .ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 100.0f)));
        //Z轴前方100处对应的屏幕的右上角的世界坐标值
        Debug.Log("3:" + GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 100.0f)));
    }

    //todo SetTargetBuffers方法：重设摄像机到TargetTexture的渲染
    //基本语法(1) public void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depth Buffer); 其中参数colorBuffer为纹理的颜色缓存，depthBuffer为纹理的深度缓存。
    //(2)publicvoidSetTargetBuffers(RenderBuffer[] colorBuffer, RenderBufferdepthBuffer); 其中参数colorBuffer为纹理的颜色缓存，depthBuffer为纹理的深度缓存。此重载方法可以将摄像机的渲染一次赋给多个colorBuffer。
    //功能说明：此方法用于将Camera的渲染赋给RenderTexture的colorBuffer和depthBuffer。
    //声明两个RendererTexture变量
    public RenderTexture RT_1, RT_2;

    public Camera c; //指定Camera

    void OnGUI_6()
    {
        //设置RT_1的buffer为摄像机c的渲染
        if (GUI.Button(new Rect(10.0f, 10.0f, 180.0f, 45.0f), "set target buffers"))
        {
            c.SetTargetBuffers(RT_1.colorBuffer, RT_1.depthBuffer);
        }
        //设置RT_2的buffer为摄像机c的渲染，此时RT_1的buffer变为场景中Camera1的渲染
        if (GUI.Button(new Rect(10.0f, 60.0f, 180.0f, 45.0f), "Reset target buffers"))
        {
            c.SetTargetBuffers(RT_2.colorBuffer, RT_2.depthBuffer);
        }
    }

    //todo ViewportPointToRay方法：近视口到屏幕的射线
    //基本语法 public Ray ViewportPointToRay(Vector3 position);//其中参数position为单位化坐标中的参考点。
    //功能说明：此方法的作用是可以从Camera的近视口nearClip向前发射一条射线到屏幕上的position点。参考点position用单位化比例值的方式来决定Ray到屏幕的位置。参考点position的x轴分量或y轴分量从0到1增长时，Ray从屏幕一边移动到另一边。当Ray未能碰撞到物体时，hit.point的返回值为Vector3(0,0,0)。参考点position的z轴分量值无效。
    public class ViewportPointToRay_ts : MonoBehaviour
    {
        Ray ray; //射线
        RaycastHit hit;
        Vector3 v3 = new Vector3(0.5f, 0.5f, 0.0f); //用于记录射线到屏幕上的视口比例位置
        Vector3 hitpoint = Vector3.zero;

        void Update()
        {
            //射线沿着屏幕X轴从左向右循环扫描
            v3.x = v3.x >= 1.0f ? 0.0f : v3.x + 0.002f;
            //生成射线
            ray = GetComponent<Camera>().ViewportPointToRay(v3);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //绘制线，在Scene视图中可见
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                //输出射线探测到的物体的名称
                Debug.Log("射线探测到的物体名称：" + hit.transform.name);
            }
        }
    }

    //todo ViewportToWorldPoint方法：坐标点的坐标系转换
    //基本语法 public Vector3 ViewportToWorldPoint(Vector3 position); //其中参数position为待转换的参考点。
    //功能说明：此方法的功能是实现从Camera视口坐标点向世界坐标点转换，这与方法WorldToView-portPoint的功能正好相反。此方法的返回值大小受当前Camera在世界坐标系中的位置Camera的fieldOfView值以及参考点position的共同影响。
    //...其中参考点position的x和y分量的有效范围为[0.0,1.0]，为比例值；而z值为实际单位值，非比例值。
    void Start_7()
    {
        transform.position = new Vector3(1.0f, 0.0f, 1.0f);
        GetComponent<Camera>().fieldOfView = 60.0f;
        GetComponent<Camera>().aspect = 16.0f / 10.0f;
        //屏幕左下角
        Debug.Log("1:" + GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 100.0f)));
        //屏幕中间
        Debug.Log("2:" + GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 100.0f)));
        //屏幕右上角
        Debug.Log("3:" + GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1.0f, 1.0f, 100.0f)));
    }

    //TODO WorldToScreenPoint方法：坐标点的坐标系转换 类 很重要
    //基本语法 public Vector3 WorldToScreenPoint(Vector3 position); //其中参数position为待转换的世界坐标系中的坐标点。
    //功能说明：此方法用来实现从世界坐标点向屏幕坐标点转换，即坐标点position投射到屏幕上的坐标值。返回值的x和y分量是以屏幕左下角为(0,0)点，以向上为y轴、向右为x轴来计算的。
    public class WorldToScreenPoint_ts : MonoBehaviour
    {
        public Transform cb, sp;
        public Texture2D t2;
        Vector3 v3 = Vector3.zero;
        float sg;

        void Start()
        {
            //记录屏幕高度
            sg = Screen.height;
        }

        void Update()
        {
            //sp绕着cb的Y轴旋转
            sp.RotateAround(cb.position, cb.up, 30.0f * Time.deltaTime);
            //获取sp在屏幕上的坐标点
            v3 = GetComponent<Camera>().WorldToScreenPoint(sp.position);
        }

        void OnGUI()
        {
            //绘制纹理
            GUI.DrawTexture(new Rect(0.0f, sg - v3.y, v3.x, sg), t2);
        }
    }

    //todo WorldToViewportPoint方法：坐标点的坐标系转换 重要
    //基本语法 public Vector3 WorldToViewportPoint(Vector3 position);//其中参数position 为待转换的世界坐标系中的坐标点。
    //功能说明：此方法的功能是把三维坐标点position从世界坐标系转换到屏幕的单位化坐标系中，即世界坐标点position投射到屏幕上的坐标点的x、y分量所占屏幕宽高的比例大小。此方法与方法WorldToScreenPoint功能类似，不同的是其返回值的x和y分量是比例值，以屏幕的总宽度和总高度分别为x和y分量的最大值1。返回值的x和y分量是以屏幕左下角为(0,0)点，以向上为y轴、向右为x轴来计算的。
    public class WorldToViewportPoint_ts : MonoBehaviour
    {
        public Transform cb, sp;
        public Texture2D t2;
        Vector3 v3 = Vector3.zero;
        float sw, sh;//sw和sh用来记录屏幕的宽度和高度
        void Start()
        {
            //记录屏幕的宽度和高度
            sw = Screen.width;
            sh = Screen.height;
        }
        void Update()
        {
            //物体sp始终绕cb的Y轴旋转
            sp.RotateAround(cb.position, cb.up, 30.0f * Time.deltaTime);
            //记录sp映射到屏幕上的比例值
            v3 = GetComponent<Camera>().WorldToViewportPoint(sp.position);
        }
        void OnGUI()
        {
            //绘制纹理，由于方法WorldToViewportPoint的返回值的y分量是从屏幕下方向上方递增的，
            //所以需要先计算1.0f - v3.y的值，然后再和sh相乘。
            GUI.DrawTexture(new Rect(0.0f, sh * (1.0f - v3.y), sw * v3.x, sh), t2);
        }
    }

}
