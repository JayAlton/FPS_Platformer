using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
public void OnSoundToggle() {
    Managers.Audio.soundMute = !Managers.Audio.soundMute;
}
public void OnSoundVolume(float volume) {
    Managers.Audio.soundVolume = volume;
}
}
