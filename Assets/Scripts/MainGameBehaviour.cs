﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameBehaviour : MonoBehaviour
{
  public Animator introPopup;
  public Animator questionPopup;
  public Animator answerPopup;
  public GameObject answerObject;
  public GameObject questionObject;
  public Animator timePopup;
  public Text scoreText;
  private int score = 0;
  private Timer timer;

  private void Awake()
  {
    timer = GetComponent<Timer>();
  }

  public void ControlBehaviour(AnimatorStateInfo info)
  {
    if (info.IsName("Loading In"))
    {
      introPopup.SetTrigger("Fade In");
    }
    else if (info.IsName("Close Popup"))
    {
      introPopup.SetTrigger("Fade Out");
    }
    else if (info.IsName("Load Question"))
    {
      timer.startTimer = true;
      questionObject.GetComponent<QuestionPopupControl>().isUsable = true;
      Camera.main.GetComponent<APIControl>().GetEntry();
      questionPopup.SetTrigger("Fade In");
    }
    else if (info.IsName("Right Answer"))
    {
      questionObject.GetComponent<QuestionPopupControl>().isUsable = false;
      answerObject.GetComponentInChildren<TextMeshProUGUI>().text = "Right Answer";
      IncrementScore();
      answerPopup.SetTrigger("Fade In");
    }
    else if (info.IsName("Wrong Answer"))
    {
      questionObject.GetComponent<QuestionPopupControl>().isUsable = false;
      answerObject.GetComponentInChildren<TextMeshProUGUI>().text = "Wrong Answer";
      answerPopup.SetTrigger("Fade In");
    }
    else if (info.IsName("Fade Question"))
    {
      questionPopup.SetTrigger("Fade Out");
    }
    else if (info.IsName("Fade Answer"))
    {
      answerPopup.SetTrigger("Fade Out");
    }
    else if (info.IsName("Timed Out"))
    {
      questionObject.GetComponent<QuestionPopupControl>().isUsable = false;
      timePopup.SetTrigger("Fade In");
    }
    else if (info.IsName("Load Menu"))
    {
      questionObject.GetComponent<QuestionPopupControl>().isUsable = true;
      SceneManager.LoadScene("Start Menu");
    }
  }

  private void IncrementScore()
  {
    score++;
    scoreText.text = string.Format("Score: {0}", score);
  }
}
