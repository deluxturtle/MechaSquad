using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles the UI interactions in the two player game setup and
/// saves them to memory.
/// </summary>
public class SettingsTwoPlayerGame : MonoBehaviour
{
    [Tooltip("Drag into here for the mech limit option.")]
    public Slider mechLimitSlider;
    [Tooltip("Drag mech limit input field here.\n" +
            "Shows the updated number in the field as well.")]
    public InputField mechLimitInputField;

    
    /// <summary>
    /// Updates the input field after changing the slider.
    /// </summary>
    /// <param name="pValue">Value of the slider.</param>
    public void UpdatedMechLimitSlider()
    {
        mechLimitInputField.text = mechLimitSlider.value.ToString();
    }

    /// <summary>
    /// Updates the slider value when changing the input field.
    /// Note: Slider max and min control the input field max and min.
    /// </summary>
    /// <param name="pValue">Input field value.</param>
    public void UpdatedMechInputField()
    {
        int inputFieldValue = int.Parse(mechLimitInputField.text);
        Mathf.Clamp(
            inputFieldValue,
            mechLimitSlider.minValue, 
            mechLimitSlider.maxValue);
        mechLimitSlider.value = inputFieldValue;
    }
}
