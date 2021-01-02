using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject foodPrefab;
    // Start is called before the first frame update
    private static ItemManager _instance;
    public static ItemManager Instance
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
        else if (itemsMsg.ItemType == ENTITY_TYPE.PropType)
        {
            //实例化道具
            item = Instantiate(foodPrefab, transform);
            //添加进道具字典中  id+GameObject
            int itemId = itemsMsg.ItemId;
            GameMaster.Instance.propDictionary.Add(itemId, item);
        }


        //设置位置
        item.transform.localPosition = new Vector3(itemsMsg.ItemPosition.CoordinateX, itemsMsg.ItemPosition.CoordinateY, 0);

        //设置大小



        //Item皮肤



    }

}
