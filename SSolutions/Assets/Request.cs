using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Request : MonoBehaviour
{
    public InputField city;
    public InputField date;
    public Text sunrise;
    public Text sunset;
    void Start()
    {
        if(PlayerPrefs.HasKey("city"))
        {
            city.text=PlayerPrefs.GetString("city");
        }
        if (PlayerPrefs.HasKey("date"))
        {
            date.text = PlayerPrefs.GetString("date");
        }
        city.Select();
        city.ActivateInputField();


}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Return))
            GoRequest();
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(city.isFocused)
            {
                date.Select();
                date.ActivateInputField();
            }
            else
            {
                city.Select();
                city.ActivateInputField();
            }
        }
    }
    public void GoRequest()
    {
        CheckFields();
        string request = "https://www.google.com/search?q=восход+солнца+" + city.text+"+" + date.text.Replace(' ', '+');
        StartCoroutine(GetRequest(request,sunrise,"Восход"));
         request = "https://www.google.com/search?q=закат+солнца+" + city.text + "+" + date.text.Replace(' ', '+');
        StartCoroutine(GetRequest(request, sunset,"Закат"));
    }

    private void CheckFields()
    {
        if (String.IsNullOrEmpty(city.text)) Bad(city); else PlayerPrefs.SetString("city",city.text);
        if (String.IsNullOrEmpty(date.text)) Bad(date); else PlayerPrefs.SetString("date",date.text);
    }

    private void Bad(InputField field)
    {
        field.image.color = Color.red;
    }

    IEnumerator GetRequest(string uri, Text outfield, string comment)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(pages[page] + ":\nReceived:\n "+ webRequest.downloadHandler.text);
                    Parse(webRequest.downloadHandler.text, outfield,comment);
                    break;
            }
        }
    }

    private void Parse(string text, Text outfield, string comment)
    {
        string s = text;
        string findstr = "BNeawe iBp4i AP7Wnd\">";
        
        
            int n = s.IndexOf(findstr);
            
            s = s.Substring(n+59,5);
            
        if (s == "><met")
        {
            Bad(city);Bad(date);
        }
        else
            outfield.text = comment+": "+s;
        
    }
    
}