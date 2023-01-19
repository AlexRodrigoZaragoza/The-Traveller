using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    [SerializeField] private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        float v;
        v = this.GetComponent<Slider>().value;
        _text.text = v.ToString("0");
        this.GetComponent<Slider>().onValueChanged.AddListener((v) => { _text.text = v.ToString("0"); });
    }
    void Update()
    {
    }
}
