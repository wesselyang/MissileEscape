using UnityEngine;
using System.Collections;

/// <summary>
/// Player(warship) control status.
/// Author: Mingxi Yang
/// </summary>


public class Ship : MonoBehaviour {

    private Transform m_Transform;

    private bool isLeft = false; //Left turn sign.
    private bool isRight = false; //Right turn sign.
    private bool isDeath = false; //Warship is alive or not.

    private MissileManager m_MissileManager;

    private GameObject smoke03; //Explosion effects

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

    void Start () {

        m_Transform = gameObject.GetComponent<Transform>();
        m_MissileManager = GameObject.Find("MissileManager").GetComponent<MissileManager>();
        smoke03 = Resources.Load<GameObject>("Smoke03");

	}
	
	void Update () {
        if (isDeath == false) //Player is able to turn the warship when it's alive.
        {
            m_Transform.Translate(Vector3.forward); //Automatically go forward.

            if (isLeft)
            {
                m_Transform.Rotate(Vector3.up * -1);
            }

            if (isRight)
            {
                m_Transform.Rotate(Vector3.up * 1);
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {

        //When the warship touches the border.
        if(coll.tag == "Border")
        {
            isDeath = true;
            GameObject.Instantiate(smoke03, m_Transform.position, Quaternion.identity); //Show the explosion effect.

            m_MissileManager.StopCreate(); //Stop creating missiles.
            gameObject.SetActive(false); //Make warship "invisible".
        }

        //When the warship touches the missile.
        if(coll.tag == "Missile")
        {
            isDeath = true; //Mark warship as dead
            GameObject.Instantiate(smoke03, m_Transform.position, Quaternion.identity); //Show the explosion effect.

            m_MissileManager.StopCreate(); //Stop creating missiles.
            GameObject.Destroy(coll.gameObject); //Delete the missile that is colliding the warship.
            gameObject.SetActive(false); //Make warship "invisible".
        }
    }

}
