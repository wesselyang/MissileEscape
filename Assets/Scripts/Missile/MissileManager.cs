using UnityEngine;
using System.Collections;

/// <summary>
/// Missile Creator Script.
/// Author: Mingxi Yang 104563133
/// </summary>
/// 

public class MissileManager : MonoBehaviour {

    private Transform m_Transform;
    private Transform[] createPoints;

    private GameObject prefab_Missile_1;
    private GameObject prefab_Missile_2;
    private GameObject prefab_Missile_3;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        createPoints = GameObject.Find("CreatePoints").GetComponent<Transform>().GetComponentsInChildren<Transform>();

        //for(int i = 0; i < createPoints.Length; i++)
        //{
        //    Debug.Log("Point--" + createPoints[i].name);
        //}

        prefab_Missile_1 = Resources.Load<GameObject>("Missile/Missile_1");
        prefab_Missile_2 = Resources.Load<GameObject>("Missile/Missile_2");
        prefab_Missile_3 = Resources.Load<GameObject>("Missile/Missile_3");

        InvokeRepeating("CreateMissile", 2, 2);
	}
	

	void Update () {
        

	}

    private void CreateMissile()
    {
        int index = Random.Range(0, createPoints.Length);
        int missileType = Random.Range(1, 4);
        switch (missileType) {
            case 1:
                GameObject.Instantiate(prefab_Missile_1, createPoints[index].position, Quaternion.identity, m_Transform);
                break;
            case 2:
                GameObject.Instantiate(prefab_Missile_2, createPoints[index].position, Quaternion.identity, m_Transform);
                break;
            case 3:
                GameObject.Instantiate(prefab_Missile_3, createPoints[index].position, Quaternion.identity, m_Transform);
                break;
        }
    }

    /// <summary>
    /// Stop Creating Missiles.
    /// </summary>
    public void StopCreate()
    {
        CancelInvoke();
    }

}
