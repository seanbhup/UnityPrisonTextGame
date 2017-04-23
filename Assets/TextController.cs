using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {
							cell, 
							mirror, 
							sheets_0, 
							lock_0, 
							cell_mirror, 
							sheets_1, 
							lock_1, 
							corridor_0, 
							stairs_0,
							floor,
							closet_door,
							stairs_1,
							corridor_1,
							in_closet,
							freedom
						};
						
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
		
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) {
			cell();
		}
		else if (myState == States.sheets_0) {
			sheets_0();
		}
		else if (myState == States.sheets_1) {
			sheets_1();
		}
		else if (myState == States.lock_0) {
			lock_0();
		}
		else if (myState == States.lock_1) {
			lock_1();
		}
		else if (myState == States.mirror) {
			mirror();
		}
		else if (myState == States.cell_mirror) {
			cell_mirror();
		}
		else if (myState == States.corridor_0) {
			corridor_0();
		}
		else if (myState == States.stairs_0) {
			stairs_0();
		}
		else if (myState == States.floor) {
			floor();
		}
		else if (myState == States.closet_door) {
			closet_door();
		}
		else if (myState == States.stairs_1) {
			stairs_1();
		}
		else if (myState == States.corridor_1) {
			corridor_1();
		}
		else if (myState == States.in_closet) {
			in_closet();
		}
		else if (myState == States.freedom) {
			freedom();
		}
	}
	
	#region State handler methods
	void cell () {
		text.text = "You are in a prison cell, and you want to escape. " + 
					"There are some dirty sheets on the bed, a mirror on the wall, " +
					"and the door is locked from the outside.\n\n" +
					"Press S to View Sheets, M to View Mirror, and L to View Lock";
					
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
		else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		}
		else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
	}
	
	void sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " + 
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell";
					
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void sheets_1 () {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " + 
					"any better.\n\n" +
					"Press R to Return to roaming your cell";
					
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void lock_0 () {
		text.text = "This is one of those button locks. You have no idea what the " + 
					"combination is. You wish you could somehow see where the dirty  " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell";
					
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void lock_1 () {
		text.text = "You carefully put the mirror through the bars, and turn it around " + 
					"so you can see the lock. You can just make out fingerprints around  " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell";
					
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
		else if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.corridor_0;
		}
	}
	
	void mirror () {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to your cell.";
					
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
		else if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}
	
	void cell_mirror () {
		text.text = "You are still in your cell, and you still want to escape! There are " + 
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock";
					
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		}
		else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}
	
	void corridor_0 () {
		text.text = "The door opens up into a corridor. There are stairs to your left, " +
						"a closet in front of you, and something odd on the floor.\n\n" +
						"Press S for Stairs, F for Floor, and C for Closet";
						
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_0;
		}
		else if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.floor;
		}
		else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet_door;
		}
	}
	
	void stairs_0 () {
		text.text = "You hear talking up the stairs. Best not to encounter a prison guard.\n\n" +
			"Press R to Return to the corridor.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}
		
	}
	
	void closet_door () {
		text.text = "The closet is locked.\n\n" +
			"Press R to Return to the corridor.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}
		
	}
	
	void floor () {
		text.text = "You see a Hairclip on the floor.\n\n" +
			"Press H to pick up the Hairclip or R to return to the corridor.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}
		else if (Input.GetKeyDown(KeyCode.H)) {
			myState = States.corridor_1;
		}
		
	}
	
	void corridor_1 () {
		text.text = "You have a Hairclip in your hand now.\n\n" +
			"Press S to check the Stairs again or P to Pick the closet door lock.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1;
		}
		else if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_1;
		}
		else if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.in_closet;
		}
		
		
	}
	
	void stairs_1 () {
		text.text = "You still hear talking up the stairs. Best not to encounter a prison guard.\n\n" +
			"Press R to Return to the corridor.";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1;
		}
		
	}
	
	void in_closet () {
		text.text = "You open the closet and it actually turns out to be a hallway to another door.\n\n" +
			"Press O to open the door at the end of the hallway or R to Return to the corridor.";
		
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1;
		}
		
	}
	
	void freedom () {
		text.text = "Congratulations! You've successfully escaped from the prison!\n\n" +
			"Press P to Play again.";
		
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}
		
	}
	#endregion
}












