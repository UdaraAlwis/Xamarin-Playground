using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace UdaraMyNotesApp
{
	public class MyNote
    {
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private DateTime _timeStamp;
        private string _title;
        private string _description;
        private string _id;
        
        [Version]
        public string Version { get; set; }
	}
}

