using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HappyBallProto;

//该脚本用来处理Notify类型的消息
public class HandleNotifyMes : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void HandNotifyMessage(Notify notifyMessage)
    {
        //optional EntityInfoChangeNotify entityInfoChangeNotify = 1; //实体的属性变化通知
        //optional GameGlobalInfoNotify gameGlobalInfoNotify = 2; //玩家加入时对玩家进行同步的所有消息
        //optional TimeNotify time = 3; //对局时间信息通知
        //optional MapInfo mapInfo = 4;
        if (notifyMessage.EntityInfoChangeNotify != null)
        {
            //执行实体信息改变（更新）函数
            HandleEntityInfoChangeNotify(notifyMessage.EntityInfoChangeNotify);
        }

        //
        //TimeNotify似乎没有编译成功
        //

        if (notifyMessage.GameGlobalInfoNotify != null)
        {
            //执行全局游戏通知函数  （进入对局时，接受所有需要渲染的数据）
            HandleGameGlobalInfoNotify(notifyMessage.GameGlobalInfoNotify);
        }
        if (notifyMessage.MapInfo!= null)
        {
            //执行处理地图信息函数
        }
       

    }

    //执行实体信息改变（更新）函数
    public static  void HandleEntityInfoChangeNotify(EntityInfoChangeNotify entityInfoChangeNotify)
    {
        //玩家信息改变了
        if (entityInfoChangeNotify.EntityType == Message.PlyerType)
        {
            Debug.Log("玩家信息改变了");
            //调用updatePlayer函数
            EntityManager.Instance.updatePlayer(entityInfoChangeNotify.PlayerMsg);
            
        }//道具的信息改变了
        else if (entityInfoChangeNotify.EntityType == Message.ItemType)
        {
            Debug.Log("道具的信息改变了");

            //1.从包中获取道具ID,道具信息
            int IteamId = entityInfoChangeNotify.EntityId;
            ItemMsg itemMsg = entityInfoChangeNotify.ItemMsg;

            //2.从字典中获取道具对象
            GameMaster.Instance.foodDictionary.TryGetValue(IteamId, out GameObject Iteam);
            Debug.Log(Iteam);

            //3.根据ItemMsg的信息，修改道具是的信息
            Iteam.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(entityInfoChangeNotify.EntityType == Message.FoodType)
        {
            Debug.Log("Food的信息改变了");
        }
        else
        {
            Debug.LogError("接受到错误的entityInfoChangeNotify的Type");
        }

    }


    //执行全局游戏通知函数  （进入对局时，接受所有需要渲染的数据）
    //或者新的玩家加入对局
    public static void HandleGameGlobalInfoNotify(GameGlobalInfoNotify  gameGlobalInfoNotify)
    {
        Debug.Log("接受到HandleGameGlobalInfoNotify的数据包");
        //1.渲染玩家
        //获得玩家个数
        //int playersNum = gameGlobalInfoNotify.PlayerNumber;

        //依次获取各个玩家信息，调用EntityManager.addPlayer方法
        foreach (PlayerMsg playerMsg in gameGlobalInfoNotify.PlayerMsg)
        {
            if (playerMsg.PlayerId != Snake.PlayerMyselfId &&playerMsg.SnakeStatus== SNAKE_STATUS.Live)
            {
                EntityManager.Instance.addPlayer(playerMsg);
            }
            else if(playerMsg.SnakeStatus == SNAKE_STATUS.Dead)
            {
                Debug.Log("gameGlobalInfoNotify.PlayerMsg中有玩家死亡，需要removePlayer");
            }
            else if (playerMsg.PlayerId == Snake.PlayerMyselfId)
            {
                Debug.LogError("gameGlobalInfoNotify.PlayerMsg中我自己不需要addPlayer");
            }
            
            
        }
        


        //2.渲染道具

    }
}
