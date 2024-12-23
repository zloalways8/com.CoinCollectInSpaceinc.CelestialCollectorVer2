
using System;
using UnityEngine;

public class SoundManagerCollector : MonoBehaviour
{
    public AudioSource themeCollector;
    public AudioSource pingCollector;
    public AudioSource clickCollector;
    public AudioSource boomCollector;

    public bool soundIsOnCollector = true;
    public bool musicIsOnCollector = true;

    public float soundSoundLevelCollector = 1f;
    public float musicSoundLevelCollector = 1f;
    public bool changedCollector = false;


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


    void Start()
    {
       
        themeCollector.Play();
        CounterCollector();
    }

    public void PlayPingCollector()
    {
        CounterCollector();
        pingCollector.Play();
    }

    public void PlayClickCollector()
    {
        CounterCollector();
        clickCollector.Play();
        CounterCollector();
    }

    public void PlayBoomCollector()
    {
        CounterCollector();
        boomCollector.Play();
        CounterCollector();
    }



    void Update()
    {

        if (GameObject.Find("SoundOnButtonCollector").GetComponent<ButtonComponentCollector>().currentStateCollector){
            soundSoundLevelCollector = 1.0f;
        }
        else soundSoundLevelCollector = 0;


        if (GameObject.Find("MusicOnButtonCollector").GetComponent<ButtonComponentCollector>().currentStateCollector)
        {
            musicSoundLevelCollector = 1.0f;
        }
        else musicSoundLevelCollector = 0;

            pingCollector.volume = soundSoundLevelCollector;
            clickCollector.volume = soundSoundLevelCollector;
            boomCollector.volume = soundSoundLevelCollector;
            themeCollector.volume = musicSoundLevelCollector;
 
        

     if(!themeCollector.isPlaying)
        {
            themeCollector.Play();
            CounterCollector();
        }
    }


}
