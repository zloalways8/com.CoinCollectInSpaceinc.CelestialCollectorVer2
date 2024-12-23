using System;
using UnityEngine;
using UnityEngine.UI;

public class WinScriptCollector : MonoBehaviour
{
  
    public Text ScoreTxtCollector;
    public Text DifTxtCollector;
    public Text HpTxtCollector;
    public Text timeTxtCollector;
    public bool winCollector;

    private Tuple<double, bool> CounterCollector(double numberCollector = 1.2)
    {
        bool checkCollector = false;
        double resultCollector = numberCollector;
        if (numberCollector > Time.time)
        {
            checkCollector = true;
            resultCollector -= 25;
        }
        return Tuple.Create(resultCollector, checkCollector);
    }
    public void WinScreenCollector()
    {
        CounterCollector();
        ScoreTxtCollector.text = GameObject.Find("ScoreTextCollector").GetComponent<Text>().text;
        HpTxtCollector.text = GameObject.Find("HpTextCollector").GetComponent<Text>().text;
        timeTxtCollector.text = GameObject.Find("TimeTextCollector").GetComponent<Text>().text;
        if (winCollector ) 
        DifTxtCollector.text = GameObject.Find("LevelTextCollector").GetComponent<Text>().text+" COMPLETE";
        else DifTxtCollector.text = GameObject.Find("LevelTextCollector").GetComponent<Text>().text + " FAILED";
    }

}
