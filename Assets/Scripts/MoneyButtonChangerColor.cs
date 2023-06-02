
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyButtonChangerColor : MonoBehaviour
{
    public TextMeshProUGUI b1;
    public TextMeshProUGUI b2;

    private Color take = new Color(0,1,0,1);
    private Color untake = new Color(1,1,1,0.5f);
    public TMP_FontAsset invert;
    public TMP_FontAsset usual;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Take);
    }

    private void Take()
    {
        b1.font = usual;
        b2.font = usual;
        GetComponentInChildren<TextMeshProUGUI>().font = invert;
    }

    public void AllColorDisable()
    {
        b1.font = usual;
        b2.font = usual;
        GetComponentInChildren<TextMeshProUGUI>().font = usual;
    }
}
