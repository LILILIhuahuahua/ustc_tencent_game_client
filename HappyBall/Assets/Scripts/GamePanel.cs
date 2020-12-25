using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour {
    public Text lvText;
    public Text lengthText;
    public Text scoreText;
	void Start () {
		
	}
	
	void Update () {
        UpdateUI();
	}
    private void UpdateUI()
    {
        lvText.text = GameMaster.Instance.level.ToString();
        lengthText.text = GameMaster.Instance.length.ToString();
        scoreText.text = GameMaster.Instance.score.ToString();
    }
    public void OnHomeClicked()
    {
        SceneManager.LoadScene(0);
    }
}
