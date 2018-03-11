using UnityEngine;
using System.Collections;

/// <summary>
/// Missile Control Script.
/// Author: Mingxi Yang 104563133
/// </summary>

public class Missile : MonoBehaviour {

    private Transform m_Transform;
    private Transform player_Transform;

    private Vector3 normalForward = Vector3.forward;
    private GameObject prefab_Smoke03; //Explosion effects

    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        player_Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        prefab_Smoke03 = Resources.Load<GameObject>("Smoke03");
    }
	
	void Update () {
        m_Transform.Translate(Vector3.forward);

        //Missile pursuing.
        Vector3 dir = player_Transform.position - m_Transform.position; //Calculate the direction from missile to warship(player).

        normalForward = Vector3.Lerp(normalForward, dir, Time.deltaTime); //Using interpolation calculation to calculate the angle.

        m_Transform.rotation = Quaternion.LookRotation(normalForward); //Rotate the missile toward the warship.


	}

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Missile")
        {
            GameObject.Instantiate(prefab_Smoke03, m_Transform.position, Quaternion.identity); //Show the explosion effect.

            GameObject.Destroy(gameObject); //Delete itself when colliding other missiles.
        }
    }
}
