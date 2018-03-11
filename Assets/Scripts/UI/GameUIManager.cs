using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Game UI scene manager.
/// Author: Mingxi Yang 104563133
/// </summary>

public class GameUIManager : MonoBehaviour {

    private GameObject m_GamePanel;
    private GameObject m_OverPanel;

    private UILabel label_Score;

    private GameObject m_ButtonControl;
    private GameObject button_Reset;
    

    // Use this for initialization
	void Start () {
        m_GamePanel = GameObject.Find("GamePanel");
        m_OverPanel = GameObject.Find("OverPanel");
        m_ButtonControl = GameObject.Find("ButtonControl");
        button_Reset = GameObject.Find("Reset");

        label_Score = GameObject.Find("GameStarValue").GetComponent<UILabel>();
        label_Score.text = "0";
        UIEventListener.Get(button_Reset).onClick = ResetButtonClick;

        m_OverPanel.SetActive(false);
	}
	
    public void UpdateScoreLabel(int score)
    {
        label_Score.text = score.ToString();
    }

    public void ShowOverPanel()
    {
        m_ButtonControl.SetActive(false);
        m_OverPanel.SetActive(true);
    }

    private void ResetButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Start");
    }

	// Update is called once per frame
	void Update () {
    
	}
}
