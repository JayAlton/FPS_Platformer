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
public void Open() {
    gameObject.SetActive(true);
}
public void Close() {
    gameObject.SetActive(false);
    Cursor.lockState = CursorLockMode.Locked;
}
}
