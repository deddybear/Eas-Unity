using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    GameObject bola;
    GameObject padleKiri;
    GameObject padleKanan;
    Bola bolaScript;
    Kontrol kiriProp;
    Kontrol kananProp;
    string[] listPower = {"Panjang", "Cepat", "Lambat"};

    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.Find("bola");
        padleKiri  = GameObject.Find("kiri");
        padleKanan = GameObject.Find("kanan");
        
        bolaScript = bola.GetComponent<Bola>();
        kiriProp  = padleKiri.GetComponent<Kontrol>();
        kananProp = padleKanan.GetComponent<Kontrol>();
    }

    // Update is called once per frame
    void Update()
    {    

    }

    public void effectPower(int statusPlayer, int indexRandom) {

        if (listPower[indexRandom] == "Panjang") {
            
            if (statusPlayer == 1 && kananProp.stackedBuff < 3) {
                padleKanan.transform.localScale += new Vector3(0, 2.5f, 0);
                kananProp.stackedBuff += 1;
            } else if (statusPlayer == 2 && kiriProp.stackedBuff < 3) {
                padleKiri.transform.localScale += new Vector3(0, 2.5f, 0);
                kiriProp.stackedBuff += 1;            
            }

        } else if (listPower[indexRandom] == "Cepat") {
            
            if (statusPlayer == 1 && kananProp.stackedBuff < 3) {
                kananProp.kecepatan += 2.5f;
                kananProp.stackedBuff += 1;
            } else if (statusPlayer == 2 && kiriProp.stackedBuff < 3) {
                kiriProp.kecepatan += 2.5f;
                kiriProp.stackedBuff += 1;  
            }

        } else if (listPower[indexRandom] == "Lambat") {
            
            if (statusPlayer == 1 && kananProp.stackedBuff < 3) {
                kananProp.kecepatan -= 2.5f;
                kananProp.stackedBuff += 1;
            } else if (statusPlayer == 2 && kiriProp.stackedBuff < 3) {
                kiriProp.kecepatan -= 2.5f;
                kiriProp.stackedBuff += 1;  
            }

        }
    }
}
