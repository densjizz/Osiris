using UnityEngine;
using System.Collections;

public class MoveCommand : Command {

	public Vector2 Destination;

	public GameObject Actor;
	public Crew ActorCrew;

	private Vector3 startPosition;
	private Vector3 endPosition;

	public override void Start ()
	{
		base.Start ();
		ActorCrew = (Crew)Actor.GetComponent<Crew>();
		endPosition = new Vector3(Destination.x, Destination.y, Actor.transform.position.z);
	}

	public override void Update ()
	{
		base.Update ();
		var dist = (endPosition - Actor.transform.position);
		var length = dist.magnitude;

		if(dist.magnitude < (ActorCrew.MovementSpeed) ){
			Actor.transform.position = endPosition;
			this.State = CommandState.Finished;
		} else{
			dist.Normalize();
			Actor.transform.position += (dist * ActorCrew.MovementSpeed);
		}



	}
	
}
