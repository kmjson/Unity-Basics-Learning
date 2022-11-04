using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    public GameObject Player;

    [SerializeField]
    Text codeText;
    string codeTextValue = "";

    private bool allowed = true;

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue.Length >= 2)
        {
            if (codeTextValue != "79" && codeTextValue !="YES")
            {
                codeTextValue = "XXX";
                Destroy(Player);
            }
            else
            {
                allowed = false;
                codeTextValue = "YES";
            }
        }
    }

    public void AddDigit(string digit)
    {
        if (allowed)
        {
            codeTextValue += digit;
        }
    }
}
