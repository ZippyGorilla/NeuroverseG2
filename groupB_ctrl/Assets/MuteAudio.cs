using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    public void MuteToggle(bool muted) {
        if (muted) {
            AudioListener.volume = 0;
        
        //Button 12 is 'Y'
        } else if (Input.GetButtonDown("Y_button")) { 
            if (muted == true) {
                MuteToggle(false);
            } else {
                AudioListener.volume = 0;
                muted = true;
            }
        } else {
            AudioListener.volume = 1;
        }
    }
}