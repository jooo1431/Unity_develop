using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class IntroControl : MonoBehaviour {


    bool change = false;
    int startTimeMin;
    int setTime;
    int curHour;
    int remainder;
    int timer;
    bool timeup;

    SoundManager sound;
    float r_speed = 2f;
    Material[] sky;

    IEnumerator StartTimer()
    {
        startTimeMin = DateTime.Now.Minute;
        remainder = 60 - startTimeMin; //현재시간에서 정각까지 남은시간   
       // StartCoroutine(Timer());
        yield return StartCoroutine(Timer());
        yield return StartCoroutine(StartTimer()); //다시 타이머시작
    }

    IEnumerator Timer()
    {
        while ( remainder < 0)
        {
            remainder--;
            yield return new WaitForSeconds(60f); //1분마다 타이머 깍아
        }

        //timeup = true;
        //StartCoroutine(TimeCheck());
        ChangeSKy();
    }
   
	// Use this for initialization
	void Start ()
    {
        sky = Resources.LoadAll<Material>("Intro");
        ChangeSKy();//들어온시각 받아서하늘바꿈
       // startTimeMin = DateTime.Now.Minute;
        StartCoroutine(StartTimer());

        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sound.PlaySingle(sound.IntroBgm,true);
       // Debug.Log(DateTime.Now.Hour.ToString());
       
	}

    void ChangeSKy()
    {
        curHour = DateTime.Now.Hour;

        if (0 <= curHour && curHour < 7)
            RenderSettings.skybox = sky[0];
        else if(7 <= curHour && curHour < 14)
            RenderSettings.skybox = sky[1];
        else if (14 <= curHour && curHour < 17)
            RenderSettings.skybox = sky[2];
        else if (17 <= curHour && curHour < 20)
            RenderSettings.skybox = sky[3];
        else if (20 <= curHour )
            RenderSettings.skybox = sky[4];
    }
	
	// Update is called once per frame
	void Update ()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * r_speed);

    }
}
