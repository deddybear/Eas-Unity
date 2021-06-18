using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rintangan : MonoBehaviour
{

    float batasAtas = 3.2f;
    float batasBawah = -3.4f;

    float gerak;
    string status;

    // Start is called before the first frame update
    void Start()
    {
        status = "down";
        
    }


    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > batasAtas) {
            status = "down";
        }

        if (transform.position.y < batasBawah) {
            status = "up";
        }
        
        if (status == "down") {
            gerak = -1 * Time.deltaTime;
        } 
        
        if (status == "up") {
            gerak = 1 * Time.deltaTime;
        }

        transform.Translate(0, gerak, 0);

    }
}
