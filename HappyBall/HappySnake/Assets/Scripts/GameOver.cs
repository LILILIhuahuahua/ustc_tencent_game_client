using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject SnakeHead;
    public GameObject camare;
    public Text infoText;
    private void OnEnable()
    {
        transform.localPosition = SnakeHead.transform.localPosition;
        infoText.text = "当前等级:" + GameMaster.Instance.level + "\n" +
            "当前得分:" + GameMaster.Instance.score + "\n" +
            "当前长度:" + GameMaster.Instance.length;
    }
    public void OnBack()
    {
        SceneManager.LoadScene(0);
    }
    public void OnRetry()
    {
        SceneManager.LoadScene(1);
    }
}
