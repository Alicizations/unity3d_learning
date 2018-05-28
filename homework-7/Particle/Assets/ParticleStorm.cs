using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePosition
{
    public float radius;
    public float angle;
    public float time;
    public float height;

    public ParticlePosition(float radius, float angle, float time, float height)
    {
        this.radius = radius;   // 半径  
        this.angle = angle;     // 角度  
        this.time = time;       // 时间
        this.height = height;   // height
    }
}

public class ParticleStorm : MonoBehaviour {

    private ParticleSystem particleSys;           // 粒子系统 
    private ParticleSystem.MainModule main;
    private ParticleSystem.Particle[] Particles;  // 粒子数组  
    private ParticlePosition[] Positions;         // 位置数组

    // some control parameter
    public int count = 10000;       // 粒子数量
    public float size = 0.25f;      // 粒子大小
    public float minRadius = 3f;  // 最小半径
    public float maxRadius = 10f; // 最大半径
    public float heightRate = 5f;    // 高度比例
    public bool clockwise = true;   // 顺时针|逆时针
    public float speed = 100f;        // 速度
    public float pingPong = 0.09f;  // 游离范围
    public float minOut = -1f;
    public float maxOut = 2.5f;

    // Use this for initialization
    void Start ()
    {
        // 初始化粒子数组  
        this.Particles = new ParticleSystem.Particle[count];
        this.Positions = new ParticlePosition[count];

        

        // 初始化粒子系统  
        particleSys = this.GetComponent<ParticleSystem>();
        this.main = particleSys.main;
        this.main.startSpeed = 0;          // 粒子初始速度为0, 靠程序移动位置
        this.main.startSize = size;        // 设置粒子大小
        this.main.loop = false;
        this.main.maxParticles = count;    // 设置最大粒子量
        particleSys.Emit(count);           // 发射粒子
        particleSys.GetParticles(Particles);

        RandomlySpread();                  // 初始化各粒子位置
    }

    // Update is called once per frame
    private int tier = 50;  // 速度差分层数  
    void Update()
    {
        for (int i = 0; i < count; i++)
        {
            // 粒子在半径方向上游离  
            Positions[i].time += Time.deltaTime;
            Positions[i].radius += Mathf.PingPong(Positions[i].time / minRadius / maxRadius, pingPong) - pingPong / 2.0f;

            if (clockwise)  // 顺时针旋转  
                Positions[i].angle -= (i % tier + 1) * (speed / Positions[i].radius / tier);
            else            // 逆时针旋转  
                Positions[i].angle += (i % tier + 1) * (speed / Positions[i].radius / tier);

            // 保证angle在0~360度  
            Positions[i].angle = (360.0f + Positions[i].angle) % 360.0f;
            float theta = Positions[i].angle / 180 * Mathf.PI;

            Particles[i].position = new Vector3(Positions[i].radius * Mathf.Cos(theta), Positions[i].height, Positions[i].radius * Mathf.Sin(theta));
        }

        particleSys.SetParticles(Particles, Particles.Length);
    }

    void RandomlySpread()
    {
        for (int i = 0; i < count; ++i)
        {   
            // 随机每个粒子位置, 水平均匀分布
            float radius = Random.Range(minRadius, maxRadius);
            float height = radius * heightRate;
            radius += Random.Range(minOut, maxOut);

            // 随机每个粒子的角度  
            float angle = Random.Range(0.0f, 360.0f);
            float theta = angle / 180 * Mathf.PI;

            // 随机每个粒子的游离起始时间  
            float time = Random.Range(0.0f, 360.0f);

            //Positions[i] = new ParticlePosition(radius, angle, time, height);
            Positions[i] = new ParticlePosition(radius, angle, time, height);

            Particles[i].position = new Vector3(Positions[i].radius * Mathf.Cos(theta), Positions[i].height, Positions[i].radius * Mathf.Sin(theta));
        }

        particleSys.SetParticles(Particles, Particles.Length);
    }
}
