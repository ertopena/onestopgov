using UnityEngine;
using UnityEngine.UI;
using System.Collections.Specialized;

public class ServiceButton : MonoBehaviour {


	public Text nameText;


	private ServiceAdapter _Adapter { get; set; }

	private string _reference;
	private NameValueCollection _fields;


	public void Init (string name, string reference, NameValueCollection fields) {
		_Adapter = new ServiceAdapter ();


		nameText.text = name;
		_reference = reference;
		_fields = fields;
	}


	public void PostRequest () {
		Debug.Log ("A button is about to post a request!!");


		NameValueCollection values = new NameValueCollection ();
		string[] keys = _fields.AllKeys;


		// TODO: POPULATE THIS IN A WAY THAT MAKES SENSE!!
		Profile profile  = new Profile ();


		foreach (string key in keys) {

			// TODO: LOOK UP ACTUAL SYNTAX FOR THIS!!
			if (profile.info[key] != null)
				values[key] = profile.info[key];
		}


		HandleResponse ( _Adapter.PostRequst (_reference, values) );
	}


	void HandleResponse (string response) {
		Debug.Log ("Handled response: " + response);
	}
}
