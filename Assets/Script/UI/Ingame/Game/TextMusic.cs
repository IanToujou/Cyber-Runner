using TMPro;
using UnityEngine;

public class TextMusic : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI songText;
    [SerializeField] private TextMeshProUGUI artistText;

    private MusicManager musicManager;

    void Start() {
        musicManager = GameManager.GetMusicManager();
    }

    void Update() {
        if(!musicManager.IsPlaying()) {
            songText.text = "";
            artistText.text = "";
            return;
        }
        songText.text = musicManager.GetCurrentSongName();
        artistText.text = "By " + musicManager.GetCurrentSongArtist();
    }
    
}
