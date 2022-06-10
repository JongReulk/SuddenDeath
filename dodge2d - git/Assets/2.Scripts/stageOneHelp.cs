using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageOneHelp : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public GameObject third;

    [Header("First")]
    public GameObject oneP;
    public GameObject twoP;

    [Header("Second")]
    public GameObject PlayerHelp1;
    public GameObject PlusHelp;
    public GameObject Bullet1;
    public GameObject equal1;
    public GameObject FailedHelp;

    [Header("Third")]
    public GameObject HelpGameMode;
    public GameObject PassEqual;
    public GameObject PassHelp;
    public GameObject StageHelpOK;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetFirst", 1f); Invoke("SetOneP", 2f); Invoke("SettwoP", 6f); Invoke("OffFirst", 8f);
        Invoke("SetSecond", 8f); Invoke("SetPlayerHelp1", 9f); Invoke("SetPlusHelp", 11f); Invoke("SetBullet1", 13f);
        Invoke("Setequal1", 15f); Invoke("SetFailedHelp", 17f); Invoke("OffSecond", 19f);
        Invoke("Setthird", 19f); Invoke("SetHelpGameMode", 20f); Invoke("SetPassEqual", 23f); Invoke("SetPassHelp", 25f);
        Invoke("SetStageHelpOK", 28f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetFirst()
    {
        first.SetActive(true);
    }

    void OffFirst()
    {
        first.SetActive(false);
    }

    void SetSecond()
    {
        second.SetActive(true);

    }
    void OffSecond()
    {
        second.SetActive(false);
    }

    void Setthird()
    {
        third.SetActive(true);
    }

    void SetOneP()
    {
        oneP.SetActive(true);
    }

    void SettwoP()
    {
        twoP.SetActive(true);
    }

    void SetPlayerHelp1()
    {
        PlayerHelp1.SetActive(true);
    }

    void SetPlusHelp()
    {
        PlusHelp.SetActive(true);
    }

    void SetBullet1()
    {
        Bullet1.SetActive(true);

    }

    void Setequal1()
    {
        equal1.SetActive(true);
    }

    void SetFailedHelp()
    {
        FailedHelp.SetActive(true);
    }

    void SetHelpGameMode()
    {
        HelpGameMode.SetActive(true);

    }

    void SetPassEqual()
    {
        PassEqual.SetActive(true);
    }

    void SetPassHelp()
    {
        PassHelp.SetActive(true);
    }

    void SetStageHelpOK()
    {
        StageHelpOK.SetActive(true);
    }

    public void ClickOnStageHelpOK()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
