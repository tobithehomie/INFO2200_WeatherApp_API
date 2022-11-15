using Newtonsoft.Json.Linq;
using System.Net;

namespace WeatherApp;

public partial class MainPage : ContentPage
{

	const string API_KEY = "9a3f73186435227f7ab236fae0b859d7";

	public MainPage()
	{
		InitializeComponent();
	}

	private void BtnShowTemp_Clicked(object sender, EventArgs e)
	{
		//If user entered something in the zipcode text box
		if (EntryZip.Text != null)
		{
            //Start the API call and get JSON info from open weather map
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string json = wc.DownloadString($"http://api.openweathermap.org/data/2.5/weather?zip={EntryZip.Text}&appid={API_KEY}&units=imperial");

				//Call the JSON object and parse the JSON
                JObject jo = JObject.Parse(json);

				//Grab the city name from the API JSON and put into cityName variable
				string cityName = jo["name"].ToString();
				//Display cityName in a pop-up box
				DisplayAlert("City", cityName, "Click me. See what happens...");

                JObject main = JObject.Parse(jo["main"].ToString());

            }
        }
		//If the user did not enter anything in the zip code text box
		else
		{
			//Display alert message
			DisplayAlert("Invalid Input", "Please enter a zip code", "Close this Thang");
		}

		
    }
}

