using UnityEngine;
using System.Collections;

/// <summary>
/// Shop Module Manager.
/// Author: Mingxi Yang 104563133
/// </summary>

public class ShopManager : MonoBehaviour {

    private ShopData shopData; //Shop Data Object.

    private string xmlPath = "Assets/Data/ShopData.xml"; //shop data xml path.

    private GameObject ui_ShopItem;

    void Start () {
        shopData = new ShopData();
        shopData.ReadXmlByPath(xmlPath);

        ui_ShopItem = Resources.Load<GameObject>("UI/ShopItem");

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
        }
    }

}
