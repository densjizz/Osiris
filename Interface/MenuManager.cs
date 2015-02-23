using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization

	public GameObject[] Menus;

	void Start () {
		GotoMenu(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GotoMenu(int id){
		ShowRightMenu(id);
		CloseAllMenuExcept(id);
	}

	void CloseAllMenuExcept (int id)
	{
		foreach(GameObject go in Menus){
			if(GetMenuFromGameObject(go).ID != id){
				go.SetActive(false);
			}
		}
	}

	void ShowRightMenu (int id)
	{
		foreach(GameObject go in Menus){
			if(GetMenuFromGameObject(go).ID == id){
				go.SetActive(true);
			}
		}
	}

	public Menu GetMenuFromGameObject(GameObject go){
		return (Menu)go.GetComponent<Menu>();
	}
}
