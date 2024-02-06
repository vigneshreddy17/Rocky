using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController uIController;
    public Slider healthSlider;
    public Text healthText;

    public GameObject deathScreen;

    private void Awake()
    {
        uIController = this;
    }
    // Start is called before the first frame update
    void Start()
    {
     
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
