using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehaviour : MonoBehaviour
{
  public Animator buttonCanvasAnimator;

  public void ControlBehaviour(AnimatorStateInfo info)
  {
    if (info.IsName("Load In"))
    {
      buttonCanvasAnimator.SetTrigger("Fade In");
    }
    else if (info.IsName("Starting Game"))
    {
      buttonCanvasAnimator.SetTrigger("Fade Out");
    }
    else if (info.IsName("Load Next Scene"))
    {
      SceneManager.LoadScene("Main Game");
    }
  }
}
