using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public Toggle playStopButton;
    public Button nextButton;
    public Button previousButton;

    public AudioSource[] Songs;

    public GameObject playIcon;
    public GameObject pauseIcon;

    private int currentSongIndex = 0;

    void Start()
    {
        playStopButton.onValueChanged.AddListener(playOrStop);
        nextButton.onClick.AddListener(nextSong);
        previousButton.onClick.AddListener(previousSong);

        playOrStop(playStopButton.isOn);
        nextSong();
        previousSong();

        StopAllSongs();
        Songs[currentSongIndex].Play();
        playStopButton.isOn = false; // Playing
        playOrStop(false);
    }

    // Update is called once per frame
    void playOrStop(bool _pause)
    {
        if (_pause)
        {
            Songs[currentSongIndex].Pause();
            playIcon.SetActive(true);
            pauseIcon.SetActive(false);
        }
        else
        {
            Songs[currentSongIndex].Play();
            playIcon.SetActive(false);
            pauseIcon.SetActive(true);
        }
    }
    void nextSong()
    {
        Songs[currentSongIndex].Stop();
        currentSongIndex = (currentSongIndex + 1) % Songs.Length;
        Songs[currentSongIndex].Play();
        playStopButton.isOn = false; // Ensure play state is correct
        playOrStop(false);
    }
    void previousSong()
    {
        Songs[currentSongIndex].Stop();
        currentSongIndex = (currentSongIndex - 1 + Songs.Length) % Songs.Length;
        Songs[currentSongIndex].Play();
        playStopButton.isOn = false;
        playOrStop(false);
    }

    void StopAllSongs()
    {
        foreach (var song in Songs)
        {
            song.Stop();
        }
    }
}
