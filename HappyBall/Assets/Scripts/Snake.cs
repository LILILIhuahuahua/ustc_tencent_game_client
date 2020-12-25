using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour {
    public HeadNode head;
    public float rotateSpeed = 10;//旋转的角速度
    public float moveStep = 8;//每次前进的距离（步长）
    public GameObject bodyPrefab;//蛇身预制体
    private Sprite headSprite;//蛇头图片
    private Sprite[] bodySprites = new Sprite[2];//蛇身图片
    [HideInInspector]
    public List<BodyNode> bodies = new List<BodyNode>();
    public float moveSpeed; //移动速度
    public float bigSpeed = 0.1f;
    public float snakeV = 0f;//体积


    //public GameObject leafBg;
    void Start () {
        LoadSkin();
        head.eatAction += Grow;
        head.dieAction += Die;
	}
	
	void Update () {
		
	}
    private void LoadSkin()
    {
        int skin = PlayerPrefs.GetInt(Constant.Skin, 1);
        if(skin == 0)
        {
            headSprite = Resources.Load<Sprite>("Snake/sh01");
            bodySprites[0] = Resources.Load<Sprite>("Snake/sb0101");
            bodySprites[1] = Resources.Load<Sprite>("Snake/sb0102");
        }
        else
        {
            headSprite = Resources.Load<Sprite>("Snake/sh02");
            bodySprites[0] = Resources.Load<Sprite>("Snake/sb0201");
            bodySprites[1] = Resources.Load<Sprite>("Snake/sb0202");
        }
        head.GetComponent<Image>().sprite = headSprite;
    }
    private void Grow()
    {
        //蛇身变大
        Debug.Log("Grow()");
        head.transform.localScale += new Vector3(bigSpeed, bigSpeed, bigSpeed);

        //记录体积
        snakeV += bigSpeed;

        //移动速度变慢
        if (moveSpeed >= 10)
        {
            moveSpeed -= 0.3f;
        }
        else if (moveSpeed >= 5)
        {
            moveSpeed -= 0.2f;
        }
        else if (moveSpeed >= 1)
        {
            moveSpeed -= 0.05f;
        }

        //int index = bodies.Count % 2 == 0 ? 0 : 1;
        //GameObject go = Instantiate(bodyPrefab, transform);
        //go.GetComponent<Image>().sprite = bodySprites[index];
        //BodyNode bn = go.GetComponent<BodyNode>();
        //Vector3 initPos;
        //if(bodies.Count > 0)
        //{
        //    initPos = bodies[bodies.Count - 1].transform.localPosition;
        //}
        //else
        //{
        //    initPos = head.transform.localPosition;
        //}
        ////赋值初始位置
        //bn.InitPosList(initPos);
        //bn.transform.localPosition = initPos;
        ////层级放到最上边
        //bn.transform.SetAsFirstSibling();
        //bodies.Add(bn);
        ////增加长度
        //GameMaster.Instance.length++;

    }
    public void CtrolMove(Vector3 targetDir)
    {
        float dotF = Vector3.Dot(targetDir.normalized, head.transform.up);
        if(dotF > -1)//(-1, 1] [0, 180)度
        {
            //求出旋转要绕哪个轴
            Vector3 axis = Vector3.Cross(head.transform.up, targetDir.normalized);
            //当前方向和目标方向之间的夹角
            float angle = Vector3.Angle(head.transform.up, targetDir.normalized);
            if(angle < rotateSpeed)
            {
                head.transform.Rotate(axis, angle);
            }
            else
            {
                head.transform.Rotate(axis, rotateSpeed);
            }
        }
        else  // -1  180度
        {
            head.transform.Rotate(Vector3.back, rotateSpeed);
        }
        //前进的目标位置
        Vector3 targetPos = head.transform.localPosition + head.transform.up * moveStep;
        //leafBg.transform.localPosition += head.transform.up * moveStep;

        head.transform.localPosition = targetPos;
        //Move(targetPos);
    }
    private void Move(Vector3 targetPos)
    {
        //如果有身体，先移动身体
        if(bodies.Count > 0)
        {
            //每一节身体有几段
            int segment = bodies[0].segment;
            for (int i = bodies.Count - 1; i > 0; i--)
            {
                bodies[i].Move(bodies[i - 1].posList[segment - 1]);
            }
            bodies[0].Move(head.posList[segment - 1]);
        }
        //蛇头移动
        head.Move(targetPos);
    }
    private void Die()
    {
        //本地保存一些数据 长度、分数、等级
        PlayerPrefs.SetInt(Constant.LastLength, GameMaster.Instance.length);
        PlayerPrefs.SetInt(Constant.LastScore, GameMaster.Instance.score);

        int bestL = PlayerPrefs.GetInt(Constant.BestLength);
        int bestS = PlayerPrefs.GetInt(Constant.BestScore);
        PlayerPrefs.SetInt(Constant.BestLength, Mathf.Max(GameMaster.Instance.length, bestL));
        PlayerPrefs.SetInt(Constant.BestScore, Mathf.Max(GameMaster.Instance.score, bestS));
        //游戏结束面板
        GameMaster.Instance.GameOver();
    }
}
