using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Reader : MonoBehaviour {
	public float delay = 1000;
	public Text display;
	private int currentLine = 0;
	private int currentWord = 0;
	private string[] words;
	private float nextUpdate = 0;

	private string path = "Assets/ebooks/fairy-tales-by-the-brothers-grimm.txt";
	private StreamReader reader;

	// Use this for initialization
	void Start () {
		//Read the text from directly from the test.txt file
		Load();

	}

	void Load() {
		reader = new StreamReader(path); 
		string line = "";
		for(int i = 0; i <= currentLine; i++) {
			line = reader.ReadLine();
		}
		words = line.Split(' ');
		if(words.Length < currentWord) {
			currentWord = 0;
		}
		display.text = words[currentWord];
		schedule();
	}
		

	void nextLine() {
		currentLine++;
		currentWord = 0;
		string line = reader.ReadLine();
		words = line.Split(' ');
		display.text = words[currentWord];
	}

	void nextWord() {
		currentWord++;
		if(currentWord >= words.Length) {
			nextLine();
			return;
		}
		display.text = words[currentWord];
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.unscaledTime >= nextUpdate) {
			nextWord();
			schedule();
		}
	}

	void schedule() {
		nextUpdate = Time.unscaledTime + delay;
	}

	void Finalize() {		
		reader.Close();
	}
}
