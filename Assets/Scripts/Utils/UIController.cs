using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public LoadSceneHelper loadSceneHelper;
    public Button loadSceneButton;
    public TouchController playerMovementScript; //Substitua MonoBehaviour

    void Start()
    {

        if (loadSceneHelper == null)
        {
            Debug.LogError("LoadSceneHelper n�o est� atribu�do no Inspector.");
            return;
        }

        if (loadSceneButton == null)
        {
            Debug.LogError("LoadSceneButton n�o est� atribu�do no Inspector.");
            return;
        }

        if (playerMovementScript == null)
        {
            Debug.LogError("PlayerMovementScript n�o est� atribu�do no Inspector.");
            return;
        }


        //Desativa o sript de movimento do jogador no in�cio
        playerMovementScript.enabled = false;

        // Adiciona a fun��o Load com o �ndice da cena ao bot�o
        loadSceneButton.onClick.AddListener(() =>
        {
            playerMovementScript.enabled = true; //Ativa o script de movimento do jogador
            loadSceneHelper.Load(1); // Supondo que a cena com �ndice 1 seja a que voc� quer carregar
        });
    }    
}