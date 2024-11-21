using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeButtonThng : MonoBehaviour
{

   
    public void CityDestroyer()
    {

    SceneManager.LoadScene("CityDestroy");

    }

    public void FactoryDestroyer()
    {
        SceneManager.LoadScene("FactoryDestroy");
    }
}




