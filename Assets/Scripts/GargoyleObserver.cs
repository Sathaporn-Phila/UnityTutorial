using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleObserver : MonoBehaviour {
    public Transform player;
    public bool m_IsPlayerInRange;
    public GameEnding gameEnding;
    void Start(){

    }
    void Update(){
        if(m_IsPlayerInRange){
            Vector3 direction = player.position - transform.position + Vector3.up; //vector between gargoyle and john lemon
            Ray ray = new Ray (transform.position,direction); // line of sight to that vector direction
            RaycastHit raycastHit; //if hit something
            if(Physics.Raycast(ray,out raycastHit)){
                if(raycastHit.collider.transform == player){// line of sight hit the player,not the wall or floor; 
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.transform == player){
            m_IsPlayerInRange = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.transform == player){
            m_IsPlayerInRange = false;
        }
    }
}