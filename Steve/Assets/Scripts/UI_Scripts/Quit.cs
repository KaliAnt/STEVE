using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

	public Button quit_;
	void Start ()
	{
		Button myBtn = quit_.GetComponent<Button>();
		myBtn.onClick.AddListener (TaskOnClick);
	}
	
	void TaskOnClick()
	{
		if(EditorApplication.isPlaying == false)
			Application.Quit ();
	}
}
