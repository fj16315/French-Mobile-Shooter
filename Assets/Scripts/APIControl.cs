using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIControl : MonoBehaviour
{
  public GameObject questionPopup;
  public Text question;
  private Text answer1;
  private Text answer2;
  private bool answer1Correct;
  private bool answer2Correct;

  public List<string> answers;
  private const string API_URL = "https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang={2}";
  private string lang;
  private const string API_KEY = "trnsl.1.1.20200522T203236Z.cba72e47fbec75d1.90e97c15148467f5dde43aa46f8c95bf4e246263";

  private void Awake()
  {
    var buttons = questionPopup.GetComponentsInChildren<Button>();
    answer1 = buttons[0].GetComponentInChildren<Text>();
    answer2 = buttons[1].GetComponentInChildren<Text>();
    answer1Correct = buttons[0].GetComponent<ButtonData>().isCorrect;
    answer2Correct = buttons[1].GetComponent<ButtonData>().isCorrect;
    lang = "en-fr";
  }

  private void SendRequest<T>(string url, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
  {
    StartCoroutine(RequestCoroutine(url, callbackOnSuccess, callbackOnFail));
  }

  private IEnumerator RequestCoroutine<T>(string url, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
  {
    var www = UnityWebRequest.Get(url);
    //www.SetRequestHeader("app_id", API_ID);
    //www.SetRequestHeader("app_key", API_KEY);
    yield return www.SendWebRequest();
    if (www.isNetworkError || www.isHttpError)
    {
      Debug.LogError(www.error);
      callbackOnFail?.Invoke(www.error);
    }
    else
    {
      Debug.Log(www.downloadHandler.text);
      ParseResponse(www.downloadHandler.text, callbackOnSuccess, callbackOnFail);
    }
  }

  private void ParseResponse<T>(string data, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
  {
    var parsedData = JsonUtility.FromJson<T>(data);
    callbackOnSuccess?.Invoke(parsedData);
  }

  private void APICallSucceed(DictionaryResult entry)
  {
    Debug.Log(entry.text[0]);
    question.text = entry.text[0];
  }

  private void APICallFailed(string errorMessage)
  {
    Debug.Log("Failed");
    Debug.LogError(errorMessage);
  }

  public void GetEntry()
  {
    GetEntryRequest(APICallSucceed, APICallFailed);
  }

  private void GetEntryRequest(UnityAction<DictionaryResult> callbackOnSuccess, UnityAction<string> callbackOnFail)
  {
    int randomWord = UnityEngine.Random.Range(0, answers.Count);
    string firstAnswer = answers[randomWord];
    string secondAnswer = firstAnswer;

    while (firstAnswer == secondAnswer)
    {
      randomWord = UnityEngine.Random.Range(0, answers.Count);
      secondAnswer = answers[randomWord];
    }

    if (UnityEngine.Random.Range(0, 1) == 0)
    {
      answer1.text = firstAnswer;
      answer2.text = secondAnswer;
      answer1Correct = true;
      answer2Correct = false;
    }
    else
    {
      answer1.text = secondAnswer;
      answer2.text = firstAnswer;
      answer1Correct = false;
      answer2Correct = true;
    }

    SendRequest(string.Format(API_URL, API_KEY, firstAnswer, lang), callbackOnSuccess, callbackOnFail);
  }
}

[Serializable]
public class DictionaryResult
{
  public List<string> text;
}
