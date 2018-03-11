using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Start UI scene manager.
/// Author: Mingxi Yang 104563133
/// </summary>

public class StartUIManager : MonoBehaviour {

    private GameObject m_StartPanel;
    private GameObject m_SettingsPanel;

    private GameObject button_Settings;
    private GameObject button_Close;
    private GameObject button_Play;

    private void SettingsButtonClick(GameObject go)
    {
        Debug.Log("Settings button clicked");
        if (m_SettingsPanel.activeSelf == false)
        {
            m_SettingsPanel.SetActive(true);
        }
    }

    private void CloseButtonClick(GameObject go)
    {
        m_SettingsPanel.SetActive(false);
    }

    private void PlayButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Game");
    }

    // Use this for initialization
    void Start () {
        m_StartPanel = GameObject.Find("StartPanel");
        m_SettingsPanel = GameObject.Find("SettingsPanel");

        button_Settings = GameObject.Find("Settings");
        button_Close = GameObject.Find("Close");
        button_Play = GameObject.Find("Play");

        UIEventListener.Get(button_Settings).onClick = SettingsButtonClick;
        UIEventListener.Get(button_Close).onClick = CloseButtonClick;
        UIEventListener.Get(button_Play).onClick = PlayButtonClick;

        m_SettingsPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
    
	}
}
