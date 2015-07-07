using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : Menu {


	public MenuManager parent;
	public Button NewGameBtn;

	void Start () {
		parent = (MenuManager)this.transform.parent.gameObject.GetComponent<MenuManager>();


		NewGameBtn.onClick.AddListener(() => { 
			parent.GotoMenu(1);
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
