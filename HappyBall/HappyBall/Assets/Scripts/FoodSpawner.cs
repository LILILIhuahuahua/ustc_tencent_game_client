using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSpawner : MonoBehaviour {
    public GameObject foodPrefab;
    private int xMin = -499;
    private int xMax = 955;
    private int yMin = -740;
    private int yMax = 701;
    private int MaxCount = 200;//最大个数显示
    public int foodCount = 0;

    private static FoodSpawner _instance;
    public static FoodSpawner Instance
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
        InvokeRepeating("SpawnFood", 0.2f, 2.5f);
	}
	
	void Update () {
        if (GameMaster.Instance.isOver) CancelInvoke();
	}
    public void SpawnFood()
    {
        //食物最大个数限制
        if (foodCount >= MaxCount) return;
        //随机个数
        int num = Random.Range(0, 6);
        for (int i = 0; i < num; i++)
        {
            GameObject food = Instantiate(foodPrefab, transform);
            //随机颜色
            Image img = food.GetComponent<Image>();
            //img.color = Random.ColorHSV();
            int r = Random.Range(60, 255);
            int g = Random.Range(60, 255);
            int b = Random.Range(60, 255);
            img.color = new Color(r / 255f, g / 255f, b / 255f, 200 / 255f);
            //随机位置
            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);
            food.transform.localPosition = new Vector3(x, y, 0);
        }
        foodCount += num;
    }
}
