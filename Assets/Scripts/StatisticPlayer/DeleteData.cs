using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteData : MonoBehaviour
{

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
    }
    private void Task()
    {
        PlayerPrefs.DeleteAll();
    }
}
