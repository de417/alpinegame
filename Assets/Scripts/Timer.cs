using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public Text timerText;
	private float startTime;
	private bool AtBox = false;
	//private bool withAParts = false; //requires all parts to be there


    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if(AtBox)
		{
			return;
		}
        float t = Time.time - startTime;
		string minutes = ((int) t / 60).ToString();
		string seconds = (t % 60).ToString("f2");
		
		timerText.text = minutes + ":" + seconds;
    }
	
	public void Finish() {
		AtBox = true;
		timerText.color = Color.green;
		timerText.fontSize = 60;
	}
}
