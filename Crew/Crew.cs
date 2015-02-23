using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crew : Commandable {

	// Use this for initialization
	public int Id;
	public string Name;

	public float MovementSpeed = 10.0f;

	public override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}

	public void AddCommand (Command cmd)
	{
		Commands.Push(cmd);
	}
}
