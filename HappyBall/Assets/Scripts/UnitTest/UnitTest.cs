using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TestEntityInfoChangeNotify();
        //TestgameGlobalInfoNotify();
        TestAddHero();

        InvokeRepeating("TestUpateHero", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TestEntityInfoChangeNotify()
    {
        //测试用
        //1.测试EntityInfoChangeNotify
        {
            //1.声明
            GMessage gMessage = new GMessage();
            Notify notify = new Notify();
            HeroMsg heroMesg = new HeroMsg();
            CoordinateXY pos = new CoordinateXY();
            EntityInfoChangeNotify entityInfoChangeNotify = new EntityInfoChangeNotify();


            //2.写数据
            gMessage.MsgType = MSG_TYPE.Notify;
            gMessage.SeqId = 1;
            entityInfoChangeNotify.EntityType = ENTITY_TYPE.HeroType; //玩家
            entityInfoChangeNotify.EntityId = 8080;

            heroMesg.HeroId = 8080;

            pos.CoordinateX = 120;
            pos.CoordinateY = 200;

            //3.填包
            heroMesg.HeroPosition = pos;
            entityInfoChangeNotify.HeroMsg = heroMesg;
            notify.EntityInfoChangeNotify = entityInfoChangeNotify;
            gMessage.Notify = notify;

            //4.测试
            HandleMes.transmitMes(gMessage);
        }
    }

    public void TestAddHero()
    {
        Debug.Log("TestAddHero");
        //2.测试gameGlobalInfoNotify
        {
            //1.声明
            GMessage gMessage = new GMessage();
            Notify notify = new Notify();
            GameGlobalInfoNotify gameGlobalInfoNotify = new GameGlobalInfoNotify();
            HeroMsg heroMesg = new HeroMsg();
            CoordinateXY pos = new CoordinateXY();



            //2.写数据
            gMessage.MsgType = MSG_TYPE.Notify;
            gMessage.SeqId = 2;
            gameGlobalInfoNotify.HeroNumber = 1;
            gameGlobalInfoNotify.Time = 2;


            heroMesg.HeroId = 8080;
            heroMesg.HeroStatus = HERO_STATUS.Live;
            heroMesg.HeroSize = 45;
            pos.CoordinateX = 120f;
            pos.CoordinateY = 200f;

            //3.填包
            heroMesg.HeroPosition = pos;
            gameGlobalInfoNotify.HeroMsg.Add(heroMesg);
            notify.GameGlobalInfoNotify = gameGlobalInfoNotify;
            gMessage.Notify = notify;

            //4.测试
            HandleMes.transmitMes(gMessage);

        }
    }

    public void TestUpateHero()
    {
        Debug.Log("TestUpateHero");
        {
            //1.声明
            GMessage gMessage = new GMessage();
            Notify notify = new Notify();
            HeroMsg heroMesg = new HeroMsg();
            CoordinateXY pos = new CoordinateXY();
            EntityInfoChangeNotify entityInfoChangeNotify = new EntityInfoChangeNotify();


            //2.写数据
            gMessage.MsgType = MSG_TYPE.Notify;
            gMessage.SeqId = 1;
            entityInfoChangeNotify.EntityType = ENTITY_TYPE.HeroType; //玩家
            entityInfoChangeNotify.EntityId = 8080;

            heroMesg.HeroId = 8080;
            heroMesg.HeroStatus = HERO_STATUS.Live;
                //改变Hero的位置与size
            pos.CoordinateX = 300;
            pos.CoordinateY = 300;
            heroMesg.HeroSize = 250;

            //3.填包
            heroMesg.HeroPosition = pos;
            entityInfoChangeNotify.HeroMsg = heroMesg;
            notify.EntityInfoChangeNotify = entityInfoChangeNotify;
            gMessage.Notify = notify;

            //4.测试
            HandleMes.transmitMes(gMessage);
        }
    }
    public void TestRemoveHero()
    {
        Debug.Log("TestRemoveHero");
        {
            //1.声明
            GMessage gMessage = new GMessage();
            Notify notify = new Notify();
            HeroMsg heroMesg = new HeroMsg();
            CoordinateXY pos = new CoordinateXY();
            EntityInfoChangeNotify entityInfoChangeNotify = new EntityInfoChangeNotify();


            //2.写数据
            gMessage.MsgType = MSG_TYPE.Notify;
            gMessage.SeqId = 1;
            entityInfoChangeNotify.EntityType = ENTITY_TYPE.HeroType; //玩家
            entityInfoChangeNotify.EntityId = 8080;

            heroMesg.HeroStatus = HERO_STATUS.Dead;
           

            //3.填包
            heroMesg.HeroPosition = pos;
            entityInfoChangeNotify.HeroMsg = heroMesg;
            notify.EntityInfoChangeNotify = entityInfoChangeNotify;
            gMessage.Notify = notify;

            //4.测试
            HandleMes.transmitMes(gMessage);
        }
    }
}

