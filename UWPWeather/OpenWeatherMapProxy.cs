﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UWPWeather
{
    class OpenWeatherMapProxy
    {
        public async static Task<RootObject> GetWeather(double lat, double lon)
        {
            var http = new HttpClient();
            var response = await http.GetAsync($"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof (RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }

        public static void GetWeather()
        {

        }

        // little APPID key addition
        private static string key { get; } = "27ef8778fb00b062c28e1b78c9b8764b";
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Coord coord { get; set; }
        [DataMember]
        public List<Weather> weather { get; set; }
        [DataMember]
        public string @base { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        public Clouds clouds { get; set; }
        [DataMember]
        public Rain rain { get; set; }
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        public Sys sys { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int cod { get; set; }
    }

    [DataContract]
    public class Coord
    {
        [DataMember]
        public double lon { get; set; }
        [DataMember]
        public double lat { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember]
        public double  temp { get; set; }
        [DataMember]
        public double pressure { get; set; }
        [DataMember]
        public int humidity { get; set; }
        [DataMember]
        public double temp_min { get; set; }
        [DataMember]
        public double temp_max { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public double degree { get; set; }
    }

    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }

    [DataContract]
    public class Rain
    {
        [DataMember]
        public int _3h { get; set; }
    }

    [DataContract]
    public class Sys
    {
        [DataMember]
        public int type { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public double message { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public int sunrise { get; set; }
        [DataMember]
        public int sunset { get; set; }
    }
}
