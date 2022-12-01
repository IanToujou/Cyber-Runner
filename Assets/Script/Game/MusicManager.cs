using UnityEngine;

public class MusicManager : MonoBehaviour {
    
    [SerializeField] private AudioClip[] songs;
    [SerializeField] private GameObject songText;

    private AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
        source.clip = songs[0];
        source.loop = true;
        source.Play();
    }

    public AudioClip[] GetSongs() {
        return songs;
    }

}
