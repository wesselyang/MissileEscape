using UnityEngine;
using System.Collections;

/// <summary>
/// Player(warship) control status.
/// Author: Mingxi Yang 104563133
/// </summary>


public class Ship : MonoBehaviour {

    private Transform m_Transform;

    private bool isLeft = false; //Left turn sign.
    private bool isRight = false; //Right turn sign.
    private bool isDeath = false; //Warship is alive or not.

    private int rewardNum = 0; //

    private MissileManager m_MissileManager;
    private RewardManager m_RewardManager;

    private GameObject prefab_Smoke03; //Explosion effects

    private GameUIManager m_GameUIManager;

    private int speed;
    private int rotate;

    public int Speed { get; set; }
    public int Rotate { get; set; }

    public bool IsLeft
    {
        get { return isLeft; }
        set { isLeft = value; }
    }

    public bool IsRight
    {
        get { return isRight; }
        set { isRight = value; }
    }

    public bool IsDeath
    {
        get { return isDeath; }
        set { isDeath = value; }
    }

    void Start () {

        m_Transform = gameObject.GetComponent<Transform>();
        m_MissileManager = GameObject.Find("MissileManager").GetComponent<MissileManager>();
        m_RewardManager = GameObject.Find("RewardManager").GetComponent<RewardManager>();
        prefab_Smoke03 = Resources.Load<GameObject>("Smoke03");
        m_GameUIManager = GameObject.Find("UI Root").GetComponent<GameUIManager>();

	}
	
	void Update () {
        if (IsDeath == false) //Player is able to turn the warship when it's alive.
        {
            m_Transform.Translate(Vector3.forward * 0.3f * Speed); //Automatically go forward.

            if (isLeft)
            {
                m_Transform.Rotate(Vector3.up * -0.2f * Rotate);
            }

            if (isRight)
            {
                m_Transform.Rotate(Vector3.up * 0.2f * Rotate);
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        GameObject[] allMissiles = GameObject.FindGameObjectsWithTag("Missile");
        //When the warship touches the border.
        if (coll.tag == "Border")
        {
            IsDeath = true;
            GameObject.Instantiate(prefab_Smoke03, m_Transform.position, Quaternion.identity); //Show the explosion effect.

            m_GameUIManager.ShowOverPanel();

            m_MissileManager.StopCreate();  //Stop creating missiles.
            m_RewardManager.StopCreate();   //Stop creating reward items.
            for (int i = 0; i < allMissiles.Length; i++)    //Clean all the missiles created, with explosion effects.
            {
                GameObject.Instantiate(prefab_Smoke03, allMissiles[i].GetComponent<Transform>().position, Quaternion.identity);
                GameObject.Destroy(allMissiles[i]);
            }
            gameObject.SetActive(false); //Make warship "invisible".
            
            
        }

        //When the warship touches the missile.
        if(coll.tag == "Missile")
        {
            IsDeath = true; //Mark warship as dead
            GameObject.Instantiate(prefab_Smoke03, m_Transform.position, Quaternion.identity); //Show the explosion effect.

            m_GameUIManager.ShowOverPanel();

            
            m_MissileManager.StopCreate(); //Stop creating missiles.
            m_RewardManager.StopCreate();   //Stop creating reward items.
            GameObject.Destroy(coll.gameObject); //Delete the missile that is colliding the warship.
            for (int i = 0; i < allMissiles.Length; i++)    //Clean all the missiles created, with explosion effects.
            {
                GameObject.Instantiate(prefab_Smoke03, allMissiles[i].GetComponent<Transform>().position,Quaternion.identity);
                GameObject.Destroy(allMissiles[i]);
            }
            //GameObject.Destroy(GameObject.FindGameObjectsWithTag("Missile"));
            gameObject.SetActive(false); //Make warship "invisible".

        }

        if(coll.tag == "Reward")
        {
            rewardNum += 10; //calculate the reward item.
            m_GameUIManager.UpdateStarLabel(rewardNum); //Update the score shown in GameUI.  
            GameObject.Destroy(coll.gameObject); //Delete the reward item.

        }
    }

}
