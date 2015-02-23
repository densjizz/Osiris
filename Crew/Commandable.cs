using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Commandable : MonoBehaviour {

	private Command currentCommand;
	public Stack<Command> Commands;

	virtual public void Start () {
		Commands = new Stack<Command>();
	}
	
	// Update is called once per frame
	virtual public void Update () {
		if(currentCommand == null || currentCommand.State == CommandState.Finished){
			ActNextCommand();
		} else if(currentCommand != null){
			currentCommand.Update ();
		}
	}

	void ActNextCommand ()
	{
		currentCommand = null;
		if(Commands.Count > 0){
			currentCommand = Commands.Peek();
			Commands.Pop();
			currentCommand.Start();
		}
	}
}
