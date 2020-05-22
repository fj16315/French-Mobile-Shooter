using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public float duration = 60.0f;
  public Text display;

  private void Start()
  {
    display.text = string.Format("Time Remaining: {0} seconds", duration.ToString("F2"));
  }

  private void Update()
  {
    duration -= Time.deltaTime;

    if (duration < 0)
    {
      duration = 0.00f;
    }

    display.text = string.Format("Time Remaining: {0} seconds", duration.ToString("F2"));
  }
}
