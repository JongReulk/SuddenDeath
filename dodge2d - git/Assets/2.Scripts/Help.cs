using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public Text StartHelp;
    public Text SettingHelp;
    
    public Text ExitHelp;
    public GameObject OK;

    private Color StartColor;
    private Color SettingColor;
    
    private Color ExitColor;

    private Color alphacolor;

    // Start is called before the first frame update
    void Start()
    {
        alphacolor.a = 1;

        StartColor = StartHelp.color;
        SettingColor = SettingHelp.color;
        
        ExitColor = ExitHelp.color;

        StartColor.a = alphacolor.a;
        SettingColor.a = alphacolor.a;
        
        ExitColor.a = alphacolor.a;

    }


    // Update is called once per frame
    void Update()
    {
        Invoke("HelpStart", 2f);
        Invoke("HelpSetting", 4f);
        Invoke("HelpExit", 6f);
        Invoke("OKSet", 8f);
    }

    void HelpStart()
    {
        StartHelp.color = StartColor;
    }

    void HelpSetting()
    {
        SettingHelp.color = SettingColor;
    }
    

    void HelpExit()
    {
        ExitHelp.color = ExitColor;
    }

    void OKSet()
    {
        OK.SetActive(true);
    }

    public void ClickOnOK()
    {
        this.gameObject.SetActive(false);
    }
}
