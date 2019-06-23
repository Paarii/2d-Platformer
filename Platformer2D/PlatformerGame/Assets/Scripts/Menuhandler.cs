using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menuhandler : MonoBehaviour
{
    
    public bool Jumping = false;
    public bool Moving = false;
    public Button button;
    public GameObject selctionMenu;
    public void OnJumpClick()
    {
        Jumping = true;
        button.interactable = false;
        
    }
    public void OnMoveClick()
    {
        Moving = true;
    }

    public void OnContinueClick()
    {
        selctionMenu.SetActive(false);
    }

}
