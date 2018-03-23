using UnityEngine;
using System.Collections;

/// <summary>
/// Button Control.
/// Author: Mingxi Yang 104563133
/// </summary>

public class ButtonControl : MonoBehaviour {

    private Ship m_Ship;

    private GameObject left;
    private GameObject right;



    private void LeftPress(GameObject go, bool isPress)
    {
        if(isPress)
        {
            Debug.Log("Left is pressing!");
            m_Ship.IsLeft = true;
        }
        else
        {
            Debug.Log("Left is not pressing!");
            m_Ship.IsLeft = false;
        }
    }

    private void RightPress(GameObject go, bool isPress)
    {
        if (isPress)
        {
            Debug.Log("Right is pressing!");
            m_Ship.IsRight = true;
        }
        else
        {
            Debug.Log("Right is not pressing!");
            m_Ship.IsRight = false;
        }
    }

    void Start () {

        left = GameObject.Find("Left");
        right = GameObject.Find("Right");

        m_Ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();

        UIEventListener.Get(left).onPress = LeftPress;
        UIEventListener.Get(right).onPress = RightPress;

	}
	
	void Update () {

	}
}
