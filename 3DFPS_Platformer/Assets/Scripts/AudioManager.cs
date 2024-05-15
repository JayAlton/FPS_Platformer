using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public float soundVolume {
        get {return AudioListener.volume;}
        set {AudioListener.volume = value;}
    }
    public bool soundMute {
        get {return AudioListener.pause;}
        set {AudioListener.pause = value;}
    }

    public ManagerStatus status {get; private set;}

    public void Startup() {
        Debug.Log("Audio manager starting ...");
        soundVolume = 1f;
        status = ManagerStatus.Started;
    }
}
