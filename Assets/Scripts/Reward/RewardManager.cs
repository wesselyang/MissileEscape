using UnityEngine;
using System.Collections;

/// <summary>
/// Reward item manager.
/// </summary>

public class RewardManager : MonoBehaviour {

    private Transform m_Transform;
    private GameObject prefab_Reward;

    private int rewardCount = 0;
    private int rewardMaxCount = 3;



    private void CreateReward()
    {
        if(rewardCount < rewardMaxCount)
        {
            Vector3 pos = new Vector3(Random.Range(-650, 750), 0, Random.Range(-400, 710));
            GameObject.Instantiate(prefab_Reward, pos, Quaternion.identity, m_Transform);
            rewardCount++;
        }

    }

    public void StopCreate()
    {
        CancelInvoke();
    }

    public void RewardCountDown()
    {
        rewardCount--;
        Debug.Log("Create reward again.");
    }

    // Use this for initialization
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        prefab_Reward = Resources.Load<GameObject>("Reward");

        InvokeRepeating("CreateReward", 5, 5);
	}
	
	// Update is called once per frame
	void Update () {
    
	}
}
