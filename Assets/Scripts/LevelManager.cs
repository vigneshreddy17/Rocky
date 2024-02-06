using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static LevelManager instance;

    public float waitToLoad = 5f;

    public string nextLevel;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LevelEnd()
    {
        AudioManager.audioManager.PlayVictoryMusic();
        yield return new WaitForSeconds(waitToLoad);

        SceneManager.LoadScene(nextLevel);
    }
}
