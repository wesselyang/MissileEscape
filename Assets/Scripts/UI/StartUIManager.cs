using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Start UI scene manager.
/// Author: Mingxi Yang 104563133
/// </summary>

public class StartUIManager : MonoBehaviour {

    private GameObject m_StartPanel;
    private GameObject m_AuthorPanel;

    private GameObject button_Author;
    private GameObject button_Close;
    private GameObject button_Play;

    private void AuthorButtonClick(GameObject go)
    {
        Debug.Log("Author button clicked");
        if (m_AuthorPanel.activeSelf == false)
        {
            m_AuthorPanel.SetActive(true);
        }
    }

    private void CloseButtonClick(GameObject go)
    {
        m_AuthorPanel.SetActive(false);
    }

    private void PlayButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Game");
    }

    public void SetPlayButtonStatus(int status)
    {
        if (status == 1)
            button_Play.SetActive(true);
        else
            button_Play.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        m_StartPanel = GameObject.Find("StartPanel");
        m_AuthorPanel = GameObject.Find("AuthorPanel");

        button_Author = GameObject.Find("Author");
        button_Close = GameObject.Find("Close");
        button_Play = GameObject.Find("Play");

        UIEventListener.Get(button_Author).onClick = AuthorButtonClick;
        UIEventListener.Get(button_Close).onClick = CloseButtonClick;
        UIEventListener.Get(button_Play).onClick = PlayButtonClick;

        m_AuthorPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
    
	}
}
