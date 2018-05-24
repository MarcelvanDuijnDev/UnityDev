using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MathConverter : MonoBehaviour
{
    public string formula;

    public MonoScript[] scripts;
    int scriptAmount;

    [Header("Input Formula")]
    public string calculateFormula;

    [Header("Output Formula")]
    public float formulaOutput;

    public string[] formulaConvert1, formulaConvert2, formulaConvert3;

    bool comma;

    void Start()
    {
        formulaConvert1 = new string[formula.Length];
        CalculateFormula();
        formulaOutput = 10 * Mathf.PI / 2 + Mathf.Sqrt(100) + 80 * Mathf.PI;

        Debug.Log(Mathf.Tan(100));
    }

    void Update()
    {

    }

    public void CalculateFormula()
    {
        for (int i = 0; i < formula.Length; i++)
        {
            formulaConvert1[i] = formula[i].ToString();
        }
        GetNumbers1();
        GetNumbers2();
    }

    void GetNumbers1()
    {
        int check = 0;
        comma = false;
        for (int i = 0; i < formulaConvert1.Length; i++)
        {
            if (formulaConvert1[i] == "+") { formulaConvert2[check] += "+"; check += 1; }
            if (formulaConvert1[i] == "*") { formulaConvert2[check] += "*"; check += 1; }
            if (formulaConvert1[i] == "/") { formulaConvert2[check] += "/"; check += 1; }
            if (formulaConvert1[i] == "=") { formulaConvert2[check] += ""; check += 1; }
            if (formulaConvert1[i] == "√") { formulaConvert2[check] += "√"; check += 1; }
            if (formulaConvert1[i] == "π") { formulaConvert2[check] += "π"; check += 1; }

            if(formulaConvert1[i] == "t" && formulaConvert1[i + 1] == "a" && formulaConvert1[i + 2] == "t")
            {
                formulaConvert2[check] += ".";
            }

            if (formulaConvert1[i] == "0" || formulaConvert1[i] == "1" || formulaConvert1[i] == "2" || formulaConvert1[i] == "3" || formulaConvert1[i] == "4" || formulaConvert1[i] == "5" || formulaConvert1[i] == "6" || formulaConvert1[i] == "7" || formulaConvert1[i] == "8" || formulaConvert1[i] == "9")
            {
                string addToFormula = "";
                for (int o = i; o < formulaConvert1.Length; o++)
                {
                    if (formulaConvert1[o] == "," || formulaConvert1[o] == "0" || formulaConvert1[o] == "1" || formulaConvert1[o] == "2" || formulaConvert1[o] == "3" || formulaConvert1[o] == "4" || formulaConvert1[o] == "5" || formulaConvert1[o] == "6" || formulaConvert1[o] == "7" || formulaConvert1[o] == "8" || formulaConvert1[o] == "9")
                    {
                        if (formulaConvert1[o] != ",")
                        {
                            addToFormula += formulaConvert1[o].ToString();
                            formulaConvert2[check] += formulaConvert1[o].ToString();
                        }
                        else
                        {
                            formulaConvert2[check] += ".";
                            comma = true;
                        }
                    }
                    else
                    {
                        if(comma)
                        {
                            formulaConvert2[check] += "f";
                            comma = false;
                        }
                        i += o - i - 1;
                        check += 1;
                        break;
                    }
                }
            }

        }
    }

    void GetNumbers2()
    {
        for (int i = 0; i < formulaConvert2.Length; i++)
        {
            if (formulaConvert2[i] == "+") { formulaConvert3[i] += "+";}
            if (formulaConvert2[i] == "*") { formulaConvert3[i] += "*";}
            if (formulaConvert2[i] == "/") { formulaConvert3[i] += "/";}
            if (formulaConvert2[i] == "=") { formulaConvert3[i] += "";}

            string addToFormula1 = "";
            if (formulaConvert2[i] == "π")
            {
                formulaConvert3[i] += "Mathf.PI";
            }
            if (formulaConvert2[i] == "√")
            {
                formulaConvert3[i] += "Mathf.Sqrt(";
                for (int o = i + 1; o < formulaConvert2.Length; o++)
                {
                    string addToFormula2 = "";
                    if (formulaConvert2[o].Contains(".") || formulaConvert2[o].Contains("0") || formulaConvert2[o].Contains("1") || formulaConvert2[o].Contains("2") || formulaConvert2[o].Contains("3") || formulaConvert2[o].Contains("4") || formulaConvert2[o].Contains("5") || formulaConvert2[o].Contains("6") || formulaConvert2[o].Contains("7") || formulaConvert2[o].Contains("8") || formulaConvert2[o].Contains("9"))
                    {
                        addToFormula2 += formulaConvert2[o].ToString();
                        formulaConvert3[i] += formulaConvert2[o].ToString();
                    }
                    else
                    {
                        formulaConvert3[i] += ")";
                        i += 1;
                        break;
                    }
                }
            }
            else
            {
                if (formulaConvert2[i].Contains(".") || formulaConvert2[i].Contains("0") || formulaConvert2[i].Contains("1") || formulaConvert2[i].Contains("2") || formulaConvert2[i].Contains("3") || formulaConvert2[i].Contains("4") || formulaConvert2[i].Contains("5") || formulaConvert2[i].Contains("6") || formulaConvert2[i].Contains("7") || formulaConvert2[i].Contains("8") || formulaConvert2[i].Contains("9"))
                {
                    addToFormula1 += formulaConvert2[i].ToString();
                    formulaConvert3[i] += formulaConvert2[i].ToString();
                }
            }
        }
        for (int i = 0; i < formulaConvert3.Length; i++)
        {
            calculateFormula += formulaConvert3[i];
        }

    }
}


