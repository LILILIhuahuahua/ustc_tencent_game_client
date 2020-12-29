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

    public static void  HandNotifyMessage(Notify notifyMessage)
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

    }

    public static  void HandleEntityInfoChangeNotify(EntityInfoChangeNotify entityInfoChangeNotify)
    {
        //玩家信息改变了
        if (entityInfoChangeNotify.EntityType == Message.PlyerType)
        {
            //1.从包中获取玩家ID
            int playerId = entityInfoChangeNotify.EntityId;
            PlayerMsg player = entityInfoChangeNotify.PlayerMsg;

            //2.从字典中获取玩家对象
            GameMaster.Instance.playerDictionary.TryGetValue(playerId, out Snake snake);
            Debug.Log("玩家信息改变了");

        }//道具的信息改变了
        else if (entityInfoChangeNotify.EntityType == Message.ItemType)
        {
            Debug.Log("道具的信息改变了");
        }
        else
        {
            Debug.LogError("接受到错误的entityInfoChangeNotify的Type");
        }

    }
}
