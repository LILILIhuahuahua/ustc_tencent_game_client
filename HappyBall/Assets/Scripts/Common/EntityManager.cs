using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntityManager : MonoBehaviour
{
    public GameObject heroPrefab;
    public GameObject foodPrefab;

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

     
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void addHero(HeroMsg heroMsg)
    {
        Debug.Log("正在执行addHero函数");
        //实例化
        GameObject hero = Instantiate(heroPrefab, transform);

        //设置位置
        hero.transform.localPosition = new Vector3(heroMsg.HeroPosition.CoordinateX, heroMsg.HeroPosition.CoordinateY, 0);

        //设置大小
        float heroLocalScale = heroMsg.HeroSize / MessageConst.HeroInitSize;
        hero.transform.localScale = new Vector3(heroLocalScale, heroLocalScale, 0);

        //设置ID
        OtherHero otherHero = hero.GetComponent<OtherHero>();
        otherHero.OtherHeroId = heroMsg.HeroId;

        //Hero皮肤


        //添加进Hero字典中  id+GameObject
        int heroId = heroMsg.HeroId;
        GameMaster.Instance.heroDictionary.Add(heroId, hero);
    }

    public void updateHero(HeroMsg heroMsg)
    {
        Debug.Log("正在执行updateHero函数");
        //判断Hero的状态
        //一.HeroLive
        if (heroMsg.HeroStatus == HERO_STATUS.Live)
        {
            Debug.Log("Hero处于生存状态");
            //1.从包中获取玩家ID,玩家信息
            int heroId = heroMsg.HeroId;


            //2.从字典中获取Hero对象
            GameMaster.Instance.heroDictionary.TryGetValue(heroId, out GameObject hero);
            //判空
            if (hero != null)
            {
                Debug.Log(hero);
            }
            else
            {
                Debug.LogError("updateHero没有在heroDictionary找到hero");
                return;
            }

            //3.根据HeroMsg的信息，修改Hero的信息
            if (heroMsg.HeroPosition != null)
            {
                //设置位置
                hero.transform.localPosition = new Vector3(heroMsg.HeroPosition.CoordinateX, heroMsg.HeroPosition.CoordinateY, 0);
            }
            if (heroMsg.HeroSize != 0)
            {
                //设置大小
                float heroLocalScale = heroMsg.HeroSize / MessageConst.HeroInitSize;
                hero.transform.localScale = new Vector3(heroLocalScale, heroLocalScale, 0);
                OtherHero otherHero = hero.GetComponent<OtherHero>();
                otherHero.OtherHeroSize = heroMsg.HeroSize;

            }

        }
        //2.Hero的Dead
        else if (heroMsg.HeroStatus == HERO_STATUS.Dead)
        {
            removeHero(heroMsg);
            Debug.Log("Hero处于死亡状态");

        }
        //3.Hero的Invincible
        else if (heroMsg.HeroStatus == HERO_STATUS.Invincible)
        {
            Debug.Log("Hero处于无敌状态");
        }

    }

    public void removeHero(HeroMsg heroMsg)
    {
        Debug.Log("执行removeHero");
        //1.字典中移除Hero
        int heroId = heroMsg.HeroId;
        GameMaster.Instance.heroDictionary.TryGetValue(heroId, out GameObject hero);
        GameMaster.Instance.heroDictionary.Remove(heroMsg.HeroId);

        //2.销毁Hero实体
        Destroy(hero);

    }




    public void addItem(ItemMsg itemsMsg)
    {
        Debug.Log("正在执行addItem函数");
        //实例化
        GameObject item = null;
        if (itemsMsg.ItemType == ENTITY_TYPE.FoodType)
        {
            //实例化食物
            item = Instantiate(foodPrefab, transform);

            //添加进道具字典中  id+GameObject
            int itemId = itemsMsg.ItemId;
            GameMaster.Instance.foodDictionary.Add(itemId, item);
        }
        else if(itemsMsg.ItemType == ENTITY_TYPE.PropType)
        {
            //实例化道具
            item = Instantiate(foodPrefab, transform);
            //添加进道具字典中  id+GameObject
            int itemId = itemsMsg.ItemId;
            GameMaster.Instance.propDictionary.Add(itemId, item);
        }


        //设置位置
        item.transform.localPosition = new Vector3(itemsMsg.ItemPosition.CoordinateX,itemsMsg.ItemPosition.CoordinateY, 0);

        //设置大小
        


        //Item皮肤


        
    }

}
