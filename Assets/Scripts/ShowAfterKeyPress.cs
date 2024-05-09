using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAfterKeyPress : MonoBehaviour
{
    public GameObject buttonMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("m"))
        {
            HideObject();
        }
    }

    public void HideObject()
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
