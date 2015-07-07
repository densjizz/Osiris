using UnityEngine;
using System.Collections;

public class SelectionManager : MonoBehaviour {

	int Range = 100;
	public Crew SelectedCrewMember;
	public LayerMask CrewLayerMask;
	public LayerMask TileLayerMask;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {



		if(Input.GetMouseButtonDown(0)){
			bool crewMemberWasSelected = RayCastForCrewSelection ();

			if(SelectedCrewMember != null && !crewMemberWasSelected)RaycastForCommands();


		}
	}

	bool RaycastForCommands ()
	{
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * Range, Color.green);
		RaycastHit Hit;
		if (Physics.Raycast (ray, out Hit, Range, TileLayerMask)) {
			var movePosition = Hit.transform.position;
			var cmd = Command.CreateMoveToCommand(SelectedCrewMember.gameObject , movePosition);
			SelectedCrewMember.AddCommand(cmd);

			return true;
		}
		return false;
	}

	bool RayCastForCrewSelection ()
	{
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * Range, Color.green);
		RaycastHit Hit;
		if (Physics.Raycast (ray, out Hit, Range, CrewLayerMask)) {
			SelectedCrewMember = (Crew)Hit.transform.parent.gameObject.GetComponent<Crew> ();
			Debug.Log ("Selected " + SelectedCrewMember.Name);
			return true;
		}
		return false;
	}
}
