using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    public int workaround = -1;

    // Start is called before the first frame update
    public void MuteToggle(bool muted)
    {
        workaround = workaround * -1;
        if (workaround == -1)
        {
            AudioListener.volume = 0;

            Debug.Log("UnityDebug Mute_Audio: " + "Muted");
        }
        else if (workaround == 1)
        {
            AudioListener.volume = 1;
            Debug.Log("UnityDebug Mute_Audio: " + "Unmuted");
        }
    }
}
