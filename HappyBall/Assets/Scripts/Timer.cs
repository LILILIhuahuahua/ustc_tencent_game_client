using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {
    public float time = 60;//以秒为单位
    public Text timerShow;
    public Action timeUpAction;
	void Start () {
		
	}
	
	void Update () {
        if (GameMaster.Instance.isOver) return;
        time -= Time.deltaTime;
        ShowTime();
        if(Mathf.Abs(time) < 0.1f)
        {
            if (timeUpAction != null) timeUpAction.Invoke();
        }
	}
    private void ShowTime()
    {
        int h = (int)time / 3600;
        int m = (int)time % 3600 / 60;
        int s = (int)time % 3600 % 60;
        timerShow.text = string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
    }
}
