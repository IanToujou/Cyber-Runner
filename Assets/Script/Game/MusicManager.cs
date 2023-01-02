using UnityEngine;

public class MusicManager : MonoBehaviour {
    
    [SerializeField] private AudioClip[] songs;

    private AudioSource source;
    private AudioClip currentSong;
    private string currentSongName;
    private string currentSongArtist;

    void Start() {
        currentSong = null;
        PlaySong(1);
    }

    public void PlaySong(int song) {
        currentSong = songs[song];
        currentSongName = currentSong.name.Split(" - ")[1];
        currentSongArtist = currentSong.name.Split(" - ")[0];
        source = GetComponent<AudioSource>();
        source.clip = currentSong;
        source.loop = true;
        source.Play();
    }

    public void Stop() {
        currentSong = null;
        source = GetComponent<AudioSource>();
        source.Stop();
    }

    public AudioClip[] GetSongs() {
        return songs;
    }

    public AudioClip GetCurrentSong() {
        return currentSong;
    }

    public string GetCurrentSongName() {
        return currentSongName;
    }

    public string GetCurrentSongArtist() {
        return currentSongArtist;
    }

    public bool IsPlaying() {
        return (currentSong != null);
    }

}
