using UnityEngine;


/// <summary>
/// tutorial /https://www.youtube.com/watch?v=7GcEW6uwO8E
/// </summary>

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    /*public Sprite freeze;
    public Sprite heal;
    public Sprite shrink;*/

    public SpriteAsset[] sprites;
    [System.Serializable]
    public class SpriteAsset
    {
        public string name;
        public Sprite sprite;
    }

    public SoundAudioClip[] soundAudioClips;
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioclip;
        [Range(0, 1)]
        public float volume = 100;
    }

}
