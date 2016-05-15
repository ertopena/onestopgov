using UnityEngine;
using System.Collections.Specialized;

public class Profile {

	public NameValueCollection info;


	public Profile() {
		info["license_plate"] = "MYPL4T3";
		info["vin_last_4"] = "F322";
	}
}
