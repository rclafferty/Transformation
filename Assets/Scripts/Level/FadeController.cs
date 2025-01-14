﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    GameObject fadeImage;
    GameObject fadeBackground;
    Image fadeImageIMG;
    //Image fadeBackgroundIMG;
    float i;
    //int x = 450;
    int x = 100;

    float fadeSeconds = 8f;

    // Use this for initialization
    void Start () {
        fadeImage = GameObject.Find("Fade");
        fadeImageIMG = fadeImage.GetComponent<Image>();
        Debug.Log("Fade is null? " + (fadeImage == null || fadeImageIMG == null));
        //fadeBackground = GameObject.Find("FadeBackground");
        //fadeBackgroundIMG = fadeImage.GetComponent<Image>();
        //Debug.Log("FadeBackground is null? " + (fadeBackground == null || fadeBackgroundIMG == null));
        i = 1.0f;

        StartCoroutine(Fade());
	}
	
	// Update is called once per frame
	void Update () {
        /*if (x > 0)
        {
            x--;
            return;
        }
        Color c = fadeImageIMG.color;
        c.a = i;
        fadeImageIMG.color = c;
        //fadeBackgroundIMG.color = c;
        i -= Time.deltaTime / 1.5f;

        if (i <= 0)
        {
            Destroy(fadeImage.gameObject);
            Destroy(GameObject.Find("Loading").gameObject);
            Destroy(this);
        }*/
	}

    IEnumerator Fade()
    {
        Debug.Log("Starting wait for fade");
        yield return new WaitForSeconds(fadeSeconds);

        Debug.Log("Starting fade");
        Color c = fadeImageIMG.color;
        c.a = i;

        while (i > 0.0f)
        {
            float deltaSec = 0.05f;
            yield return new WaitForSeconds(deltaSec);
            i -= deltaSec;

            c.a = i;
            fadeImageIMG.color = c;
        }

        Debug.Log("Done with fade");
        Destroy(fadeImage.gameObject);
        Destroy(GameObject.Find("Loading").gameObject);
        Destroy(this);
    }
}
