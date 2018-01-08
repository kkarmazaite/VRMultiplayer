using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private bool moveForward=false;
	GameObject Camera;
	Animator anim;
	public float speed=0.7f;
	private bool LockPosition;
	private Quaternion lastTransform;
	private Rigidbody rigitbody;
	void Start(){
		rigitbody = GetComponent<Rigidbody> ();
		rigitbody.constraints = RigidbodyConstraints.FreezePosition|RigidbodyConstraints.FreezeRotation;
	}
	void Update() {
		anim = GetComponent<Animator> ();
		var target = GameObject.Find ("Head");
		if (LockPosition) {
			transform.rotation = lastTransform;
		} else {
			Vector3 newRotation = new Vector3 (0, target.transform.eulerAngles.y, 0);
			this.transform.eulerAngles = newRotation;

			if (target.transform.eulerAngles.z <= 325 && target.transform.eulerAngles.z > 180) {
				moveForward = true;
				anim.SetBool ("Walk", true);

			}
			if (target.transform.eulerAngles.z > 35 && target.transform.eulerAngles.z < 180) {
				moveForward = false;
				anim.SetBool ("Walk", false);
			}
			if (moveForward) {
				rigitbody.constraints =  RigidbodyConstraints.None;
				rigitbody.constraints = RigidbodyConstraints.FreezeRotation;
				this.transform.Translate (0, 0, Time.deltaTime*speed );
			}
			if (!moveForward) {
				rigitbody.constraints = RigidbodyConstraints.FreezePosition|RigidbodyConstraints.FreezeRotation;
			}

			/*if (moveForward && speed < 1) {
				this.transform.Translate (0, 0, Time.deltaTime * speed);
				speed += (Time.deltaTime * 0.4f);
			}
			if (!moveForward && speed > 0) {
				this.transform.Translate (0, 0, Time.deltaTime * speed);
				speed -= (Time.deltaTime * 0.7f);
			}
			if (moveForward && speed >= 1) {
				this.transform.Translate (0, 0, Time.deltaTime);
			}
*/
		}
	}
	public void Position(bool pos){
		LockPosition = pos;
		lastTransform = transform.rotation;
	}
}
