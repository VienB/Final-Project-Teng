using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderForMusic : MonoBehaviour
{
    private Slider backgroundMusicSlider;
    private AudioSource backgroundMusicSource;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusicSlider = GetComponent<Slider>();
        backgroundMusicSource = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMusicSource.volume = backgroundMusicSlider.value;
    }
}
