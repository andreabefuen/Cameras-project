using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameView : MonoBehaviour {

    public GameObject panel;
    public Text timerText;
    public Text readyText;

    public GameObject initialPanel;

    private float timer;

	// Use this for initialization
	void Start () {
       
        readyText.enabled = false;
        initialPanel.SetActive(true);
        

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        timerText.text = "TIMER: " + (int) timer;


        if (Input.GetKeyDown(KeyCode.Space) && initialPanel.activeSelf == true)
        {
            //Time.timeScale = 1;
            initialPanel.SetActive(false);
        }

        if(timer >= 14 && timer <17)
        {
            readyText.enabled = true;
            readyText.text = "READY";
        }
        if(timer >= 17 && timer < 20)
        {
            readyText.text = "STEADY";
        }
        if (timer >= 20 && timer < 22)
        {
            readyText.text = "GO!";
        }
        if (timer >= 22)
        {
            readyText.enabled = false;
        }

        if (timer > 60f)
        {
            
            Debug.Log("Terminar juego");
            int aux = Application.loadedLevel + 1;
            Application.LoadLevel(aux);
        }
	}

    public void GetDamage()
    {
        panel.SetActive(true);
        Invoke("DisableDamage", 0.3f);

    }
    void DisableDamage()
    {
        panel.SetActive(false);
    }
}
