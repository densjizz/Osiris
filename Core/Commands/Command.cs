using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Command : object {


	public const int CMD_MOVE_ID = 0;
	public const string CMD_MOVE_NAME = "MOVE";


	[SerializeField]
	public int Id =0;
	[SerializeField]
	public string Name = "";
	public CommandState State;
	public List<object> parameters;


	virtual public void Start(){

	}

	virtual public void Update(){

	}



	//STATIC


	public static Command CreateMoveToCommand (GameObject actor, Vector3 movePosition)
	{
		var cmd = new MoveCommand();
		cmd.Id = CMD_MOVE_ID;
		cmd.Name = CMD_MOVE_NAME;
		cmd.Destination = movePosition;
		cmd.Actor = actor;
		return cmd;
	}


}

public enum CommandState{
	Idle,
	Running,
	Finished
}
