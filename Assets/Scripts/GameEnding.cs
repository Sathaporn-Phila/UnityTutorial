using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour {
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageGroup;
    public bool m_IsPlayerAtExit;
    float m_timer;
    void Start() {
        
    }
    void Update() {
        if(m_IsPlayerAtExit){
            this.EndLevel();
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject == player){
            m_IsPlayerAtExit = true;
        }
    }
    void EndLevel(){
        m_timer += Time.deltaTime;
        exitBackgroundImageGroup.alpha = m_timer/fadeDuration;
        if(m_timer>fadeDuration + displayImageDuration){
            Application.Quit();
        }
    }
}