// Smothly open a door
//var targeti : Transform;
var moveSpeed = 5.0;
private var initPosition : Vector3;

private var open : boolean;
private var enter : boolean;

private var openPosition : Vector3;
private var closedPosition : Vector3;

private var cur = 0.0;

var openDistance = 0.1;

function Start(){
	initPosition = transform.position;
	print(transform.position.x);
//	closedPosition = transform.eulerAngles;
	openPosition = new Vector3(initPosition.x - openDistance, initPosition.y, initPosition.z);
}

//Main function
function Update (){
	if (open) {
        transform.position = Vector3.Slerp(transform.position, openPosition, Time.deltaTime * moveSpeed);
    } else {
        transform.position = Vector3.Slerp(transform.position, initPosition, Time.deltaTime * moveSpeed);
	}
	
	if (Input.GetKeyDown("g") && enter) {
		open = !open;
		print("key down");
	}
//	if (!targeti) return;
	
}

function OnGUI(){
	if(enter && !open){
		GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'G' to open drawer");
	} else if (enter && open){
		GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'G' to close drawer");
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

