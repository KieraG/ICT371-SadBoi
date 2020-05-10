using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slideshow : MonoBehaviour
{
    private Renderer m_Renderer;
    public List<Texture> Slides = new List<Texture>();

    [SerializeField]
    private int CurrentSlide = 0;


    public void NextSlide()
    {
        if (CurrentSlide == Slides.Count - 1)
        {
            CurrentSlide = 0;
        }
        else
        {
            ++CurrentSlide;
        }

        UpdateScreen();

    }

    public void PreviousSlide()
    {
        if (CurrentSlide == 0)
        {
            CurrentSlide = Slides.Count - 1;
        }
        else
        {
            --CurrentSlide;
        }

        UpdateScreen();
    }

    public void FirstSlide()
    {
        CurrentSlide = 0;
        UpdateScreen();
    }

    public void AddSlide(Texture slideTexture)
    {
        Slides.Add(slideTexture);
    }

    public void AddSlide(Texture slideTexture, int position)
    {
        Slides.Insert(position, slideTexture);
    }

    private void UpdateScreen()
    {
        m_Renderer.material.SetTexture("_MainTex", Slides[CurrentSlide]);
    }

    // Start is called before the first frame update
    private void Start()
    {

        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.SetTexture("_MainTex", Slides[CurrentSlide]);

    }

    // Update is called once per frame
    private void Update()
    {

    }
}
