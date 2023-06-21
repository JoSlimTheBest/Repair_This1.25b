using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppliqationQuit : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
    }

    public void Task()
    {
        SceneManager.LoadScene(0);
    }
}
