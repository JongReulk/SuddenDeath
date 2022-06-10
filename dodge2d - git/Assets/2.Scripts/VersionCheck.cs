using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionCheck : MonoBehaviour
{
    public string URL = ""; // 버전체크를 위한 URL
    public string CurVersion; // 현재 빌드버전
    string latestVersion; // 최신버전
    public GameObject newVersionAvailable; // 버전확인 UI
    private bool isCancel;

    void Start()
    {
        isCancel = false;
        StartCoroutine(LoadTxtData(URL));
    }

    public void CheckVersion()
    {
        if (CurVersion != latestVersion)
        {
            newVersionAvailable.SetActive(true);
       
        }
        else
        {
            newVersionAvailable.SetActive(false);
        }
        Debug.Log("Current Version" + CurVersion + "Lastest Version" + latestVersion);
    }


    IEnumerator LoadTxtData(string url)
    {
        WWW www = new WWW(url);
        yield return www; // 페이지 요청

        latestVersion = www.text; // 웹에 입력된 최신버전
        
        CheckVersion();
    }

    public void OpenURL(string url) // 스토어 열기
    {
        Application.OpenURL(url);
    }

    public void ClickOnDownloadNow()
    {
        OpenURL("https://play.google.com/store/apps/details?id=com.nsrstudio.suddendeath");
    }

    public void ClickOnCancle()
    {
        newVersionAvailable.SetActive(false);
    }
}
