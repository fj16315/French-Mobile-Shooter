using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainGameBehaviour : MonoBehaviour
{
  public Animator introPopup;
  public Animator questionPopup;
  public Animator answerPopup;
  public GameObject answerObject;

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
      Camera.main.GetComponent<APIControl>().GetEntry();
      questionPopup.SetTrigger("Fade In");
    }
    else if (info.IsName("Right Answer"))
    {
      answerObject.GetComponentInChildren<TextMeshProUGUI>().text = "Right Answer";
      answerPopup.SetTrigger("Fade In");
    }
    else if (info.IsName("Wrong Answer"))
    {
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
  }
}
