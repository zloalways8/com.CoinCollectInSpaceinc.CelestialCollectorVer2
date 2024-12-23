using System;
using UnityEngine;

public class JumpCanvasCollector : MonoBehaviour
{
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

    public void JumpCollector(string destinationCollector)
    {
        CounterCollector();
        GameObject.Find("MainCameraCollector").GetComponent<SoundManagerCollector>().PlayClickCollector();
        GameObject.Find("MainCameraCollector").GetComponent<CanvasHolderCollector>().MoveCollector(destinationCollector,false);
    }

    public void JumpCollectorGame(int difCollector)
    {
       
        GameObject.Find("MainCameraCollector").GetComponent<SoundManagerCollector>().PlayClickCollector();
        GameObject.Find("MainCameraCollector").GetComponent<CanvasHolderCollector>().MoveCollector("gameCollector", false,difCollector);
        CounterCollector();
    }


    public void JumpBackCollector()
    {
        CounterCollector();
        GameObject.Find("MainCameraCollector").GetComponent<SoundManagerCollector>().PlayClickCollector();
    
        GameObject.Find("MainCameraCollector").GetComponent<CanvasHolderCollector>().MoveBackCollector();
        CounterCollector();
    }

    public void CloseCollector()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
        CounterCollector();
    }
}
