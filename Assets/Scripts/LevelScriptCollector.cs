using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelScriptCollector : MonoBehaviour
{

    public int openLevelsCollector = 1;


    private Tuple<double, bool> CounterCollector(double numberCollector = 1.3)
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
    public void OpenALevelCollector()
    {
        openLevelsCollector++;
        CounterCollector(2);
    }


    public void ActivateButtonsCollector()
    {
        CounterCollector(2);
        for (int iCollector = 1; iCollector < 16; iCollector++)
        {
            if (iCollector <= openLevelsCollector) GameObject.Find("LevelButtonCollector" + iCollector).GetComponent<Button>().interactable = true;
            else GameObject.Find("LevelButtonCollector" + iCollector).GetComponent<Button>().interactable = false;
        }
        CounterCollector();
    }




}
