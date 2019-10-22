using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

// Show off all the Debug UI components.
public class ReceptionDialogMenu : MonoBehaviour
{
    bool inMenu;
    bool toVictim = true;
    private Text sliderText;

    private int victDialogueProgress = 0;
    private int trafDialogueProgress = 0;

    void Start()
    {
        DebugUIBuilder.instance.AddLabel("Who are you speaking to?");
        DebugUIBuilder.instance.AddRadio("Trafficker?", "group", delegate (Toggle t) { VictRadioPressed("Trafficker?", "Traf", t); });
        DebugUIBuilder.instance.AddRadio("Victim?", "group", delegate (Toggle t) { TrafRadioPressed("Victim?", "Vict", t); });
        DebugUIBuilder.instance.AddDivider();
        DebugUIBuilder.instance.AddLabel("What do you want to say?", DebugUIBuilder.DEBUG_PANE_RIGHT);
        DebugUIBuilder.instance.AddDivider(DebugUIBuilder.DEBUG_PANE_RIGHT);
        if (toVictim)
        {
            DebugUIBuilder.instance.AddButton("How are you related?", VictButtonPressed, DebugUIBuilder.DEBUG_PANE_RIGHT);
            DebugUIBuilder.instance.AddButton("Do you feel safe at home?", VictButtonPressed, DebugUIBuilder.DEBUG_PANE_RIGHT);
            DebugUIBuilder.instance.AddButton("Have you ever performed sexual acts for money?", VictButtonPressed, DebugUIBuilder.DEBUG_PANE_RIGHT);
            DebugUIBuilder.instance.AddButton("Do you have control over your papers and your money?", VictButtonPressed, DebugUIBuilder.DEBUG_PANE_RIGHT);
            DebugUIBuilder.instance.Show();
            
        }
        else
        {
            DebugUIBuilder.instance.AddButton("Are you the caretaker?", TrafButtonPressed, DebugUIBuilder.DEBUG_PANE_RIGHT);
            DebugUIBuilder.instance.AddButton("What happened to patient?", TrafButtonPressed, DebugUIBuilder.DEBUG_PANE_RIGHT);
            DebugUIBuilder.instance.AddButton("How are you related?", TrafButtonPressed, DebugUIBuilder.DEBUG_PANE_RIGHT);
            DebugUIBuilder.instance.AddButton("*Hand the trafficker a form to try and separate them*", TrafButtonPressed, DebugUIBuilder.DEBUG_PANE_RIGHT);
            DebugUIBuilder.instance.Show();
        }
        DebugUIBuilder.instance.Show();
        inMenu = true;
        
    }

    public void TogglePressed(Toggle t)
    {
        Debug.Log("Toggle pressed. Is on? " + t.isOn);
    }
    public void RadioPressed(string radioLabel, string group, Toggle t)
    {
        Debug.Log("Radio value changed: " + radioLabel + ", from group " + group + ". New value: " + t.isOn);
    }
    
    public void VictRadioPressed(string radioLabel, string group, Toggle t)
    {
        Debug.Log("Radio value changed: " + radioLabel + ", from group " + group + ". New value: " + t.isOn);
        toVictim = true;
    }

    public void TrafRadioPressed(string radioLabel, string group, Toggle t)
    {
        Debug.Log("Radio value changed: " + radioLabel + ", from group " + group + ". New value: " + t.isOn);
        toVictim = false;
    }

    public void SliderPressed(float f)
    {
        Debug.Log("Slider: " + f);
        sliderText.text = f.ToString();
    }

    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }

        
    }

    void VictButtonPressed()
    {
        victDialogueProgress++;
    }

    void TrafButtonPressed()
    {
        trafDialogueProgress++;
    }
    void LogButtonPressed()
    {
        Debug.Log("Button pressed");
    }
}
