using Osiris.Stats;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crew : Commandable {

	// Use this for initialization
	public int Id;
	public string Name;

    public Stat Strenght;
    public Stat Agility;
    public Stat Intelligence;


    public float MovementSpeed = 10.0f;

	public override void Start () {
		base.Start();
        Strenght = new Stat("Strenght", 12, 1);
        Agility = new Stat("Agility", 10, 1);
        Intelligence = new Stat("Intelligence", 10, 1);
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
