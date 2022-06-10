using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHelp : MonoBehaviour
{
    public GameObject playerselectHelp;
    public GameObject player1selectHelp;
    public GameObject player2selectHelp;

    public GameObject getcoinHelp;

    public GameObject characterOKHelp;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("playerSelect", 2f);
        Invoke("player1Select", 4f);
        Invoke("player2Select", 6f);
        Invoke("GetCoin", 8f);
        Invoke("SetcharacterOK", 10f);


    }

    private void playerSelect()
    {
        playerselectHelp.SetActive(true);
    }

    private void player1Select()
    {
        player1selectHelp.SetActive(true);

    }

    void player2Select()
    {
        player2selectHelp.SetActive(true);
    }

    void GetCoin()
    {
        getcoinHelp.SetActive(true);

    }

    void SetcharacterOK()
    {
        characterOKHelp.SetActive(true);

    }

    public void ClickonCharacterOK()
    {
        this.gameObject.SetActive(false);
    }
}
