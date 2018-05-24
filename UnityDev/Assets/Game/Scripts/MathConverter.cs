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
        formulaOutput = Mathf.Sqrt(51)+Mathf.Tan(65)/Mathf.PI-Mathf.Cos(54)*Mathf.Sin(6);

        Debug.Log("");
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
            if (formulaConvert1[i] == "-") { formulaConvert2[check] += "-"; check += 1; }
            if (formulaConvert1[i] == "*") { formulaConvert2[check] += "*"; check += 1; }
            if (formulaConvert1[i] == "/") { formulaConvert2[check] += "/"; check += 1; }
            if (formulaConvert1[i] == "=") { formulaConvert2[check] += ""; check += 1; }
            if (formulaConvert1[i] == "√") { formulaConvert2[check] += "√"; check += 1; }
            if (formulaConvert1[i] == "π") { formulaConvert2[check] += "π"; check += 1; }

            if(formulaConvert1[i] == "t" && formulaConvert1[i + 1] == "a" && formulaConvert1[i + 2] == "n")
            {
                formulaConvert2[check] += "tan";
                check += 1;
                Debug.Log("tan");
            }
            if(formulaConvert1[i] == "c" && formulaConvert1[i + 1] == "o" && formulaConvert1[i + 2] == "s")
            {
                formulaConvert2[check] += "cos";
                check += 1;
                Debug.Log("cos");
            }
            if(formulaConvert1[i] == "s" && formulaConvert1[i + 1] == "i" && formulaConvert1[i + 2] == "n")
            {
                formulaConvert2[check] += "sin";
                check += 1;
                Debug.Log("sin");
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
        bool checkSpecial = false;
        for (int i = 0; i < formulaConvert2.Length; i++)
        {
            if (formulaConvert2[i] == "+") { formulaConvert3[i] += "+";}
            if (formulaConvert2[i] == "-") { formulaConvert3[i] += "-";}
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
                        break;
                    }
                }
            }
            if (formulaConvert2[i] == "tan")
            {
                formulaConvert3[i] += "Mathf.Tan(";
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
                        break;
                    }
                }
            }
            if (formulaConvert2[i] == "cos")
            {
                formulaConvert3[i] += "Mathf.Cos(";
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
                        break;
                    }
                }
            }
            if (formulaConvert2[i] == "sin")
            {
                formulaConvert3[i] += "Mathf.Sin(";
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
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < formulaConvert3.Length; i++)
        {
            calculateFormula += formulaConvert3[i];
        }

    }
}


