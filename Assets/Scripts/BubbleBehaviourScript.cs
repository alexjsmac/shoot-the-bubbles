using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BubbleBehaviourScript : MonoBehaviour {

	// Cube's Max/Min scale
	public float mScaleMax  = 2f;
	public float mScaleMin  = 0.5f;
	public PlayerController playerobject;
	 

	// Orbit max Speed
	public float mOrbitMaxSpeed = 30f;

	// Orbit speed
	private float mOrbitSpeed;

	// Anchor point for the Cube to rotate around
	private Transform mOrbitAnchor;

	// Orbit direction
	private Vector3 mOrbitDirection;

	// Max Cube Scale
	private Vector3 mCubeMaxScale;

	// Growing Speed
	public float mGrowingSpeed  = 10f;
	private bool mIsCubeScaled  = false;

	void Start () {
		CubeSettings();
		playerobject = FindObjectOfType (typeof(PlayerController)) as PlayerController;
	}
		
	// Set initial cube settings
	private void CubeSettings(){
		
		// defining the anchor point as the main camera
		mOrbitAnchor = Camera.main.transform;

		// defining the orbit direction
		float x = Random.Range(-1f,1f);
		float y = Random.Range(-1f,1f);
		float z = Random.Range(-1f,1f);
		mOrbitDirection = new Vector3( x, y, z );

		// defining speed
		mOrbitSpeed = Random.Range( 5f, mOrbitMaxSpeed );

		// defining scale
		float scale = Random.Range(mScaleMin, mScaleMax);
		mCubeMaxScale = new Vector3( scale, scale, scale );

		// set cube scale to 0, to grow it lates
		transform.localScale = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		// makes the cube orbit and rotate
		RotateCube();

		// scale cube if needed
		if ( !mIsCubeScaled )
			ScaleObj();

		//if (transform.position == Camera.main.transform.position)
			//print("Hit!");
			//StartCoroutine( DestroyCube());
	}

	// Makes the cube rotate around a anchor point
	// and rotate around its own axis
	private void RotateCube(){

		// rotate cube around camera
		//transform.RotateAround(mOrbitAnchor.position, mOrbitDirection, mOrbitSpeed * Time.deltaTime);

		transform.LookAt(Camera.main.transform);
		transform.Translate (Vector3.forward * Time.deltaTime);

		// rotating around its axis
		transform.Rotate( mOrbitDirection * 30 * Time.deltaTime);
	}

	// Scale object from 0 to 1
	private void ScaleObj(){

		// growing obj
		if ( transform.localScale != mCubeMaxScale )
			transform.localScale = Vector3.Lerp( transform.localScale, mCubeMaxScale, Time.deltaTime * mGrowingSpeed );
		else
			mIsCubeScaled = true;
	}

	// Cube Health
	public int mCubeHealth  = 100;

	// Define if the Cube is Alive
	private bool mIsAlive       = true;

	// Cube got Hit
	// return 'false' when cube was destroyed
	public bool Hit( int hitDamage ){
		mCubeHealth -= hitDamage;
		if ( mCubeHealth >= 0 && mIsAlive ) {
			StartCoroutine( DestroyCube());
			return true;
		}
		return false;
	}

	// Destroy Cube
	private IEnumerator DestroyCube(){
		mIsAlive = false;
		playerobject.UpdateScore ();


		// Make the cube desappear
		GetComponent<Renderer>().enabled = false;
		// we'll wait some time before destroying the element
		// this is usefull when using some kind of effect
		// like a explosion sound effect.
		// in that case we could use the sound lenght as waiting time
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);



	}
}
