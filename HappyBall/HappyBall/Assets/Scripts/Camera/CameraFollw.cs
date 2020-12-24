using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollw : MonoBehaviour {

    public GameObject LeftBg;
    // Use this for initialization
    public Vector2 minPos;
    public Vector2 maxPos;
    public Camera cam;        //相机
    public Transform target;  //目标位置
    public float damping = 1f;
    // 追逐模式（与目标距离（xoy平面中）较远）下的速度
    public float chaseSpeed = 3f;
    // 与目标距离较近的速度
    public float closeToSlowlySpeed = 0.5f;
    // 判断与目标距离是否够近的依据距离
    public float shouldChaseDistance = 0.1f;

    private float m_offsetZ;
    private Vector3 m_lastTargetPosition;
    private Vector3 m_currentVelocity;
    private Vector3 m_lookAheadPos;

    private Vector2 moveDelta;
    private bool shouldChase;
    private Vector3 aheadTargetPos;
    private Vector3 newPos;
    private Vector3 offset;

    // 实际游戏中可只在游戏开始时计算1次，此处这样写的原因是确保实时修改的范围数值能即刻应用到游戏中
    private Vector2 ActualMinPos
    {
        get
        {
            return new Vector2(minPos.x + Screen.width * cam.orthographicSize / Screen.height, minPos.y + cam.orthographicSize);
        }
    }
    private Vector2 ActualMaxPos
    {
        get
        {
            return new Vector2(maxPos.x + Screen.width * cam.orthographicSize / Screen.height, maxPos.y + cam.orthographicSize);
        }
    }


    // Use this for initialization
    void Start()
    {
        offset = LeftBg.transform.position - transform.position;
        minPos = new Vector2(440,355);
        maxPos = new Vector2(635, 520);
        m_lastTargetPosition = target.position;
        m_offsetZ = (transform.position - target.position).z;
        transform.parent = null;
        if (cam == null)
            cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        moveDelta = target.position - m_lastTargetPosition;

        // 如果二者距离太远，则进入追逐模式
        shouldChase = moveDelta.magnitude > shouldChaseDistance;

        // 追逐模式(与目标距离（xoy平面中）较远)
        if (shouldChase)
        {
            m_lookAheadPos = chaseSpeed * moveDelta.normalized;
        }
        // 缓慢移动模式(与目标距离较近)
        else
        {
            // 三个参数：当前点、目标点、每次最大移动距离
            // 从 当前点 向 目标点 移动 每次最大移动距离（如果目标点和当前点的距离小于每次最大移动距离，则本次返回的点将为目标点）
            // 若每次最大移动距离为负值，则表现为远离目标点
            m_lookAheadPos = Vector3.MoveTowards(m_lookAheadPos, Vector3.zero, Time.deltaTime * closeToSlowlySpeed);
        }

        // 在z方向上，保持二者的距离不变
        // 在xoy平面中，获取到当前的目标位置（会“过头”:有动感）
        aheadTargetPos = target.position + m_lookAheadPos + Vector3.forward * m_offsetZ;

        // 将一个向量从transform.position逐渐改变为AheadTargetPos，在damping时间内到达
        // 其中m_currentVelocity为当前的速度，每一次都会发生变化,下一次的调用会用到上一次调用时得到的该速度值（因此需设置为全局变量）
        // smoothDamp与Lerp相比，smoothDamp像弧形衰减，Lerp像线性衰减
        newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_currentVelocity, damping);

        // 限制相机在指定范围内移动
        transform.position = GetCamValidPos(newPos, ActualMinPos, ActualMaxPos);
        LeftBg.transform.position  = transform.position+offset;
        m_lastTargetPosition = target.position;
    }

    // 限制相机的移动范围（矩形框内）
    private Vector3 GetCamValidPos(Vector3 targetPos, Vector2 minPos, Vector2 maxPos)
    {
        Vector3 validPos = new Vector3(Mathf.Clamp(targetPos.x, minPos.x, maxPos.x), Mathf.Clamp(targetPos.y, minPos.y, maxPos.y), targetPos.z);
        return validPos;
    }
}
