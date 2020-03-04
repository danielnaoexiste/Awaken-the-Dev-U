using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string path) 
    {
        SceneManager.LoadScene(path);
    }

    public void OpenSocial(string social) {
        Application.OpenURL(social);
    }

    public void Quit() {
        Application.Quit();
    }
}
