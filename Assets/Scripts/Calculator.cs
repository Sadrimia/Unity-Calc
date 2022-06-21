using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
   [SerializeField] private Text numbersLabel;
   [SerializeField] private Text operatorLabel;
    private float result;
    private float input;
    private string operation;
    private float secondInput;

    public void NumberClick(int val)
    {
        if (result == 0)
        {
            numbersLabel.text += $"{val}";
        }
        else
        {
            input = result;
            numbersLabel.text += $"{val}";
        }
    }

    public void OperationClick(string val)
    {
        float.TryParse(numbersLabel.text, out float NumbersLabelFloat);
        if (result == 0)
        {
            input = NumbersLabelFloat;
        }
        else
        {
            input = result;
        }

        operation = val;
        operatorLabel.text = val;
        numbersLabel.text = "";
    }

    public void EqualsClick(string val)
    {
        operatorLabel.text = "";
        float.TryParse(numbersLabel.text, out float NumbersLabelFloat);
        secondInput = NumbersLabelFloat;

        if (input != 0 && secondInput != 0 && !string.IsNullOrEmpty(operation))
        {
            switch (operation)
            {
                case "+":
                    result = input + secondInput;
                    break;
                case "-":
                    result = input - secondInput;
                    break;
                case "*":
                    result = input * secondInput;
                    break;
                case "/":
                    result = input / secondInput;
                    break;
            }
            numbersLabel.text = result.ToString();
        }
    }

    public void PeriodClick(string val)
    {
        if(numbersLabel.text.Contains(",") == false){
            numbersLabel.text += $"{val}";
        }else{
            Debug.Log("The comma is already there");
        }
    }

    public void ClearAll()
    {
        input = 0;
        secondInput = 0;
        result = 0;
        numbersLabel.text = "";
        operatorLabel.text = "";
    }
}