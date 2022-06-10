using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHelp : MonoBehaviour
{

    public GameObject stagepassHelp;
    public GameObject stageidleHelp;
    public GameObject stagelockHelp;

    public GameObject characterHelp;
    public GameObject gamemodeHelp;
    public GameObject nextlevelHelp;
    public GameObject stagesettingHelp;

    public GameObject stageOKHelp;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("character", 2f);
        Invoke("gameMode", 4f);
        Invoke("stageUp", 6f);
        Invoke("stageSetting", 8f);
        Invoke("OK", 10f);


    }

    private void stagePass()
    {
        stagepassHelp.SetActive(true);
    }

    private void stageIdle()
    {
        stageidleHelp.SetActive(true);
        
    }

    void stageLock()
    {
        stagelockHelp.SetActive(true);   
    }
    
    void character()
    {
        characterHelp.SetActive(true);

    }

    void gameMode()
    {
        gamemodeHelp.SetActive(true);

    }

    void stageUp()
    {
        nextlevelHelp.SetActive(true);
    }

    void stageSetting()
    {
        stagesettingHelp.SetActive(true);
    }

    void OK()
    {
        stageOKHelp.SetActive(true);
    }

    public void ClickonStageOK()
    {
        this.gameObject.SetActive(false);
    }
}
