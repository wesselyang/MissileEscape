using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Shop Module Manager.
/// Author: Mingxi Yang 104563133
/// </summary>

public class ShopManager : MonoBehaviour {

    private ShopData shopData; //Shop Data Object.

    //private string xmlPath = "Assets/Data/ShopData.xml"; //shop data xml path.
    private string shopDataContent;
    private string saveDataContent = "<SaveData><GoldCount>3000</GoldCount><BestScore>0</BestScore><ID0>1</ID0><ID1>0</ID1><ID2>0</ID2><ID3>0</ID3><ID4>0</ID4></SaveData>";
    //private string savePath = "Assets/Data/SaveData.xml"; //player data xml path.
    private string savePath = Application.persistentDataPath + "/SaveData.xml";

    private GameObject ui_ShopItem;

    //Two buttons in Shop Module.
    private GameObject leftButton;
    private GameObject rightButton;

    //A list of UI items.
    private List<GameObject> shopUI = new List<GameObject>();

    private int index = 0; // the index of item that shown in Shop Module.

    private UILabel starValue;
    private UILabel scoreValue;

    private StartUIManager m_StartUIManager;

    void Start ()
    {
        shopDataContent = Resources.Load("ShopData").ToString(); //Set the content of ShopData.xml to a string variable.

        if (!File.Exists(savePath))
        {
            File.WriteAllText(savePath, saveDataContent);
        }

        shopData = gameObject.AddComponent<ShopData>();
        shopData.ReadXmlByPath(shopDataContent);
        shopData.ReadPlayerInfo(savePath);

        //Test for ReadPlayerInfo.
        //Debug.Log(shopData.goldCount);
        //Debug.Log(shopData.bestScore);
        //for(int i = 0; i < shopData.shopStatus.Count; i++)
        //{
        //    Debug.Log(shopData.shopStatus[i]);
        //}

        ui_ShopItem = Resources.Load<GameObject>("UI/ShopItem");
        m_StartUIManager = GameObject.Find("UI Root").GetComponent<StartUIManager>();

        //Button event binding.
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");
        UIEventListener.Get(leftButton).onClick = LeftButtonClick;
        UIEventListener.Get(rightButton).onClick = RightButtonClick;

        //Sync the player info data from xml to UI.
        starValue = GameObject.Find("Star/StarValue").GetComponent<UILabel>();
        scoreValue = GameObject.Find("Score/ScoreValue").GetComponent<UILabel>();

        //Load the new score from PlayerPrefs.
        int temp_Score = PlayerPrefs.GetInt("Score", 0);
        if (temp_Score > shopData.bestScore)
        {
            //Update UI best score.
            UpdateUIScore(temp_Score);
            //Update XML best score.
            shopData.UpdateXMLData(savePath, "BestScore", temp_Score.ToString());
            //Clear PlayerPrefs data.
            PlayerPrefs.SetInt("Score", 0);
        }
        else
        {
            UpdateUIScore(shopData.bestScore);
        }

        //Load the star value from PlayerPrefs.
        int temp_Star = PlayerPrefs.GetInt("Star", 0);
        if (temp_Star > 0)
        {
            int currentStarValue = shopData.goldCount + temp_Star;
            //Update UI star value.
            UpdateUIStar(currentStarValue);
            //Update XML star value.
            shopData.UpdateXMLData(savePath, "GoldCount", currentStarValue.ToString());
            //Clear PlayerPrefs data.
            PlayerPrefs.SetInt("Star", 0);
        }
        else
        {
            UpdateUIStar(shopData.goldCount);
        }

        SetWarshipInfo(shopData.shopList[index]);  //Pre-load the ship model path.

        CreateAllShopUI();
	}

    /// <summary>
    /// Update the gold in UI.
    /// </summary>
    private void UpdateUIStar(int star)
    {

        starValue.text = star.ToString();

    }

    /// <summary>
    /// Update best score in UI.
    /// </summary>
    private void UpdateUIScore(int score)
    {

        scoreValue.text = score.ToString();

    }

    /// <summary>
    /// Update the gold and best score in UI.
    /// </summary>
    private void UpdateUIData()
    {

        starValue.text = shopData.goldCount.ToString();
        scoreValue.text = shopData.bestScore.ToString();

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
            GameObject ship = Resources.Load<GameObject>("shipUI/" + shopData.shopList[i].Model);
            //Set the value for the item object in UI.
            item.GetComponent<ShopItemUI>().SetUIValue(shopData.shopList[i].Id, shopData.shopList[i].Speed, shopData.shopList[i].Rotate, shopData.shopList[i].Price, ship, shopData.shopStatus[i]);

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
            //Debug.Log("Left");
            index--;
            int status = shopData.shopStatus[index];
            m_StartUIManager.SetPlayButtonStatus(status);
            SetWarshipInfo(shopData.shopList[index]);  //Pre-load the path while selecting.
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
            //Debug.Log("Right");
            index++;
            int status = shopData.shopStatus[index];
            m_StartUIManager.SetPlayButtonStatus(status);
            SetWarshipInfo(shopData.shopList[index]);  //Pre-load the path while selecting.
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


    /// <summary>
    /// Figure out if item is available for purchase.
    /// </summary>
    /// <param name="item"></param>
    private void PurchaseAction(ShopItemUI item)
    {
        if(shopData.goldCount >= item.ItemPrice)
        {
            //Debug.Log("Purchase successful!");
            item.PurchaseDone();    //Hide purchase button after finishing purchase.
            shopData.goldCount -= item.ItemPrice;   //Cost the gold while purchasing.
            UpdateUIData(); //Update data in UI.

            shopData.UpdateXMLData(savePath, "GoldCount", shopData.goldCount.ToString()); //Update data in XML file.
            int status = shopData.shopStatus[index] = 1;
            shopData.UpdateXMLData(savePath, "ID" + item.ItemId, "1");
            
            m_StartUIManager.SetPlayButtonStatus(status);
        }
        else
        {
            //Debug.Log("Purchase failed.");
        }
    }


    /// <summary>
    /// Set in-game Ship model path.
    /// </summary>
    /// <param name="name"></param>
    private void SetWarshipInfo(ShopItem item)
    {
        PlayerPrefs.SetString("ShipModel", "ShipInGame/" + item.Model);
        PlayerPrefs.SetInt("ShipSpeed", int.Parse(item.Speed));
        PlayerPrefs.SetInt("ShipRotate", int.Parse(item.Rotate));
    }
}
