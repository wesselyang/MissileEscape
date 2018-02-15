using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Transform m_Transform;
    private Transform player_Transform;

    // Use this for initialization
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        player_Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


	}
	
	// Update is called once per frame
	void Update () {
        m_Transform.position = player_Transform.position + new Vector3(0, 50, 0);
	}
}
