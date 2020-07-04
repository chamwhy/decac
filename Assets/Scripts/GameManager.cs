﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
TODO
-기본로직
-애니메이션
-데이터 처리
-반응
    1.시작
    2.홈
    3.다시시작
    4.설정
    5.
-

*/

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;




    private void Awake(){
        Debug.Log("Game Start!");
    }

    //1 default logic

    public void AddScore(int plus){
        score += plus;
    }

    IEnumerator ScoreLoop (){
        score += 1;
        yield return new WaitForSeconds(1f);
    }

    private void StartScoreLoop(){
        StartCoroutine(ScoreLoop());
    }
    //Btn Events
    public void StartGame(){
        Invoke("StartScoreLoop", 3f);
    }
    public void Respawn(){
        
    }
    public void Home(){
        
    }

    public void Change(){
        
    }

    public void PriviousBall(){

    }

    public void NextBall(){

    }
    //4 반응
    

    public void ClickBtnEvents(int type){
        switch (type) {
            case 0: //when 'start btn' is clicked
                break;

            case 1: //when 'respawn btn' is clicked
                break;

            case 2: //when 'home btn' is clicked
                break;

            case 3: //when 'change btn' is clicked
                break;

            case 4: //when 'leftArrow btn' is clicked
                break;

            case 5: //when 'rightArrow btn' is clicked
                break;

            case 6: //when 'select btn' is clicked
                break;

            default:
                break;
        }
    }
}