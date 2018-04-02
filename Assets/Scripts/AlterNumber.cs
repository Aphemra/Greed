using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlterNumber : MonoBehaviour {

    public float numberToStartAt = 100.000f;
    public Text numberToDisplay;
    public float toAddPerFrame = 1;
    public bool isCurrency = false;

    public BigNumberFormatter bigNumberFormatter;

    private double number;
    
	void Start ()
    {
        number = numberToStartAt;

        numberToDisplay.text = bigNumberFormatter.Format(number, isCurrency);
	}
	
	void Update () {
        number += toAddPerFrame;
        numberToDisplay.text = bigNumberFormatter.Format(number, isCurrency);
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
