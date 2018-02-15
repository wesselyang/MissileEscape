using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

    private Transform m_Transform;

    private bool isLeft = false;
    private bool isRight = false;

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

    // Use this for initialization
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        m_Transform.Translate(Vector3.forward);

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
