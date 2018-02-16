using UnityEngine;
using System.Collections;

/// <summary>
/// Missile Creator Script.
/// Author: Mingxi Yang
/// </summary>
/// 

public class MissileManager : MonoBehaviour {

    private Transform m_Transform;
    private Transform[] createPoints;

    private GameObject prefab_Missile_3;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        createPoints = GameObject.Find("CreatePoints").GetComponent<Transform>().GetComponentsInChildren<Transform>();

        //for(int i = 0; i < createPoints.Length; i++)
        //{
        //    Debug.Log("Point--" + createPoints[i].name);
        //}

        prefab_Missile_3 = Resources.Load<GameObject>("Missile_3");

        InvokeRepeating("CreateMissile", 3, 5);
	}
	

	void Update () {
        

	}

    private void CreateMissile()
    {
        int index = Random.Range(0, createPoints.Length);
        GameObject.Instantiate(prefab_Missile_3, createPoints[index].position, Quaternion.identity, m_Transform);
    }

    /// <summary>
    /// Stop Creating Missiles.
    /// </summary>
    public void StopCreate()
    {
        CancelInvoke();
    }

}
