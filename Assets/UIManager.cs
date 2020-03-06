using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    public Text sliderText;
    public Text timeRemaining;

    public static UIManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {        
        timeRemaining.text = GameManager.instance.gameDuration.ToString();
    }

    public void OpenClose(GameObject go)
    {
        if(go.activeInHierarchy == true)
        {
            go.SetActive(false);
        }
        else
        {
            go.SetActive(true);
        }
    }

}
