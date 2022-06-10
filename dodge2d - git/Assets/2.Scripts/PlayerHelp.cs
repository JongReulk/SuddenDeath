using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHelp : MonoBehaviour
{
    public Text OneHelp;
    public Text TwoHelp;
    public Text MultiHelp;
    
    public GameObject OK;

    private Color OneColor;
    private Color TwoColor;
    private Color MultiColor;
    

    private Color alphacolor;

    // Start is called before the first frame update
    void Start()
    {
        alphacolor.a = 1;

        OneColor = OneHelp.color;
        TwoColor = TwoHelp.color;
        MultiColor = MultiHelp.color;

        OneColor.a = alphacolor.a;
        TwoColor.a = alphacolor.a;
        MultiColor.a = alphacolor.a;

    }


    // Update is called once per frame
    void Update()
    {
        Invoke("HelpOne", 2f);
        Invoke("HelpTwo", 4f);
        Invoke("HelpMulti", 6f);
        Invoke("OKSet", 8f);
    }

    void HelpOne()
    {
        OneHelp.color = OneColor;
    }

    void HelpTwo()
    {
        TwoHelp.color = TwoColor;
    }

    void HelpMulti()
    {
        MultiHelp.color = MultiColor;
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
