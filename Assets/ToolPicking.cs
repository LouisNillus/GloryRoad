using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPicking : MonoBehaviour
{
    [DrawScriptable]
    public Weapon currentWeapon;

    public static ToolPicking instance;

    public List<ToolSlot> allTools = new List<ToolSlot>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeUseState()
    {
        foreach(ToolSlot ts in allTools)
        {
            if(ts.weapon != currentWeapon && ts.isBought == true)
            {
                ts.buttonText.text = "USE";
                ts.buttonText.color = Color.white;
                ts.isSelected = false;
            }
        }
    }
}
