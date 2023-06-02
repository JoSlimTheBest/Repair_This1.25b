using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDeleteButton : MonoBehaviour
{
    public GameObject currentmess;
    public MessageHolder mh;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
    }

    public void Task()
    {
        mh.DestroyMessage(currentmess);
        gameObject.SetActive(false);
    }
}
