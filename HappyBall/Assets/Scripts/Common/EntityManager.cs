using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HappyBallProto;

public class EntityManager : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    private static EntityManager _instance;
    public static EntityManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;

        //测试用，添加一个Player
        //addPlayer(new PlayerMsg());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void addPlayer(PlayerMsg playerMsg)
    {
        Debug.Log("正在执行addPlayer函数");
        //实例化
        GameObject player = Instantiate(playerPrefab, transform);

        //设置位置
        player.transform.localPosition = new Vector3(playerMsg.PlayerPosition.CoordinateX, playerMsg.PlayerPosition.CoordinateY, 0);

        //设置大小
        float playerLocalScale = playerMsg.PlayerSize / Message.PlayerInitRadius;
        player.transform.localScale = new Vector3(playerLocalScale, playerLocalScale, 0);


        //玩家皮肤


        //添加进Player字典中  id+GameObject
        int playerId = playerMsg.PlayerId;
        GameMaster.Instance.playerDictionary.Add(playerId, player);
    }
    public void updatePlayer(PlayerMsg playerMsg)
    {
        Debug.Log("正在执行updatePlayer函数");
        //判断玩家的状态
        //一.玩家Live
        if (playerMsg.SnakeStatus == SNAKE_STATUS.Live)
        {
            Debug.Log("玩家处于生存状态");
            //1.从包中获取玩家ID,玩家信息
            int playerId = playerMsg.PlayerId;


            //2.从字典中获取玩家对象
            GameMaster.Instance.playerDictionary.TryGetValue(playerId, out GameObject player);
            Debug.Log(player);

            //3.根据PlayerMsg的信息，修改玩家的信息
            if (playerMsg.PlayerPosition != null)
            {
                //设置位置
                player.transform.localPosition = new Vector3(playerMsg.PlayerPosition.CoordinateX, playerMsg.PlayerPosition.CoordinateY, 0);
            }
            if (playerMsg.PlayerSize != 0)
            {
                //设置大小
                float playerLocalScale = playerMsg.PlayerSize / Message.PlayerInitRadius;
                player.transform.localScale += new Vector3(playerLocalScale, playerLocalScale, 0);
            }

        }
        //2.玩家Dead
        else if (playerMsg.SnakeStatus == SNAKE_STATUS.Dead)
        {
            removePlayer(playerMsg);
            Debug.Log("玩家处于死亡状态");

        }
        //3.玩家Invincible
        else if (playerMsg.SnakeStatus == SNAKE_STATUS.Invincible)
        {
            Debug.Log("玩家处于无敌状态");
        }

    }

    public void removePlayer(PlayerMsg playerMsg)
    {
        //1.字典中移除Player
        
        GameMaster.Instance.playerDictionary.Remove(playerMsg.PlayerId);

        //2.销毁Player实体

    }


}
