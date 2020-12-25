using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public Snake snake;
    private Vector3 targetDir;//蛇头移动的目标方向
    public int StartInterval = 4;//调用移动方法的间隔次数
    private int currentInterval;//当前的调用间隔
    private int countNum = 0;
    public GameOver gameOver;
    public bool isOver = false;
    [HideInInspector]
    public int level = 1;//等级
    [HideInInspector]
    public int length;//长度
    [HideInInspector]
    public int score;//分数
    public Timer timer;
    private static GameMaster _instance;
    public static GameMaster Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    void Start () {
        level = 1;
        int mode = PlayerPrefs.GetInt(Constant.Mode, 0);
        timer.timeUpAction += GameOver;
        timer.gameObject.SetActive(mode == 1);
	}
    private void FixedUpdate()
    {
        if (isOver) return;
        GetInput();
        countNum++;
        if (countNum >= currentInterval)
        {
            countNum = 0;
            Move();
        }
    }
    private void GetInput()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentInterval = StartInterval / 2;
        }
        else
        {
            currentInterval = StartInterval;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(h != 0 || v != 0)
        {
            targetDir = new Vector3(h, v, 0);
        }
    }
    public void AddScore()
    {
        score += Random.Range(1, 4);
        level = score / 100 + 1;
    }
    private void Move()
    {
        snake.CtrolMove(targetDir);
    }
    public void GameOver()
    {
        isOver = true;
        gameOver.gameObject.SetActive(true);
        AudioManager.Instance.PlayDie();
    }
}
