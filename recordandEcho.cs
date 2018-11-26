using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections;

public class recordandEcho : MonoBehaviour {

    public Renderer rend;
    public AudioSource audioSource;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
        Debug.Log(Application.persistentDataPath);
    }

    public static void analyzeResponse(AudioClip clip)
    {

        float[] spectrum = new float[256];
        spectrum = clip.GetOutputData(128, 2);
        for (var i = 0; i < spectrum.Length; i++)
            print(spectrum.ToString());
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("start recording");
            rend.material.color = Color.green;
            //right now it always records for 10 sec
            audioSource.clip = Microphone.Start("", false, 10, 44100);
            //float[] samples = new float[audioSource.clip.samples * audioSource.clip.channels];
            //audioSource.clip.GetData(samples, 0);
            //Debug.Log("Samples before in Start: " + samples);
            //Debug.Log(samples.Length);

            //if(audioSource.clip != null)
            //{
            //    Debug.Log("audio source not null");
            //    for (int i = 0; i < samples.Length; ++i)
            //    {
            //        samples[i] = samples[i] * 0.5f;
            //        if (samples[i] != 0f)
            //        {
            //            Debug.Log(samples[i]);
            //        }

            //    }
            //    Debug.Log("Did we get any data?");

            //}

            


        }
        if (Input.GetKeyUp("r"))
        {
            Debug.Log("stop recording");
            rend.material.color = Color.red;
            audioSource.Play();
            saveAudiotoDisk.Save("testing", audioSource.clip);

            analyzeResponse(audioSource.clip);
        }
        
    }
  
    
     
    //public static ienumerator loadaudio()
    //{
       
    //    www www = new www("file://" + application.persistentdatapath + "testing.wav");
    //    yield return www; // code will wait till file is completely read
    //    clip = www.getaudioclip(false);
    //    clip.play();
        

        
    //}
}

