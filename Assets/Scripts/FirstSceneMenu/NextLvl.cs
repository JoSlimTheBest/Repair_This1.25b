using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    public void SceneStart()
    {
        SceneManager.LoadScene(1);
    }
}
