/*SimpleLocalizator plugin
 * Developed by NightLord189 (nldevelop.com)*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SimpleLocalizator
{
    
    [RequireComponent(typeof(TextMeshProUGUI))]
    
    public class MultiLangSimpleTextUI : MultiLangSimpleTextBase
    {

        TextMeshProUGUI _text;

        public TextMeshProUGUI text {
            get {
                if (_text == null)
                    _text = GetComponent<TextMeshProUGUI>();
                return _text;
            }
        }

        protected override void RefreshString(string str)
        {
            text.text = str;
        }
    }
}