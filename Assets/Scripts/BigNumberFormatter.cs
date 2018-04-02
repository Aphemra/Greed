using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNumberFormatter : MonoBehaviour {
    
    private int formatIndex;
    private int numberSize;
    private string[] fullNameFormatSuffixes = new string[] { "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion", "Nonillion", "Decillion" };
    private string[] shortNameFormatSuffixes = new string[] { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "De" };
    
    public string currencyPrefix = "$";

    void Update()
    {
        formatIndex = GameMaster.GlobalFormatIndex;
    }

    public string Format (double toConvert, bool isCurrency)
    {
        double normalFormat = toConvert;
        double scientificFormat = toConvert;

        numberSize = 0;
        int scientificNotationExponent = 0;

        while(normalFormat >= 1000)
        {
            normalFormat /= 1000;
            numberSize++;
        }

        while(scientificFormat >= 10)
        {
            scientificFormat /= 10;
            scientificNotationExponent++;
        }

        switch (formatIndex)
        {
            case 0:
                return FormatHelper(normalFormat, " " + fullNameFormatSuffixes[numberSize], isCurrency);
            case 1:
                return FormatHelper(normalFormat, " " + shortNameFormatSuffixes[numberSize], isCurrency);
            case 2:
                return FormatHelper(scientificNotationExponent < 3 ? normalFormat : scientificFormat, scientificNotationExponent < 3 ? "" : "x10^" + scientificNotationExponent, isCurrency);
            default:
                Debug.Log("NoFormatError: No formatting selected. Check the BigNumberFormatter script.");
                return "ERROR";
        }
    } 

    private string FormatHelper(double toConvert, string suffix, bool isCurrency)
    {
        if (isCurrency)
            return string.Format(currencyPrefix + "{0:#,##0.00}{1}", toConvert, suffix);
        else
            return string.Format("{0:#,##0.00}{1}", toConvert, suffix);
    }
}
