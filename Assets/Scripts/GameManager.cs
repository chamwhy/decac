using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CamMove cam;
    public GameObject player;

    public bool isStart = false;
    int score;
    int bestScore;

    public Animator[] startMenuAnim;
    public Animator[] endMenuAnim;
    public Animator[] changeMuneAnim;
    public Animator[] touchAnim;
    public Animator scoreAnim;

    private IEnumerator coroutine;
    public void StartBtn(){
        AnimTrigger("off", 0);
        AnimTrigger("on", 3);
        StartGame();
    }


    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isStart = true;
        score = 0;
        coroutine = AddScore();
        StartCoroutine(coroutine);
    }

    public void EndGame()
    {
        isStart = false;
        StopCoroutine(coroutine);
        cam.CloseUp();
        Invoke("EndAnim", 0.8f);
    }

    IEnumerator AddScore()
    {
        while (true)
        {
            score++;
            yield return new WaitForSeconds(0.5f);
        }

    }
    /* plus functions */

    private void EndAnim()
    {
        AnimTrigger("on", 1);
    }


    /* Game functions */
    public void AnimTrigger(string trigger, int type)
    {
        switch (type)
        {
            case 0:
                Trigger(startMenuAnim, trigger);
                break;
            case 1:
                Trigger(endMenuAnim, trigger);
                break;
            case 2:
                Trigger(changeMuneAnim, trigger);
                break;
            case 3:
                scoreAnim.SetTrigger(trigger);
                break;
        }
    }

    void Trigger(Animator[] anim, string trigger)
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetTrigger(trigger);
        }
    }


    public void TouchEffect(bool isRight)
    {
        if (isStart)
        {
            touchAnim[Convert.ToInt32(isRight)].SetTrigger("touch");
        }
    }


    /* buttons' event */

    

    public void PauseBtn(){

    }

    public void RestartBtn(){

    }

    public void HomeBtn(){

    }

    public void ChangeBtn(){

    }

    public void ArrowBtn(bool isRight){

    }

    public void SellectBtn(){

    }
}

