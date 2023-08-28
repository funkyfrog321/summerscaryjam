using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public float startDelaySeconds = 2f;
    public FlickerLights flickerLights;
    public GameObject postProcessVolume;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(DelayedStart());
        flickerLights.GetComponent<Animation>().Play("Spooky");
        postProcessVolume.GetComponent<Animation>().Play("SpookyBloom");
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(startDelaySeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
