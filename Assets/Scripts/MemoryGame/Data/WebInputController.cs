using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebInputController : MonoBehaviour
{
    private string _value;
    public string Value => _value;

    public void ReceiveFromJS(string inputValue)
    {
        Debug.Log("Received from JavaScript: " + inputValue);
        _value = inputValue;
    }
}
