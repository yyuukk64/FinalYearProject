using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;  //custom editor programming


public class Turesure_Box : EditorWindow
{
	//attach scrips
	AnswerChecker answerChecker;
	CanvasController_Takara canvasController;

	// attributes for the new window
	string myString = "Hello World";
	public string ans = "0000";
	int PasswordLength = 4;

	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f; 

	// tabs attributes
	public int toolbarInt = 0;
	public string[] toolbarStrings = new string[] {"Turesure Box"};

	public GameObject takaraBox_4Digits;
	public GameObject takaraBox_5Digits;
	public GameObject takaraBox_6Digits;

	// Add menu name "My Window" to the Windom menu
	[MenuItem("Window/PasswordObjects")]
	static void Init()
	{
		// get exiting open window or if none, make a new one:
		Turesure_Box window = (Turesure_Box)EditorWindow.GetWindow(typeof(Turesure_Box));
		window.Show();
	}

	void OnGUI()
	{
		GUILayout.Label("Base Settings", EditorStyles.boldLabel);       // label
		myString = EditorGUILayout.TextField("Object Name", myString);   // input field
		ans = EditorGUILayout.TextField("Set Password - " + PasswordLength + " digits", ans);   // input field

		/*
		groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);  // toggle box
		myBool = EditorGUILayout.Toggle("Toggle", myBool);
		myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup();
		*/

		// tabs
		toolbarInt = GUILayout.Toolbar(toolbarInt, toolbarStrings);

		// drop down menu
		GUILayout.BeginHorizontal(EditorStyles.toolbar);

		// draw something
		DrawToolStrip();
		EditorGUILayout.EndHorizontal();

	}

	void DrawToolStrip()
	{
		if (GUILayout.Button("Create...", EditorStyles.toolbarButton))
		{
			OnMenu_Create();
			EditorGUIUtility.ExitGUI();
		}

		GUILayout.FlexibleSpace(); // fill the remaining space

		if (GUILayout.Button("Password Length", EditorStyles.toolbarDropDown))
		{
			GenericMenu toolsMenu = new GenericMenu();

			if (PasswordLength != 4)
			{  // if any GameObject is selected
				toolsMenu.AddItem(new GUIContent("4 Digis"), false, OnTools_4Digits);
			}
			else
			{ // if no gameObject is selected 
				toolsMenu.AddDisabledItem(new GUIContent("4 Digis"));
			}

			if (PasswordLength != 5)
			{  // if any GameObject is selected
				toolsMenu.AddItem(new GUIContent("5 Digis"), false, OnTools_5Digits);
			}
			else
			{ // if no gameObject is selected 
				toolsMenu.AddDisabledItem(new GUIContent("5 Digis"));
			}

			if (PasswordLength != 6)
			{  // if any GameObject is selected
				toolsMenu.AddItem(new GUIContent("6 Digis"), false, OnTools_6Digits);
			}
			else
			{ // if no gameObject is selected 
				toolsMenu.AddDisabledItem(new GUIContent("6 Digis"));
			}
			toolsMenu.AddSeparator("");
			// offset menu from right of editor window
			toolsMenu.DropDown(new Rect(Screen.width - 216 - 40, 0, 0, 16));
			EditorGUIUtility.ExitGUI();
		}
	}

	// show help website
	void OnTools_4Digits()
	{
		PasswordLength = 4;
		Debug.Log("You Set the password Length To " + PasswordLength);
	}

	// optimize object
	void OnTools_5Digits()
	{
		PasswordLength = 5;
		Debug.Log("You Set the password Length To " + PasswordLength);
	}

	void OnTools_6Digits()
	{
		PasswordLength = 6;
		Debug.Log("You Set the password Length To " + PasswordLength);
	}

	// create menu
	void OnMenu_Create()
	{
		// do something
		switch (PasswordLength)
        {
			case 4:
				GameObject takara4D_gameObject = Instantiate(takaraBox_4Digits, new Vector3(0, 0, 0), Quaternion.identity);
				takara4D_gameObject.name = myString;
				takara4D_gameObject.GetComponent<Answer>().answer = ans;
				takara4D_gameObject.GetComponent<Answer>().PWLength = PasswordLength;
				break;
			case 5:
				GameObject takara5D_gameObject = Instantiate(takaraBox_5Digits, new Vector3(0, 0, 0), Quaternion.identity);
				takara5D_gameObject.name = myString;
				takara5D_gameObject.GetComponent<Answer>().answer = ans;
				takara5D_gameObject.GetComponent<Answer>().PWLength = PasswordLength;
				break;
			case 6:
				GameObject takara6_gameObject = Instantiate(takaraBox_6Digits, new Vector3(0, 0, 0), Quaternion.identity);
				takara6_gameObject.name = myString;
				takara6_gameObject.GetComponent<Answer>().answer = ans;
				takara6_gameObject.GetComponent<Answer>().PWLength = PasswordLength;
				break;
		}

		//Debug.Log("The ans you set : " + takaraBox.GetComponent<CanvasController_Takara>().answer);
	}

}
