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
        //Load Ship data.
        string shipModel = PlayerPrefs.GetString("ShipModel");
        int speed = PlayerPrefs.GetInt("ShipSpeed");
        int rotate = PlayerPrefs.GetInt("ShipRotate");
        //Debug.Log(ship);

        //Instantiate the specific ship model in game scene.
        model = Resources.Load<GameObject>(shipModel);
        player = GameObject.Instantiate(model, Vector3.zero, Quaternion.identity) as GameObject;


        Ship ship = player.AddComponent<Ship>();    //Add Ship script to models.
        ship.Speed = speed;
        ship.Rotate = rotate;
        player.tag = "Player";          //Add tag to models.
    }
	

}
