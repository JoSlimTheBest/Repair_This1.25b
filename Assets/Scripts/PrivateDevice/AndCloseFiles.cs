using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndCloseFiles : MonoBehaviour
{
    public MouseControll mc;
    public PrivateScreen2 ps2;
    public PrivateScreen3 pc3;
    public FilesScreenHolder fsh;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
    }
    public void Task()
    {
        fsh.DestroyAll();
        mc.OpenMouse();
        ps2.Desrtoing();
        pc3.CloseAll();
       
    }
}
