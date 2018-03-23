using UnityEngine;
using System.Collections;

/// <summary>
/// Camera Follow Scripts.
/// Author: Mingxi Yang 104563133
/// </summary>

public class CameraFollow : MonoBehaviour {

    private Transform m_Transform;
    private Transform player_Transform;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        player_Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

	}
	
	void Update () {
        m_Transform.position = player_Transform.position + new Vector3(0, 50, 0);
	}
}
