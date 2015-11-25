using System.Runtime.Serialization;
using System.Collections.Generic;

namespace CPIApiManager
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "responseTime")]
        public string ResponseTime { get; set; }

        [DataMember(Name = "message")]
        public string[] Message { get; set; }

        [DataMember(Name = "Results")]
        public Results Results { get; set; }
    }

    [DataContract]
    public class Results
    {
        [DataMember(Name = "series")]
        public Series[] Series { get; set; }
    }

    [DataContract]
    public class Series
    { 
        [DataMember(Name = "seriesID")]
        public string SeriesID { get; set; }

        [DataMember(Name = "data")]
        public Data[] Data { get; set; }
    }

    [DataContract]
    public class Data
    {
        [DataMember(Name = "year")]
        public string Year { get; set; }

        [DataMember(Name = "period")]
        public string Period { get; set; }

        [DataMember(Name = "periodName")]
        public string PeriodName { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "footnotes")]
        public FootNote[] Footnotes { get; set; }
    }

    [DataContract]
    public class FootNote
    {
        public string Value { get; set; }
    }
}
