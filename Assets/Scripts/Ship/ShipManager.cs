using UnityEngine;
using System.Collections;


/// <summary>
/// Ship management scripts.
/// Author: Mingxi Yang 104563133
/// </summary>
public class ShipManager : MonoBehaviour {

    private GameObject model, player;


    void Awake()
    {
        string ship = PlayerPrefs.GetString("ShipInGamePath");
        Debug.Log(ship);
        model = Resources.Load<GameObject>(ship);
        
        //Instantiate the specific ship model in game scene.
        player = GameObject.Instantiate(model, Vector3.zero, Quaternion.identity) as GameObject;
        player.AddComponent<Ship>();    //Add Ship script to models.
        player.tag = "Player";          //Add tag to models.
    }
	

}
