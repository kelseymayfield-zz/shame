//Make an empty game object and call it "Door"
//Rename your 3D door model to "Body"
//Parent a "Body" object to "Door"
//Make sure thet a "Door" object is in left down corner of "Body" object. The place where a Door Hinge need be
//Add a box collider to "Door" object and make it much bigger then the "Body" model, mark it trigger
//Assign this script to a "Door" game object that have box collider with trigger enabled
//Press "f" to open the door and "g" to close the door
//Make sure the main character is tagged "player"

// Smothly open a door
var smooth = 2.0;
var DoorOpenAngle = 90.0;
var rotationDirection = -1.0;
public var rotationStep = 1.0;
private var open : boolean;
private var enter : boolean;

private var defaultRot : Vector3;
private var openRot : Vector3;
private var currentRot : Vector3;

function Start(){
	defaultRot = transform.eulerAngles;
	currentRot = transform.eulerAngles;
	openRot = new Vector3 (defaultRot.x, defaultRot.y + (rotationDirection * DoorOpenAngle), defaultRot.z);
}

function objectRotationAnimation(){
	currentRot.y += (rotationStep * rotationDirection);
	transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, currentRot, Time.deltaTime * smooth);
			
	if ((currentRot.y > openRot.y && rotationDirection < 0) || (currentRot.y < openRot.y && rotationDirection > 0)) {
		objectRotationAnimation();
	} else {
		transform.eulerAngles = openRot;
	}
}

//Main function
function Update (){
	if(open){
		//Open door
//		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		rotationDirection = -1.0;
		openRot = new Vector3 (defaultRot.x, defaultRot.y + (rotationDirection * DoorOpenAngle), defaultRot.z);
		objectRotationAnimation();
	}else{
		//Close door
//		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
		rotationDirection = 1.0;
		openRot = new Vector3 (defaultRot.x, defaultRot.y, defaultRot.z);
		if (currentRot.y != defaultRot.y)
			objectRotationAnimation();
	}

	if(Input.GetKeyDown("f") && enter){
		open = !open;
		}
	}

function OnGUI(){
	if(enter){
		GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
	}
}

//Activate the Main function when player is near the door
function OnTriggerEnter (other : Collider){
	if (other.gameObject.tag == "Player") {
		enter = true;
	}
}

//Deactivate the Main function when player is go away from door
function OnTriggerExit (other : Collider){
	if (other.gameObject.tag == "Player") {
		enter = false;
	}
}
//@youtube.com/user/maksimum654321
//www.warmerise.com - check this game