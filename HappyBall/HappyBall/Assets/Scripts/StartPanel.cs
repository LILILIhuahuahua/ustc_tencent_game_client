using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour {
    public Toggle blue;
    public Toggle yellow;
    public Toggle endless;
    public Toggle timer;
    public Text last;
    public Text best;
	// Use this for initialization
	void Start () {
        int skin = PlayerPrefs.GetInt(Constant.Skin, 1);
        int mode = PlayerPrefs.GetInt(Constant.Mode, 0);
        int lastLength = PlayerPrefs.GetInt(Constant.LastLength, 0);
        int lastScore = PlayerPrefs.GetInt(Constant.LastScore, 0);
        int bestLength = PlayerPrefs.GetInt(Constant.BestLength, 0);
        int bestScore = PlayerPrefs.GetInt(Constant.BestScore, 0);
        blue.isOn = skin == 0;
        yellow.isOn = skin == 1;
        endless.isOn = mode == 0;
        timer.isOn = mode == 1;
        last.text = string.Format("上次: 长度{0},分数{1}", lastLength, lastScore);
        best.text = string.Format("最高: 长度{0},分数{1}", bestLength, bestScore);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnStartBtnClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnSkinChanged(bool value)
    {
        if(blue.isOn)//蓝色
        {
            PlayerPrefs.SetInt(Constant.Skin, 0);
        }
        else if(yellow.isOn)//黄色
        {
            PlayerPrefs.SetInt(Constant.Skin, 1);
        }
    }
    public void OnModeChanged(bool value)
    {
        if(endless.isOn)//无尽模式
        {
            PlayerPrefs.SetInt(Constant.Mode, 0);
        }
        else if(timer.isOn)//计时模式
        {
            PlayerPrefs.SetInt(Constant.Mode, 1);
        }
    }
}
