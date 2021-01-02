using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    private float speed = 30f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MyselfHero")
        {
            StartCoroutine(MoveTo(collision));
        }
    }
    IEnumerator MoveTo(Collider2D target)
    {
        //记录目标位置
        Vector3 targetPos = target.transform.position;
        while(Vector3.Distance(transform.position, targetPos) > 2)
        {
            //Debug.Log("MoveTo");
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
            yield return null;
        }
        //移到目标点之后
        ReachTarget(target);
    }
    private void ReachTarget(Collider2D target)
    {
        //食物个数要减去
        FoodSpawner.Instance.foodCount--;
        //蛇头吃掉食物了
        target.gameObject.SendMessage("EatFood");
        //加分
        GameMaster.Instance.AddScore();
        //销毁食物
        Destroy(gameObject);
    }
}
