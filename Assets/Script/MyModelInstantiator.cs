using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Vuforia{

public class MyModelInstantiator : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;
	public Transform myModelPrefab;

	// Use this for initialization
		public GameObject Green;
		public GameObject Red;


	void Start ()


	{
			Green.SetActive (false);
		Red.SetActive (false);


		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	// Update is called once per frame
	void Update ()
	{
	}
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{ 
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			   newStatus == TrackableBehaviour.Status.TRACKED ||
			   newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound ();

				Green.SetActive (true);

			}
			else
			
			{
				
				OnTrackingLost ();

				Red.SetActive (true);
				Green.SetActive (false);


		}
	} 
	private void OnTrackingFound()
	{
		if (myModelPrefab != null)
		{
			Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
			myModelTrf.parent = mTrackableBehaviour.transform;
			myModelTrf.localPosition = new Vector3(0f, 0f, -1f);
			myModelTrf.localRotation = Quaternion.identity;
			myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
			myModelTrf.gameObject.active = true;
		}
	}
		private void OnTrackingLost()
		{
			Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
			myModelTrf.gameObject.active = false;
		}

}
		}