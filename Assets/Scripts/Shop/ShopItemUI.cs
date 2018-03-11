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
    private GameObject shipParent;

    // Use this for initialization
	void Awake ()
    {
        m_Transform = gameObject.GetComponent<Transform>();

        ui_Speed = m_Transform.FindChild("Speed/SpeedValue").GetComponent<UILabel>();
        ui_Rotate = m_Transform.FindChild("Rotate/RotateValue").GetComponent<UILabel>();
        ui_Price = m_Transform.FindChild("PurchaseButton/Price").GetComponent<UILabel>();

        shipParent = m_Transform.FindChild("Model").gameObject;

	}
	
    /// <summary>
    /// Set the value for each item in UI.
    /// </summary>
    public void SetUIValue(string speed, string rotate, string price, GameObject model)
    {

        ui_Speed.text = speed;
        ui_Rotate.text = rotate;
        ui_Price.text = price;

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

}
