using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Text numbersLabel;
    public Text operatorLabel;
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

        /*  if (input == 0)
          {
              input = val;
          }
          else
          {
              secondInput = val;
          } */
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
        numbersLabel.text += $"{val}";
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