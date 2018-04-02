using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlterNumber : MonoBehaviour {

    public float numberToStartAt = 100.000f;
    public Text numberToDisplay;

    public BigNumberFormatter bigNumberFormatter;

    private double number;
    
	void Start ()
    {
        number = numberToStartAt;

        numberToDisplay.text = bigNumberFormatter.format(number);
	}
	
	void Update () {
        number++;
        numberToDisplay.text = bigNumberFormatter.format(number);
    }

    public void add(float numberToIncreaseBy)
    {
        number += numberToIncreaseBy;
    }

    public void subtract(float numberToDecreaseBy)
    {
        if (number - numberToDecreaseBy <= 0)
            return; // Notify player they can't do this

        number -= numberToDecreaseBy;
    }
}
