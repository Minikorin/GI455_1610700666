using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMatch : MonoBehaviour
{
    public Text inputText;
    public Text resultText;

    public void Start()
    {
        resultText.text = "status: ";
    }

    public void CheckText()
    {
        if (inputText.text == "Nathamon")
        {
            resultText.text = inputText.text + " is found";

        }
        else if (inputText.text == "Mean")
        {
            resultText.text = inputText.text + " is found";

        }
        else if (inputText.text == "GI455")
        {
            resultText.text = inputText.text + " is found";

        }
        else if (inputText.text == "Network")
        {
            resultText.text = inputText.text + " is found";

        }
        else if (inputText.text == "Cat")
        {
            resultText.text = inputText.text + " is found";

        }
        else if (inputText.text == "Computer")
        {
            resultText.text = inputText.text + " is found";

        }
        else if (inputText.text != "Nathamon" || inputText.text != "Mean"|| inputText.text != "GI455"||
        inputText.text != "Network"||inputText.text != "Cat"||inputText.text != "Computer")
        {

            resultText.text = inputText.text + "  is not found";
        }
        
       
    }
}
