using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMoney : MonoBehaviour
{
    [Header("Button")]
    public Button characterButton13;
    public Button characterButton14;
    public Button characterButton15;
    public Button characterButton16;
    public Button characterButton17;
    public Button characterButton18;
    public Button characterButton19;

    [Header("Image")]
    public Image EnableCharacter13;
    public Image EnableCharacter14;
    public Image EnableCharacter15;
    public Image EnableCharacter16;
    public Image EnableCharacter17;
    public Image EnableCharacter18;
    public Image EnableCharacter19;

    [Header("CoinShow")]
    public GameObject needMoney13;
    public GameObject needMoney14;
    public GameObject needMoney15;
    public GameObject needMoney16;
    public GameObject needMoney17;
    public GameObject needMoney18;
    public GameObject needMoney19;

    private int coin;
    private int isPurchased13;
    private int isPurchased14;
    private int isPurchased15;
    private int isPurchased16;
    private int isPurchased17;
    private int isPurchased18;
    private int isPurchased19;

    private Color tempColor13;
    private Color tempColor14;
    private Color tempColor15;
    private Color tempColor16;
    private Color tempColor17;
    private Color tempColor18;
    private Color tempColor19;

    // Start is called before the first frame update
    void Start()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        

        isPurchased13 = PlayerPrefs.GetInt("isPurchased13", 0);
        isPurchased14 = PlayerPrefs.GetInt("isPurchased14", 0);
        isPurchased15 = PlayerPrefs.GetInt("isPurchased15", 0);
        isPurchased16 = PlayerPrefs.GetInt("isPurchased16", 0);
        isPurchased17 = PlayerPrefs.GetInt("isPurchased17", 0);
        isPurchased18 = PlayerPrefs.GetInt("isPurchased18", 0);
        isPurchased19 = PlayerPrefs.GetInt("isPurchased19", 0);

        //var tempColor0;

        tempColor13 = EnableCharacter13.color;
        tempColor14 = EnableCharacter14.color;
        tempColor15 = EnableCharacter15.color;
        tempColor16 = EnableCharacter16.color;
        tempColor17 = EnableCharacter17.color;
        tempColor18 = EnableCharacter18.color;
        tempColor19 = EnableCharacter19.color;
        

        if (coin >= 10)
        {

            if (isPurchased13 == 0)
            {
                //characterButton13.interactable = false;
                tempColor13.a = 0.5f;
                EnableCharacter13.color = tempColor13;

            }



            if (isPurchased14 == 0)
            {
                //characterButton14.interactable = false;
                tempColor14.a = 0.5f;
                EnableCharacter14.color = tempColor14;

            }


            if (isPurchased15 == 0)
            {
                //characterButton15.interactable = false;
                tempColor15.a = 0.5f;
                EnableCharacter15.color = tempColor15;

            }


            if (isPurchased16 == 0)
            {
                //characterButton16.interactable = false;
                tempColor16.a = 0.5f;
                EnableCharacter16.color = tempColor16;

            }


            if (isPurchased17 == 0)
            {
                //characterButton17.interactable = false;
                tempColor17.a = 0.5f;
                EnableCharacter17.color = tempColor17;

            }


            if (isPurchased18 == 0)
            {
                //characterButton18.interactable = false;
                tempColor18.a = 0.5f;
                EnableCharacter18.color = tempColor18;

            }


            if (isPurchased19 == 0)
            {
                //characterButton19.interactable = false;
                tempColor19.a = 0.5f;
                EnableCharacter19.color = tempColor19;

            }



        }

        if (coin < 10)
        {
            if (isPurchased13 == 0)
            {
                characterButton13.interactable = false;
                tempColor13.a = 0.5f;
                EnableCharacter13.color = tempColor13;

            }
            if (isPurchased13 == 1)
            {
                needMoney13.SetActive(false);
                //characterButton13.interactable = true;
                //tempColor13.a = 1f;
                //EnableCharacter13.color = tempColor13;
            }


            if (isPurchased14 == 0)
            {
                characterButton14.interactable = false;
                tempColor14.a = 0.5f;
                EnableCharacter14.color = tempColor14;

            }
            if (isPurchased14 == 1)
            {
                needMoney14.SetActive(false);
                //characterButton14.interactable = true;
                //tempColor14.a = 1f;
                //EnableCharacter14.color = tempColor14;
            }

            if (isPurchased15 == 0)
            {
                characterButton15.interactable = false;
                tempColor15.a = 0.5f;
                EnableCharacter15.color = tempColor15;

            }
            if (isPurchased15 == 1)
            {
                needMoney15.SetActive(false);
                //characterButton15.interactable = true;
                //tempColor15.a = 1f;
                //EnableCharacter15.color = tempColor15;
            }

            if (isPurchased16 == 0)
            {
                characterButton16.interactable = false;
                tempColor16.a = 0.5f;
                EnableCharacter16.color = tempColor16;

            }
            if (isPurchased16 == 1)
            {
                needMoney16.SetActive(false);
                //characterButton16.interactable = true;
                //tempColor16.a = 1f;
                //EnableCharacter16.color = tempColor16;
            }

            if (isPurchased17 == 0)
            {
                characterButton17.interactable = false;
                tempColor17.a = 0.5f;
                EnableCharacter17.color = tempColor17;

            }
            if (isPurchased17 == 1)
            {
                needMoney17.SetActive(false);
                //characterButton17.interactable = true;
                //tempColor17.a = 1f;
                //EnableCharacter17.color = tempColor17;
            }

            if (isPurchased18 == 0)
            {
                characterButton18.interactable = false;
                tempColor18.a = 0.5f;
                EnableCharacter18.color = tempColor18;

            }
            if (isPurchased18 == 1)
            {
                needMoney18.SetActive(false);
                //characterButton18.interactable = true;
                //tempColor18.a = 1f;
                //EnableCharacter18.color = tempColor18;
            }

            if (isPurchased19 == 0)
            {
                characterButton19.interactable = false;
                tempColor19.a = 0.5f;
                EnableCharacter19.color = tempColor19;

            }
            if (isPurchased19 == 1)
            {
                needMoney19.SetActive(false);
                //characterButton19.interactable = true;
                //tempColor19.a = 1f;
                //EnableCharacter19.color = tempColor19;
            }


        }



    }

    // Update is called once per frame
    void Update()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        StartCoroutine(ChangeCharacterEnable());
        



    }
    IEnumerator ChangeCharacterEnable()
    {
        isPurchased13 = PlayerPrefs.GetInt("isPurchased13");
        isPurchased14 = PlayerPrefs.GetInt("isPurchased14");
        isPurchased15 = PlayerPrefs.GetInt("isPurchased15");
        isPurchased16 = PlayerPrefs.GetInt("isPurchased16");
        isPurchased17 = PlayerPrefs.GetInt("isPurchased17");
        isPurchased18 = PlayerPrefs.GetInt("isPurchased18");
        isPurchased19 = PlayerPrefs.GetInt("isPurchased19");
        coin = PlayerPrefs.GetInt("Coin", 0);

        if (coin < 10)
        {
            if (isPurchased13 == 0)
            {
                characterButton13.interactable = false;
                tempColor13.a = 0.5f;
                EnableCharacter13.color = tempColor13;

            }
            if (isPurchased13 == 1)
            {
                needMoney13.SetActive(false);
                characterButton13.interactable = true;
                tempColor13.a = 1f;
                EnableCharacter13.color = tempColor13;
            }


            if (isPurchased14 == 0)
            {
                characterButton14.interactable = false;
                tempColor14.a = 0.5f;
                EnableCharacter14.color = tempColor14;

            }
            if (isPurchased14 == 1)
            {
                needMoney14.SetActive(false);
                characterButton14.interactable = true;
                tempColor14.a = 1f;
                EnableCharacter14.color = tempColor14;
            }

            if (isPurchased15 == 0)
            {
                characterButton15.interactable = false;
                tempColor15.a = 0.5f;
                EnableCharacter15.color = tempColor15;

            }
            if (isPurchased15 == 1)
            {
                needMoney15.SetActive(false);
                characterButton15.interactable = true;
                tempColor15.a = 1f;
                EnableCharacter15.color = tempColor15;
            }

            if (isPurchased16 == 0)
            {
                characterButton16.interactable = false;
                tempColor16.a = 0.5f;
                EnableCharacter16.color = tempColor16;

            }
            if (isPurchased16 == 1)
            {
                needMoney16.SetActive(false);
                characterButton16.interactable = true;
                tempColor16.a = 1f;
                EnableCharacter16.color = tempColor16;
            }

            if (isPurchased17 == 0)
            {
                characterButton17.interactable = false;
                tempColor17.a = 0.5f;
                EnableCharacter17.color = tempColor17;

            }
            if (isPurchased17 == 1)
            {
                needMoney17.SetActive(false);
                characterButton17.interactable = true;
                tempColor17.a = 1f;
                EnableCharacter17.color = tempColor17;
            }

            if (isPurchased18 == 0)
            {
                characterButton18.interactable = false;
                tempColor18.a = 0.5f;
                EnableCharacter18.color = tempColor18;

            }
            if (isPurchased18 == 1)
            {
                needMoney18.SetActive(false);
                characterButton18.interactable = true;
                tempColor18.a = 1f;
                EnableCharacter18.color = tempColor18;
            }

            if (isPurchased19 == 0)
            {
                characterButton19.interactable = false;
                tempColor19.a = 0.5f;
                EnableCharacter19.color = tempColor19;

            }
            if (isPurchased19 == 1)
            {
                needMoney19.SetActive(false);
                characterButton19.interactable = true;
                tempColor19.a = 1f;
                EnableCharacter19.color = tempColor19;
            }


        }

        if (coin >= 10)
        {
            characterButton13.interactable = true;
            characterButton14.interactable = true;
            characterButton15.interactable = true;
            characterButton16.interactable = true;
            characterButton17.interactable = true;
            characterButton18.interactable = true;
            characterButton19.interactable = true;

            if (isPurchased13 == 0)
            {
                //characterButton13.interactable = false;
                characterButton13.interactable = true;
                tempColor13.a = 0.5f;
                EnableCharacter13.color = tempColor13;

            }



            if (isPurchased14 == 0)
            {
                //characterButton14.interactable = false;
                characterButton13.interactable = true;
                tempColor14.a = 0.5f;
                EnableCharacter14.color = tempColor14;

            }


            if (isPurchased15 == 0)
            {
                //characterButton15.interactable = false;
                characterButton13.interactable = true;
                tempColor15.a = 0.5f;
                EnableCharacter15.color = tempColor15;

            }


            if (isPurchased16 == 0)
            {
                //characterButton16.interactable = false;
                characterButton13.interactable = true;
                tempColor16.a = 0.5f;
                EnableCharacter16.color = tempColor16;

            }


            if (isPurchased17 == 0)
            {
                //characterButton17.interactable = false;
                characterButton13.interactable = true;
                tempColor17.a = 0.5f;
                EnableCharacter17.color = tempColor17;

            }


            if (isPurchased18 == 0)
            {
                //characterButton18.interactable = false;
                characterButton13.interactable = true;
                tempColor18.a = 0.5f;
                EnableCharacter18.color = tempColor18;

            }


            if (isPurchased19 == 0)
            {
                //characterButton19.interactable = false;
                characterButton13.interactable = true;
                tempColor19.a = 0.5f;
                EnableCharacter19.color = tempColor19;

            }

            if (isPurchased13 == 1)
            {
                needMoney13.SetActive(false);
                characterButton13.interactable = true;
                tempColor13.a = 1f;
                EnableCharacter13.color = tempColor13;
            }



            if (isPurchased14 == 1)
            {
                needMoney14.SetActive(false);
                characterButton14.interactable = true;
                tempColor14.a = 1f;
                EnableCharacter14.color = tempColor14;
            }


            if (isPurchased15 == 1)
            {
                needMoney15.SetActive(false);
                characterButton15.interactable = true;
                tempColor15.a = 1f;
                EnableCharacter15.color = tempColor15;
            }


            if (isPurchased16 == 1)
            {
                needMoney16.SetActive(false);
                characterButton16.interactable = true;
                tempColor16.a = 1f;
                EnableCharacter16.color = tempColor16;
            }


            if (isPurchased17 == 1)
            {
                needMoney17.SetActive(false);
                characterButton17.interactable = true;
                tempColor17.a = 1f;
                EnableCharacter17.color = tempColor17;
            }


            if (isPurchased18 == 1)
            {
                needMoney18.SetActive(false);
                characterButton18.interactable = true;
                tempColor18.a = 1f;
                EnableCharacter18.color = tempColor18;
            }


            if (isPurchased19 == 1)
            {
                needMoney19.SetActive(false);
                characterButton19.interactable = true;
                tempColor19.a = 1f;
                EnableCharacter19.color = tempColor19;
            }
        }

        yield return new WaitForSeconds(0.5f);
    }

    public void ClickOnPayCharacter13()
    {
        if(coin >=10)
        {
            if (isPurchased13 == 0)
            {
                PlayerPrefs.SetInt("isPurchased13", 1);
                needMoney13.SetActive(false);
                coin = coin - 10;
                PlayerPrefs.SetInt("Coin", coin);

                
                
            }
            else
            {
                Debug.Log("Already Purchased");
            }
        }
        else
            print("not enough money");
    }

    public void ClickOnPayCharacter14()
    {
        if (coin >= 10)
        {
            if (isPurchased14 == 0)
            {
                PlayerPrefs.SetInt("isPurchased14", 1);
                needMoney14.SetActive(false);
                coin = coin - 10;
                PlayerPrefs.SetInt("Coin", coin);
            }
            else
            {
                Debug.Log("Already Purchased");
            }
        }
        else
            print("not enough money");
    }

    public void ClickOnPayCharacter15()
    {
        if (coin >= 10)
        {
            if (isPurchased15 == 0)
            {
                PlayerPrefs.SetInt("isPurchased15", 1);
                needMoney15.SetActive(false);
                coin = coin - 10;
                PlayerPrefs.SetInt("Coin", coin);
                
            }
            else
            {
                Debug.Log("Already Purchased");
            }
        }
        else
            print("not enough money");
    }

    public void ClickOnPayCharacter16()
    {
        if (coin >= 10)
        { 
            if (isPurchased16 == 0)
            {
                PlayerPrefs.SetInt("isPurchased16", 1);
                needMoney16.SetActive(false);
                coin = coin - 10;
                PlayerPrefs.SetInt("Coin", coin);
            }
            else
            {
                Debug.Log("Already Purchased");
            }
        }
        else
            print("not enough money");
    }

    public void ClickOnPayCharacter17()
    {
        if (coin >= 10)
        {
            if (isPurchased17 == 0)
            {
                PlayerPrefs.SetInt("isPurchased17", 1);
                needMoney17.SetActive(false);
                coin = coin - 10;
                PlayerPrefs.SetInt("Coin", coin);
            }
            else
            {
                Debug.Log("Already Purchased");
            }
        }
        else
            print("not enough money");
    }

    public void ClickOnPayCharacter18()
    {
        if (coin >= 10)
        {
            if (isPurchased18 == 0)
            {
                PlayerPrefs.SetInt("isPurchased18", 1);
                needMoney18.SetActive(false);
                coin = coin - 10;
                PlayerPrefs.SetInt("Coin", coin);
            }
            else
            {
                Debug.Log("Already Purchased");
            }
        }
        else
            print("not enough money");
    }

    public void ClickOnPayCharacter19()
    {
        if (coin >= 10)
        {
            if (isPurchased19 == 0)
            {
                PlayerPrefs.SetInt("isPurchased19", 1);
                needMoney19.SetActive(false);
                coin = coin - 10;
                PlayerPrefs.SetInt("Coin", coin);
            }
            else
            {
                Debug.Log("Already Purchased");
            }
        }
        else
            print("not enough money");
    }
}
