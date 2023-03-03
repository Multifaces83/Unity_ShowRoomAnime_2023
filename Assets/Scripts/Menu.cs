using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _validateButton;
    [SerializeField] private Input _topVideo1;
    [SerializeField] private Input _topVideo2;
    [SerializeField] private Input _topVideo3;
    private TouchScreenKeyboard keyboard;
    private Process _keyboard;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnValidateButtonClicked()
    {
        // Debug.Log("Validate button clicked");

    }
    public void OpenKeyboard()
    {

        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, false, false, false);
        launchKeyboard();
    }

    private void launchKeyboard()
    {
        if (_keyboard == null) _keyboard = Process.Start("osk.exe");
    }
}
