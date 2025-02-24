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
            Debug.LogError("LoadSceneHelper não está atribuído no Inspector.");
            return;
        }

        if (loadSceneButton == null)
        {
            Debug.LogError("LoadSceneButton não está atribuído no Inspector.");
            return;
        }

        if (playerMovementScript == null)
        {
            Debug.LogError("PlayerMovementScript não está atribuído no Inspector.");
            return;
        }


        //Desativa o sript de movimento do jogador no início
        playerMovementScript.enabled = false;

        // Adiciona a função Load com o índice da cena ao botão
        loadSceneButton.onClick.AddListener(() =>
        {
            playerMovementScript.enabled = true; //Ativa o script de movimento do jogador
            loadSceneHelper.Load(1); // Supondo que a cena com índice 1 seja a que você quer carregar
        });
    }    
}