using UnityEngine;
using System.Collections;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

public class ServiceAdapter {

	public string GetServices() {
		using (WebClient webClient = new System.Net.WebClient())
		{
			WebClient n = new WebClient();
			var json = n.DownloadString("https://vast-fjord-30944.herokuapp.com/services.json");
			string valueOriginal = Convert.ToString(json);
			Console.WriteLine(valueOriginal);
			return valueOriginal;
		}
	}

	// Pass in the service reference that was received in the GetServices json string above
	// and use it to upload the data.  Example:
	// {"id":1,"name":"Renew Vehicle  Registration","service_reference":"renew_vehicle_registration","description":"Renew your vehicle registration","fields":"{\"license_plate\":\"string\", \"vin_last_4\":\"string\"}","category_id":1,"url":"https://vast-fjord-30944.herokuapp.com/services/1.json"}
	// So reference = "renew_vehicle_registration" and values would be values["licence_plate"]="MYPL4T3", values["vin_last_4"]="F322" 
	public string PostRequst(string reference, NameValueCollection values) {
		using (var client = new WebClient())
		{
			var response = client.UploadValues("https://vast-fjord-30944.herokuapp.com/services/" + reference, values);

			string result = Encoding.Default.GetString(response);
			Console.WriteLine(result);
			return result;
		}
	}

}
