using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeadNode : Node {
    public int growCount = 2;//吃几个食物增长一节
    private int eatCount = 0;
    public Action eatAction;
    public Action dieAction;
	public void EatFood()
    {
        AudioManager.Instance.PlayEat();
        eatCount++;
        if(eatCount == growCount)
        {
            eatCount = 0;
            if (eatAction != null)
            {
                eatAction.Invoke();
            }
            else
            {
                Debug.LogError("找不到eatAction");
            }
        }
    }
    public void Die()
    {
        if (dieAction != null) dieAction.Invoke();
    }
}
