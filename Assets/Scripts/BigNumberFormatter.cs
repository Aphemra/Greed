using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNumberFormatter : MonoBehaviour {
    
    private int formatIndex;
    private int numberSize;
    private string[] fullNameFormatSuffixes = new string[] { "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion", "Nonillion", "Decillion" };
    private string[] shortNameFormatSuffixes = new string[] { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "De" };

    void Update()
    {
        formatIndex = GameMaster.GlobalFormatIndex;
    }

    public string format (double toConvert)
    {
        numberSize = 0;

        while( toConvert >= 1000)
        {
            toConvert /= 1000;
            numberSize++;
        }

        switch (formatIndex)
        {
            case 0:
                return format(toConvert, fullNameFormatSuffixes[numberSize]);
            case 1:
                return format(toConvert, shortNameFormatSuffixes[numberSize]);
            default:
                Debug.Log("NoFormatError: No formatting selected. Check the BigNumberFormatter script.");
                return "ERROR";
        }
    } 

    private string format(double toConvert, string suffix)
    {
        return string.Format("${0:#,##0.00} {1}", toConvert, suffix);
    }
}
