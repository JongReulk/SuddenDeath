using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    private float color;
    private Image ChangeColorImage;
    private float time;
    private float changetime = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        //color = 0f;
        ChangeColorImage = GetComponent<Image>();
        //ChangeColorImage.color = new Color(1f, 0f, 1f);
        //GetComponent<Image>().color = new Color(1f, 0f, 1f);
        //ChangeColorImage = new Color(255, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeColorImage = new Color(color, 0f, 1f);
        //StartCoroutine(ChangeColor());
        time += Time.deltaTime;

        if(time > changetime)
        {
            ChangeColorImage.color = new Color(color, 1f, 0);

            if (color == 0f)
            {
                color = 1f;
            }

            else
            {
                color = 0f;
            }
            time = 0;
        }
    }

    IEnumerator ChangeColor()
    {
        ChangeColorImage.color = new Color(color, 1f, 0);
        
        yield return new WaitForSeconds(3f);

        if (color == 0f )
        {
            color = 1f;
        }

        else
        {
            color = 0f;
        }

        

    }
}

