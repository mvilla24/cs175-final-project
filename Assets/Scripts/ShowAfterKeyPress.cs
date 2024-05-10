using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAfterKeyPress : MonoBehaviour
{
    public GameObject buttonMenu;
    public string keyName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(keyName))
        {
            ToggleObject();
        }
    }

    public void ToggleObject()
    {
        buttonMenu.SetActive(!buttonMenu.activeSelf);
        if (buttonMenu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
