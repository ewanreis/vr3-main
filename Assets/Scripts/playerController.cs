using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour
{   private float nextStateTimer;
    private int state;
    private string stateText;
    Animator anim;
    void Start() {
        int state = 0;
        nextStateTimer = 2;
        anim = GetComponent<Animator>();
    }  
    void LateUpdate() {
        ProcessStates();
    }
    void ProcessStates() {   
        nextStateTimer -= Time.deltaTime;
        switch(state) {  // State logic - switch states depending on what logic we want to apply
            case 0:
                Idle();
                if (nextStateTimer < 0) {   
                    state = 1;
                    nextStateTimer = 2;
                }
                break;
            case 1:
                Turn();
                if (nextStateTimer < 0) {   
                    state = 2;
                    nextStateTimer = 10;
                }
                break;
            case 2:
                Walk();
                if (nextStateTimer < 0) {
                    state = 0;
                    nextStateTimer = 5;
                }
                break;
            case 3:
                Run();
                if(nextStateTimer < 0) {
                    state = 0;
                    nextStateTimer = 5;
                }
                break;
        }
    }
    void Idle() {  // Different AI Update methods
        print("Idle");
        stateText = "Idle";
        anim.SetBool("walk", false);
    }
    void Turn() {
        print("Turn");
        stateText = "Turn";
    }
    void Walk() {
        anim.SetBool("walk", true);
        print("Walk");
        stateText = "Walk";
    }
    void Run() {
        print("Run");
        stateText = "Run";
    }
    void OnGUI() {
        string content = nextStateTimer.ToString(), state = stateText;
        GUILayout.Label($"<color='black'><size=40>State= {state}\n{content}</size></color>");
    }
}
