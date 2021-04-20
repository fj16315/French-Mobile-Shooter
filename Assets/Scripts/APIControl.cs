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
  private const string API_URL = "https://systran-systran-platform-for-language-processing-v1.p.rapidapi.com/translation/text/translate?source={0}&target={1}&input={2}";
  private string source;
  private string target;
  private const string API_KEY = "51456f48bbmsh3c8601094700b05p1a7cd3jsn746629439ed0";

  private void Awake()
  {
    var buttons = questionPopup.GetComponentsInChildren<Button>();
    answer1 = buttons[0].GetComponentInChildren<Text>();
    answer2 = buttons[1].GetComponentInChildren<Text>();
    answer1Correct = buttons[0].GetComponent<ButtonData>().isCorrect;
    answer2Correct = buttons[1].GetComponent<ButtonData>().isCorrect;
    source = "en";
    target = "fr";
  }

  private void SendRequest<T>(string url, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
  {
    StartCoroutine(RequestCoroutine(url, callbackOnSuccess, callbackOnFail));
  }

  private IEnumerator RequestCoroutine<T>(string url, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
  {
    var www = UnityWebRequest.Get(url);
    //www.SetRequestHeader("app_id", API_ID);
    www.SetRequestHeader("x-rapidapi-key", API_KEY);
    www.SetRequestHeader("x-rapidapi-host", "systran-systran-platform-for-language-processing-v1.p.rapidapi.com");
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
    Debug.Log(entry.outputs[0].output);
    question.text = entry.outputs[0].output;
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

    SendRequest(string.Format(API_URL, source, target, firstAnswer), callbackOnSuccess, callbackOnFail);
  }
}

[Serializable]
public class DictionaryResult
{
  public List<Output> outputs;
}

[Serializable]
public class Output
{
  public string output;
}
