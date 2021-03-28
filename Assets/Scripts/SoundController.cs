using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private Button button;
    [SerializeField]
    private Sprite offSprite;
    [SerializeField]
    private Sprite onSprite;
    private int isPlay = 1;

    private void Start()
    {
        LoadGame();
        if (isPlay == 1)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        } 
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
    public void OffOnMusic()
    {
        if(isPlay == 1)
        {
            button.GetComponent<Image>().sprite = offSprite;
            music.Stop();
            isPlay = 0;
        }
        else if(isPlay == 0)
        {
            button.GetComponent<Image>().sprite = onSprite;
            music.Play();
            isPlay = 1;
        }
    }
   
    private void SaveGame()
    {
        PlayerPrefs.SetInt("SavedIsPlay", isPlay);
        PlayerPrefs.Save();
    }
    void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedIsPlay"))
        {
            isPlay = PlayerPrefs.GetInt("SavedIsPlay");
        }

    }
}
