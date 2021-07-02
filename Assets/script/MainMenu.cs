using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    

    public GameObject MainMenuUI;
    public GameObject PanelTutorialUI;
    public GameObject PanelKesulitanUI;

    GameObject padleKiri;
    GameObject padleKanan;
    GameObject bola;

    Kontrol kiriProp;
    Kontrol kananProp;
    Bola bolaProp;
    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 0f;
        padleKiri  = GameObject.Find("kiri");
        padleKanan = GameObject.Find("kanan");
        bola       = GameObject.Find("bola");

        kiriProp  = padleKiri.GetComponent<Kontrol>();
        kananProp = padleKanan.GetComponent<Kontrol>();
        bolaProp = bola.GetComponent<Bola>();
    }
    public void PlayGame() {
        Debug.Log("Play Game");

        PanelKesulitanUI.SetActive(true);
    }

    public void HowToPlay() {
        Debug.Log("How To Play");
        PanelTutorialUI.SetActive(true);
    }

    public void QuitGame() {
         Debug.Log("Quit");
        Application.Quit();
    }

    public void Sulit() {
        kiriProp.kecepatan = 2.5f;
        bolaProp.kecepatan = 130;
        bolaProp.kesulitan = "sulit";
        MainMenuUI.SetActive(false);
        PanelKesulitanUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Mudah() {
        kiriProp.kecepatan = 10f;
        bolaProp.kecepatan = 100;
        bolaProp.kesulitan = "mudah";
        MainMenuUI.SetActive(false);
        PanelKesulitanUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
