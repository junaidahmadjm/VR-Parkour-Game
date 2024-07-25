using System;
using TMPro;
using UnityEngine;

public class ConcatStringToTMPInputField : MonoBehaviour
{
    public TMP_InputField tMP_InputField;
    public AudioSource Audiosource;
    public AudioClip audioClip;
    public GameObject KeyboardObject;
    public TMP_Text Displayname;

    private void OnEnable()
    {
        if(Displayname)
        {
            Displayname.gameObject.SetActive(false);
        }
    }
    public void Concat(String s)
    {
        var currentFieldString = tMP_InputField.text;
        var newFieldString = currentFieldString + s;
        tMP_InputField.text = newFieldString;

        Audiosource.clip = audioClip;
        PlayButtonSound();
    }

    public void Backspace()
    {
        var currentFieldString = tMP_InputField.text;
        if (currentFieldString.Length > 0)
        {
            var newFieldString = currentFieldString.Substring(0, currentFieldString.Length - 1);
            tMP_InputField.text = newFieldString;

            PlayButtonSound();
        }
    }

    private void PlayButtonSound()
    {
        if (audioClip != null && !Audiosource.isPlaying)
        {
            Audiosource.PlayOneShot(audioClip);
        }
    }

    public void SaveButton()
    {

        PlayerPrefs.SetString(Constants.DisplayName, tMP_InputField.text);
        Displayname.text = "Player Name: " + tMP_InputField.text;
        Displayname.gameObject.SetActive(true);
        KeyboardObject.SetActive(false);
        PlayButtonSound();

    }


}