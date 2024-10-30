using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClickedFluff : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void OnButtonClicked()
    {
        SceneManager.LoadScene("CGScene1");
    }
}
