using UnityEngine;
using System.Collections;

/// <summary>
/// Shop item controller.
/// Author: Mingxi Yang 104563133
/// </summary>

public class ShopItemUI : MonoBehaviour {

    private Transform m_Transform;

    private UILabel ui_Speed;
    private UILabel ui_Rotate;
    private UILabel ui_Price;
    private GameObject shipParent; //The parent object of ship models.

    private GameObject PurchaseButton;
    private GameObject itemStatus; //The items status for recognizing if purchase button is needed to show.

    private int itemPrice;
    public int itemId;  

	void Awake ()
    {
        m_Transform = gameObject.GetComponent<Transform>();

        ui_Speed = m_Transform.FindChild("Speed/SpeedValue").GetComponent<UILabel>();
        ui_Rotate = m_Transform.FindChild("Rotate/RotateValue").GetComponent<UILabel>();
        ui_Price = m_Transform.FindChild("PurchaseButton/Price").GetComponent<UILabel>();

        shipParent = m_Transform.FindChild("Model").gameObject;
        itemStatus = m_Transform.FindChild("PurchaseButton").gameObject;

        PurchaseButton = m_Transform.FindChild("PurchaseButton/Bg").gameObject;
        UIEventListener.Get(PurchaseButton).onClick = PurchaseButtonClick;

	}
	
    public int ItemPrice
    {
        get { return itemPrice; }
        set { itemPrice = value; }
    }

    /// <summary>
    /// Set the value for each item in UI.
    /// </summary>
    public void SetUIValue(string id, string speed, string rotate, string price, GameObject model, int status)
    {

        ui_Speed.text = speed;
        ui_Rotate.text = rotate;
        ui_Price.text = price;

        itemPrice = int.Parse(price);
        itemId = int.Parse(id);

        //recoginze the status of the item.
        if (status == 1)
        {
            itemStatus.SetActive(false);
        } 

        //Instantiate a ship model.
        GameObject ship = NGUITools.AddChild(shipParent, model);
        Transform ship_Transform = ship.GetComponent<Transform>();

        ship.layer = 5; //Set the ship as UI layer.
        ship_Transform.FindChild("Mesh").gameObject.layer = 5; //Set the mesh in ship object as UI layer.

        //Ship item position setup in UI.
        ship_Transform.localScale = Vector3.one * 5; 
        ship_Transform.localPosition = new Vector3(0, -29, 0);
        Vector3 rot = new Vector3(-90, 0, 0);
        ship_Transform.localRotation = Quaternion.Euler(rot);

    }

    /// <summary>
    /// Purchase button click event.
    /// </summary>
    private void PurchaseButtonClick(GameObject go)
    {
        Debug.Log("PurchaseButton");
        SendMessageUpwards("CalcItemPrice", this);
    }

    public void PurchaseDone()
    {
        itemStatus.SetActive(false);
    }

}
