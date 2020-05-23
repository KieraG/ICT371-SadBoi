using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject window;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        window.SetActive(true);
        window.GetComponent<InformationScreen>().SetImageActive();
    }

}
