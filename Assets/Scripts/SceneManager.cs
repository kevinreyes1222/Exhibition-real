using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public SceneReference Scene;

    public void Cambiar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
    }
}
