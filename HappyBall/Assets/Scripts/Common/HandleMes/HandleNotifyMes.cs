using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        Debug.Log("正在执行HandNotifyMessage函数");
        if (notifyMessage.GameGlobalInfoNotify != null)
        {
            //执行全局游戏通知函数  （进入对局时，接受所有需要渲染的数据）
            HandleGameGlobalInfoNotify(notifyMessage.GameGlobalInfoNotify);
        }
        if (notifyMessage.EntityInfoChangeNotify != null)
        {
            //执行实体信息改变（更新）函数
            HandleEntityInfoChangeNotify(notifyMessage.EntityInfoChangeNotify);
        }
        if(notifyMessage.Time != null)
        {
            //执行时间相关函数
        }
        if (notifyMessage.MapInfo!= null)
        {
            //执行处理地图信息函数
        }
       

    }

    //执行实体信息改变（更新）函数
    public static  void HandleEntityInfoChangeNotify(EntityInfoChangeNotify entityInfoChangeNotify)
    {
        Debug.Log("正在执行HandleEntityInfoChangeNotify函数");

        //Hero信息改变了
        if (entityInfoChangeNotify.EntityType == ENTITY_TYPE.HeroType)
        {
            Debug.Log("玩家信息改变了");
            //调用updatePlayer函数
            HeroManager.Instance.updateHero(entityInfoChangeNotify.HeroMsg);
            
        }//道具的信息改变了
        else if (entityInfoChangeNotify.EntityType == ENTITY_TYPE.FoodType)
        {
            Debug.Log("Food的信息改变了");

            //1.从包中获取Food的ID,Food信息
            int IteamId = entityInfoChangeNotify.EntityId;
            ItemMsg itemMsg = entityInfoChangeNotify.ItemMsg;

            //2.从字典中获取Food对象
            GameMaster.Instance.foodDictionary.TryGetValue(IteamId, out GameObject Iteam);
            Debug.Log(Iteam);

            //3.根据ItemMsg的信息，修改Food的信息
            Iteam.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(entityInfoChangeNotify.EntityType == ENTITY_TYPE.PropType)
        {
            Debug.Log("道具信息改变了");
            //1.从包中获取道具的ID,道具信息
            int IteamId = entityInfoChangeNotify.EntityId;
            ItemMsg itemMsg = entityInfoChangeNotify.ItemMsg;

            //2.从字典中获取道具对象
            GameMaster.Instance.foodDictionary.TryGetValue(IteamId, out GameObject Iteam);
            Debug.Log(Iteam);

            //3.根据ItemMsg的信息，修改道具的信息
            Iteam.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Debug.LogError("接受到错误的entityInfoChangeNotify的Type");
        }

    }


    //执行全局游戏通知函数  （进入对局时，接受所有需要渲染的数据）
    //或者新的Hero加入对局
    public static void HandleGameGlobalInfoNotify(GameGlobalInfoNotify  gameGlobalInfoNotify)
    {
        Debug.Log("正在HandleGameGlobalInfoNotify函数");
        //1.渲染玩家
        //依次获取各个玩家信息，调用EntityManager.addPlayer方法
        foreach (HeroMsg heroMsg in gameGlobalInfoNotify.HeroMsg)
        {
            if (heroMsg.HeroId != Snake.HeroMyselfId )
            {
                //判断Hero状态
                if(heroMsg.HeroStatus == HERO_STATUS.Live)
                {
                    Debug.Log("正在HandleGameGlobalInfoNotify函数中addHero");
                    HeroManager.Instance.addHero(heroMsg);
                }
                else if (heroMsg.HeroStatus == HERO_STATUS.Dead)
                {
                    Debug.Log("gameGlobalInfoNotify.heroMsg中有玩家死亡，需要removeHero");
                    HeroManager.Instance.removeHero(heroMsg);
                }
                else if (heroMsg.HeroStatus == HERO_STATUS.Invincible)
                {
                    Debug.Log("gameGlobalInfoNotify.heroMsg中有玩家处于无敌状态");
                    HeroManager.Instance.addHero(heroMsg);
                    HeroManager.Instance.InvincibleHero(heroMsg);
                }
                else
                {
                    Debug.Log("gameGlobalInfoNotify.heroMsg中有错误的玩家状态");
                }
            }
            else if (heroMsg.HeroId == Snake.HeroMyselfId)
            {
                Debug.LogError("gameGlobalInfoNotify.HeroMyselfId中我自己不需要addHero");
            }
            
            
        }


        //2.渲染道具
        //依次获取道具信息，调用EntityManager.addPlayer方法
        foreach (ItemMsg itemMsg in gameGlobalInfoNotify.ItemMsg)
        {
            ItemManager.Instance.addItem(itemMsg);
        }
    }
}
