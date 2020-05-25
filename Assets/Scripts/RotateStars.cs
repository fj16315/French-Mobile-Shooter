using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStars : MonoBehaviour
{
  public float xSpeed;
  private float rotateX = 0.0f;

  private void Update()
  {
    rotateX += xSpeed;
    transform.localEulerAngles = new Vector3(0.0f, rotateX, 0.0f);
  }
}
