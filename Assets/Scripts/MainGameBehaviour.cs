using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameBehaviour : MonoBehaviour
{
  public Animator introPopup;
  public Animator questionPopup;
  public Image leftButton;
  public Image rightButton;

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
      questionPopup.SetTrigger("Fade In");
    }
    else if (info.IsName("Right Answer"))
    {
      leftButton.color = Color.green;
    }
    else if (info.IsName("Wrong Answer"))
    {
      rightButton.color = Color.red;
    }
  }
}
