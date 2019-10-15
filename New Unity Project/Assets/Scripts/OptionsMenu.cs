using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;

    public ResItem[] resolutions;

    public int selectedResolution;

    public Text resolutionLabel;

    // Start is called before the first frame update
    void Start()
    {
        // Here we set the initial values so that graphics settings persist
        fullscreenTog.isOn = Screen.fullScreen; // Setting the Fullscreen toggle button

        if(QualitySettings.vSyncCount == 0)     // Setting the vsync toggle button
        {
            vsyncTog.isOn = false;
        } else
        {
            vsyncTog.isOn = true;
        }

        bool foundRes = false;
        for(int i = 0; i < resolutions.Length; i++)   // Setting the resolution via a search in the array
        {
            // Search each resolution in the array to see if it matches the current resolution
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;        // Indicate that we've located the correct resolution
                selectedResolution = i; // Set the "selectedResolution" to the current value in the array
                UpdateResLabel();       // Update the label to reflect the correct resolution
            }
        }

        if(!foundRes) // If the resolution is not in the list... (i.e. user has a custom resolution)
        {
            resolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString(); // Set the label accordingly
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }

        UpdateResLabel();

    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Length - 1)
        {
           selectedResolution = resolutions.Length - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {

        // Apply vSync
        if(vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } else
        {
            QualitySettings.vSyncCount = 0;
        }

        // Apply resolution and set full screen on or off
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }
}

[System.Serializable] // This allow us to display this class back in the Unity editor
public class ResItem
{
    // This class will be used to set the in-game resolution
    public int horizontal, vertical;
}