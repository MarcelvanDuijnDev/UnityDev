using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MathConverter : MonoBehaviour
{
    public string formula;
    public string[] formulaConvert;

    public MonoScript[] scripts;
    int scriptAmount;

    [Header("Input Formula")]
    public string calculateFormula;

    [Header("Output Formula")]
    public float formulaOutput;

    public string[] checkAmount;

    bool comma;

    void Start ()
    {
        formulaConvert = new string[formula.Length];
        CalculateFormula();
        formulaOutput = Mathf.Sqrt(100);

        Object[] data = AssetDatabase.LoadAllAssetsAtPath("Assets");

        foreach (Object o in data)
        {
            Debug.Log(o);
        }
	}
	
	void Update () 
    {
		
	}

    public void CalculateFormula()
    {
        for (int i = 0; i < formula.Length; i++)
        {
            formulaConvert[i] = formula[i].ToString();
        }
        Formula1();
    }

    void Formula1()
    {
        int check = 0;
        for (int i = 0; i < formulaConvert.Length; i++)
        {
            if (formulaConvert[i] == "+"){checkAmount[check] += "+"; check += 1;}
            if (formulaConvert[i] == "="){checkAmount[check] += ""; check += 1;}

            if (formulaConvert[i] == "0" || formulaConvert[i] == "1" || formulaConvert[i] == "2" || formulaConvert[i] == "3" || formulaConvert[i] == "4" || formulaConvert[i] == "5" || formulaConvert[i] == "6" || formulaConvert[i] == "7" || formulaConvert[i] == "8" || formulaConvert[i] == "9")
            {
                string addToFormula = "";
                for (int o = i; o < formulaConvert.Length; o++) 
                {
                    if (formulaConvert[o] == "0" || formulaConvert[o] == "1" || formulaConvert[o] == "2" || formulaConvert[o] == "3" || formulaConvert[o] == "4" || formulaConvert[o] == "5" || formulaConvert[o] == "6" || formulaConvert[o] == "7" || formulaConvert[o] == "8" || formulaConvert[o] == "9")
                    {
                        addToFormula += formulaConvert[o].ToString();
                        checkAmount[check] += formulaConvert[o].ToString();
                    }
                    else
                    {
                        i += o - i - 1;
                        check += 1;
                        calculateFormula += addToFormula;
                        break;
                    }
                }
            }
        }    
    }

    void ConvertFormulaSigns()
    {
        for (int i = 0; i < formulaConvert.Length; i++)
        {
            if (formulaConvert[i] == "0"){calculateFormula += "0";}
            if (formulaConvert[i] == "1"){calculateFormula += "1";}
            if (formulaConvert[i] == "2"){calculateFormula += "2";}
            if (formulaConvert[i] == "3"){calculateFormula += "3";}
            if (formulaConvert[i] == "4"){calculateFormula += "4";}
            if (formulaConvert[i] == "5"){calculateFormula += "5";}
            if (formulaConvert[i] == "6"){calculateFormula += "6";}
            if (formulaConvert[i] == "7"){calculateFormula += "7";}
            if (formulaConvert[i] == "8"){calculateFormula += "8";}
            if (formulaConvert[i] == "9"){calculateFormula += "9";}
            if (formulaConvert[i] == "+"){calculateFormula += "+";}
            if (formulaConvert[i] == "*"){calculateFormula += "*";}
            if (formulaConvert[i] == "x"){calculateFormula += "*";}
            if (formulaConvert[i] == "."){calculateFormula += "*";}
            if (formulaConvert[i] == "%"){calculateFormula += "%";}
            if (formulaConvert[i] == "^"){calculateFormula += "^";}
            if (formulaConvert[i] == "÷"){calculateFormula += "÷";}
            if (formulaConvert[i] == "/"){calculateFormula += "/";}
            if (formulaConvert[i] == ","){calculateFormula += ".";}
            // if (formulaConvert[i] == "√"){calculateFormula += "√";} Mathf.Sqrt()
        }
    }
}
    