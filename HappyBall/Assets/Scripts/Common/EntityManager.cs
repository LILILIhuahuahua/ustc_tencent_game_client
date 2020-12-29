using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlayer()
    {
        //实例化
        GameObject player = Instantiate(playerPrefab, transform);

        //设置位置
        player.transform.localPosition = new Vector3(200, 200, 0);
        //设置大小

        //玩家皮肤

        //添加进Player字典中  id+GameObject



    }
}
