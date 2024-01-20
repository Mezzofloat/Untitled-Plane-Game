using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTalk : MonoBehaviour
{
    #region Variables
    [SerializeField] TMP_Text speech;
    [SerializeField] GameObject talkUI;
    [SerializeField] List<Transform> npcs = new();
    [SerializeField] string speechText = "The quick brown fox jumps over the lazy dog.";

    Transform talkToMe;
    bool isSpeechSetting;
    readonly WaitForSeconds delay = new(0.07f);
    #endregion

    IEnumerator SetSpeech() {
        isSpeechSetting = true;
        talkUI.SetActive(true);
        foreach (char c in speechText) {
            speech.text += c;
            yield return delay;
        }
        isSpeechSetting = false;
    }
    
    void OnInteract() {
        if (npcs.Count == 0) return;
        
        talkToMe = npcs[0];
        foreach (Transform npc in npcs)
        {
            if ((npc.position - transform.position).sqrMagnitude < (talkToMe.position - transform.position).sqrMagnitude) 
                talkToMe = npc;
        }

        PlayerTrade pt = gameObject.GetComponent<PlayerTrade>();

        StopAllCoroutines();
        if (isSpeechSetting) {
            speech.text = speechText;
            isSpeechSetting = false;
        } else if (talkUI.activeSelf) {
            talkUI.SetActive(false);
        } 
        
        if ((talkToMe.position - transform.position).sqrMagnitude < 1f) {          
            pt.OnTrade(talkToMe.gameObject, true);
            speech.text = "";
            StartCoroutine(nameof(SetSpeech));
        } else {
            pt.OnTrade(talkToMe.gameObject, false);
        }
    }
}