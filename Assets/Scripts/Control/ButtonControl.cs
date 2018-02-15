using UnityEngine;
using System.Collections;

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

    // Use this for initialization
    void Start () {

        left = GameObject.Find("Left");
        right = GameObject.Find("Right");

        m_Ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();

        UIEventListener.Get(left).onPress = LeftPress;
        UIEventListener.Get(right).onPress = RightPress;

	}
	
	// Update is called once per frame
	void Update () {

	}
}
