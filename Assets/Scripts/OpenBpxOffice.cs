using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBpxOffice : MonoBehaviour
{
    public GameObject BioImage;
    public BoxOffice box;

    public void Open()
    {
        BioImage.SetActive(true);
        box.OpenBoxOffice();
    }
}
