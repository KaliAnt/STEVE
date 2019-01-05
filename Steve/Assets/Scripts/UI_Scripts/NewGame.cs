using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	public Button newGame_;
	void Start () {
		Button btn = newGame_.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	void TaskOnClick()
	{
		SceneManager.LoadScene("GameScene");
	}	
}
