### 物体对象运动的本质
是物体对象位置的改变

### 物体的抛物线运动
* 1.
```
    // 通过直接改变position来实现
    public float v0 = 10.0f;
    public float a = 2.0f;
    private float t = 0f;

    void Update () {
        t += (float)Time.deltaTime;
        this.transform.position = new Vector3((float)(v0 * t - 0.5 * a * t * t), 0, v0*t);
    }
```
* 2.
```
    // 通过translate函数来实现
    public float v0 = 5.0f;

    void Update () {
        v0 += 0.5f;
        this.transform.Translate(v0 * Vector3.up * Time.deltaTime);
        transform.Translate(Vector3.right * Time.deltaTime); 
    }
```
* 3.
```
    // 通过设置游戏对象重力和初速度实现
    void Start () {
        this.GetComponent<Rigidbody>().velocity = new Vector3(5, 10, 0);
    }
```

### 太阳系仿真
```
    // 定义游戏对象
    public GameObject Sun;
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Moon;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;
    public GameObject Pluto;
    public float speed = 5f;

    void Update () {
        // 自转
        Sun.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Mercury.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Venus.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Earth.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Mars.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Jupiter.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Saturn.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Uranus.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Neptune.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        Pluto.transform.Rotate(Vector3.up * Time.deltaTime * 360);
        
        // 公转
        Mercury.transform.RotateAround(Sun.transform.position, Vector3.up+0.1f*Vector3.right, speed * Time.deltaTime*34);
        Venus.transform.RotateAround(Sun.transform.position, Vector3.up - 0.1f * Vector3.right, speed * Time.deltaTime*30);
        Earth.transform.RotateAround(Sun.transform.position, Vector3.up + 0.15f * Vector3.right, speed * Time.deltaTime*26);
        Mars.transform.RotateAround(Sun.transform.position, Vector3.up - 0.15f * Vector3.right, speed * Time.deltaTime*22);
        Jupiter.transform.RotateAround(Sun.transform.position, Vector3.up + 0.2f * Vector3.right, speed * Time.deltaTime*18);
        Saturn.transform.RotateAround(Sun.transform.position, Vector3.up - 0.19f * Vector3.right, speed * Time.deltaTime*14);
        Uranus.transform.RotateAround(Sun.transform.position, Vector3.up + 0.18f * Vector3.right, speed * Time.deltaTime*10);
        Neptune.transform.RotateAround(Sun.transform.position, Vector3.up - 0.16f * Vector3.right, speed * Time.deltaTime*6);
        Pluto.transform.RotateAround(Sun.transform.position, Vector3.up + 0.13f * Vector3.right, speed * Time.deltaTime*3);
    }
```