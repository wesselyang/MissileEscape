using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Shop Module Manager.
/// Author: Mingxi Yang 104563133
/// </summary>

public class ShopManager : MonoBehaviour {

    private ShopData shopData; //Shop Data Object.

    private string xmlPath = "Assets/Data/ShopData.xml"; //shop data xml path.

    private GameObject ui_ShopItem;

    //Two buttons in Shop Module.
    private GameObject leftButton;
    private GameObject rightButton;

    //A list of UI items.
    private List<GameObject> shopUI = new List<GameObject>();

    private int index = 0; // the index of item that shown in Shop Module.

    void Start () {
        shopData = new ShopData();
        shopData.ReadXmlByPath(xmlPath);

        ui_ShopItem = Resources.Load<GameObject>("UI/ShopItem");

        //Button event binding.
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");
        UIEventListener.Get(leftButton).onClick = LeftButtonClick;
        UIEventListener.Get(rightButton).onClick = RightButtonClick;


        CreateAllShopUI();
	}
	
    /// <summary>
    /// Create all shop items.
    /// </summary>
    private void CreateAllShopUI()
    {
        for(int i = 0; i < shopData.shopList.Count; i++)
        {
            //Instantiate an shop item object.
            GameObject item = NGUITools.AddChild(gameObject, ui_ShopItem);
            //Load the corresponding ship model.
            GameObject ship = Resources.Load<GameObject>(shopData.shopList[i].Model);
            //Set the value for the item object in UI.
            item.GetComponent<ShopItemUI>().SetUIValue(shopData.shopList[i].Speed, shopData.shopList[i].Rotate, shopData.shopList[i].Price, ship);

            //Add the item into list
            shopUI.Add(item);
        }
        //Hide UI items.
        ShopUISwitch(index);
    }

    /// <summary>
    /// Left Button Click Event.
    /// </summary>
    private void LeftButtonClick(GameObject go)
    {
        if (index > 0)
        {
            Debug.Log("Left");
            index--;
            ShopUISwitch(index);
        }

    }

    /// <summary>
    /// Right Button Click Event.
    /// </summary>
    private void RightButtonClick(GameObject go)
    {
        if (index < shopUI.Count - 1)
        {
            Debug.Log("Right");
            index++;
            ShopUISwitch(index);
        }
    }

    /// <summary>
    /// UI items method of hiding and showing.
    /// </summary>
    /// <param name="index"></param>
    private void ShopUISwitch(int index)
    {
        for(int i = 0; i < shopUI.Count; i++)
        {
            shopUI[i].SetActive(false);

        }
        shopUI[index].SetActive(true);
    }

}
