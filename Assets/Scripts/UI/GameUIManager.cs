using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Game UI scene manager.
/// Author: Mingxi Yang 104563133
/// </summary>

public class GameUIManager : MonoBehaviour {

    //private GameObject m_GamePanel;
    private GameObject m_OverPanel;

    private UILabel label_Star;
    private UILabel label_Time;

    private GameObject m_ButtonControl;
    private GameObject button_Reset;

    private int time;

    //For OverPanel
    private UILabel over_Score;
    private UILabel over_StarValue;
    private UILabel over_TimeValue;

    public int Time
    {
        get { return time; }
        set
        {
            time = value; 
            //Debug.Log("Time:" + Time);
            UpdateTimerLabel(time);

        }
    }

    // Use this for initialization
	void Start () {
        //m_GamePanel = GameObject.Find("GamePanel");
        m_OverPanel = GameObject.Find("OverPanel");
        m_ButtonControl = GameObject.Find("ButtonControl");
        button_Reset = GameObject.Find("Reset");

        label_Star = GameObject.Find("GameStarValue").GetComponent<UILabel>();
	    label_Time = GameObject.Find("Timer").GetComponent<UILabel>();
        label_Star.text = "0";
	    label_Time.text = "0:00";

        //For OverPanel
	    over_Score = GameObject.Find("Score/ScoreValue").GetComponent<UILabel>();
	    over_StarValue = GameObject.Find("Star/OverStarValue").GetComponent<UILabel>();
	    over_TimeValue = GameObject.Find("Time/TimeValue").GetComponent<UILabel>();


	    StartCoroutine("TimeIncrease");

        UIEventListener.Get(button_Reset).onClick = ResetButtonClick;

        m_OverPanel.SetActive(false);
	}
	
    /// <summary>
    /// Update score shown in UI.
    /// </summary>
    /// <param name="score"></param>
    public void UpdateStarLabel(int score)
    {
        label_Star.text = score.ToString();
    }

    /// <summary>
    /// Update the time in game UI.
    /// </summary>
    /// <param name="time"></param>
    private void UpdateTimerLabel(int time)
    {
        if (time % 60 < 10)
        {
            label_Time.text = time / 60 + ":0" + time % 60;
        }
        else
        {
            label_Time.text = time / 60 + ":" + time % 60;
        }
    }

    public void ShowOverPanel()
    {

        m_ButtonControl.SetActive(false);
        m_OverPanel.SetActive(true);
        TimeStop();
        SetOverPanelInfo();
    }

    private void ResetButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Start");
    }

    /// <summary>
    /// Use coroutine to increase time in game scene.
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Time++;
        }
    }

    /// <summary>
    /// Stop the time increase coroutine.
    /// </summary>
    private void TimeStop()
    {
        StopCoroutine("TimeIncrease");
    }

    private void SetOverPanelInfo()
    {
        int star = int.Parse(label_Star.text);
        over_StarValue.text = "+" + star;
        over_TimeValue.text = "+" + Time.ToString();
        int temp_FinalScore = star + Time;
        over_Score.text = temp_FinalScore.ToString();

        //Save the new score to PlayerPrefs.
        PlayerPrefs.SetInt("Score", temp_FinalScore);
        //Save the star collected on this game to PlayerPrefs.
        PlayerPrefs.SetInt("Star", star);

    }
}
