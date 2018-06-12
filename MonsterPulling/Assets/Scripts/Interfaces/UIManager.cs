using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    
    public FirstPersonController fps;
    private bool smartphoneActive;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetButtonDown("Smartphone"))
        {
            smartphoneActive = !smartphoneActive;
            fps.enabled = !smartphoneActive;
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = smartphoneActive;
        }
    }

   
}
