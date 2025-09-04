using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterWeatherApi.Domain.Models.Image;

public class GoogleImageResponseModel
{
    public Search_Metadata search_metadata { get; set; }
    public Search_Parameters search_parameters { get; set; }
    public Search_Information search_information { get; set; }
    public Place_Results place_results { get; set; }
}

public class Search_Metadata
{
    public string id { get; set; }
    public string status { get; set; }
    public string json_endpoint { get; set; }
    public string created_at { get; set; }
    public string processed_at { get; set; }
    public string google_maps_url { get; set; }
    public string raw_html_file { get; set; }
    public float total_time_taken { get; set; }
}

public class Search_Parameters
{
    public string engine { get; set; }
    public string type { get; set; }
    public string q { get; set; }
    public string google_domain { get; set; }
    public string hl { get; set; }
}

public class Search_Information
{
    public string local_results_state { get; set; }
    public string query_displayed { get; set; }
}

public class Place_Results
{
    public string title { get; set; }
    public string place_id { get; set; }
    public string data_id { get; set; }
    public string data_cid { get; set; }
    public string reviews_link { get; set; }
    public string photos_link { get; set; }
    public Gps_Coordinates gps_coordinates { get; set; }
    public string place_id_search { get; set; }
    public string provider_id { get; set; }
    public string thumbnail { get; set; }
    public string serpapi_thumbnail { get; set; }
    public Description description { get; set; }
    public string address { get; set; }
    public Weather weather { get; set; }
    public Image[] images { get; set; }
    public string web_results_link { get; set; }
    public string serpapi_web_results_link { get; set; }
}

public class Gps_Coordinates
{
    public float latitude { get; set; }
    public float longitude { get; set; }
}

public class Description
{
    public string snippet { get; set; }
    public string link { get; set; }
}

public class Weather
{
    public string celsius { get; set; }
    public string fahrenheit { get; set; }
    public string conditions { get; set; }
}

public class Image
{
    public string title { get; set; }
    public string thumbnail { get; set; }
    public string serpapi_thumbnail { get; set; }
}



