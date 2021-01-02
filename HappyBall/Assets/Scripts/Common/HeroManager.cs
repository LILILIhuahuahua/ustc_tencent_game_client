using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroManager : MonoBehaviour
{
    public GameObject heroPrefab;
    

    // Start is called before the first frame update
    private static HeroManager _instance;
    public static HeroManager Instance
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
        if (heroMsg.HeroId == Snake.HeroMyselfId)
        {
            Debug.LogError("收到的heroMsg是heroId我自己");
            return;
        }
        //实例化
        GameObject hero = Instantiate(heroPrefab, transform);

        //添加进Hero字典中  id+GameObject
        int heroId = heroMsg.HeroId;
        GameMaster.Instance.heroDictionary.Add(heroId, hero);

        //设置位置
        hero.transform.localPosition = new Vector3(heroMsg.HeroPosition.CoordinateX, heroMsg.HeroPosition.CoordinateY, 0);

        //设置大小
        float heroLocalScale = heroMsg.HeroSize / MessageConst.HeroInitSize;
        hero.transform.localScale = new Vector3(heroLocalScale, heroLocalScale, 0);

        //设置ID
        OtherHero otherHero = hero.GetComponent<OtherHero>();
        otherHero.OtherHeroId = heroMsg.HeroId;

        //Hero皮肤


        
    }

    public void updateHero(HeroMsg heroMsg)
    {
        Debug.Log("正在执行updateHero函数");
        if (heroMsg.HeroId == Snake.HeroMyselfId)
        {
            Debug.LogError("收到的heroMsg是heroId我自己");
            return;
        }
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
            HeroManager.Instance.InvincibleHero(heroMsg);
        }

    }

    public void removeHero(HeroMsg heroMsg)
    {
        Debug.Log("执行removeHero");
        if (heroMsg.HeroId == Snake.HeroMyselfId)
        {
            Debug.LogError("收到的heroMsg是heroId我自己");
            return;
        }
        //1.字典中移除Hero
        int heroId = heroMsg.HeroId;
        GameMaster.Instance.heroDictionary.TryGetValue(heroId, out GameObject hero);
        if (hero != null)
        {
            //字典中移除Hero
            GameMaster.Instance.heroDictionary.Remove(heroMsg.HeroId);

            //2.销毁Hero实体
            Destroy(hero);
        }
        else
        {
            Debug.LogError("执行removeHero的字典中找不到HeroId的对象");
        }

    }

    public void InvincibleHero(HeroMsg heroMsg)
    {
        Debug.Log("执行InvincibleHero,让玩家处于无敌状态"); 
        //将无敌玩家的Cricle Collider2D 变成inable，几秒钟之后再变回来
        int heroId = heroMsg.HeroId;
        GameMaster.Instance.heroDictionary.TryGetValue(heroId, out GameObject hero);
        GameObject invisibleMask = hero.GetComponent<OtherHero>().invisibleMask;

        Collider2D heroCollider2D = hero.GetComponent<Collider2D>();

        //几秒后变回来
        StartCoroutine(invincible(heroCollider2D, invisibleMask));
        
        

    }

    IEnumerator invincible(Collider2D heroCollider2D, GameObject invisibleMask)
    {
        Debug.Log("heroCollider2D.enabled = false");
        //播放无敌特效
        heroCollider2D.enabled = false;
        invisibleMask.SetActive(true);
        yield return new WaitForSeconds(MessageConst.InvincibleTime);
        Debug.Log("heroCollider2D.enabled = ture");
        heroCollider2D.enabled = true;
        invisibleMask.SetActive(false);

    }

}
