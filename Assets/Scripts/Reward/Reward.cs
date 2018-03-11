﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Reward item control
/// </summary>
public class Reward : MonoBehaviour {

    private Transform m_Transform;


    // Use this for initialization
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        m_Transform.Rotate(Vector3.left);
	}

    void OnDestroy()
    {
        //Debug.Log("I'm destroyed.");
        SendMessageUpwards("RewardCountDown");
    }

}