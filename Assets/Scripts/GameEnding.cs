using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour {
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    bool m_IsPlayerAtExit;
    bool m_isPlayerCaught;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    float m_timer;
    void Start() {
        
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject == player){
            m_IsPlayerAtExit = true;
        }
    }
    public void CaughtPlayer(){
        m_isPlayerCaught = true;
    }
    void Update() {
        if(m_IsPlayerAtExit){
            this.EndLevel(exitBackgroundImageCanvasGroup,false);
        }
        else if(m_isPlayerCaught){
            this.EndLevel(caughtBackgroundImageCanvasGroup,true);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup,bool doRestart){
        m_timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_timer/fadeDuration;
        if(m_timer>fadeDuration + displayImageDuration){
            if(doRestart){
                SceneManager.LoadScene(0);
            }
            else {
                Application.Quit();
            }
        }
    }
}