using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to create a slideshow with images
public class Slideshow : MonoBehaviour
{
    private Renderer m_Renderer;
    public List<Texture> Slides = new List<Texture>();

    [SerializeField]
    private int CurrentSlide = 0;

    //Changes the texture to the next image in the array
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

    //Changes the texture to the previous image in the array
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
    //Goes to the first slide
    public void FirstSlide()
    {
        CurrentSlide = 0;
        UpdateScreen();
    }

    //Adds a slide to the array
    public void AddSlide(Texture slideTexture)
    {
        Slides.Add(slideTexture);
    }

    //Adds a slide to the array at the given position
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
