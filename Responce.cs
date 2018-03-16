using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AutoHubWITHSQL
{
    [DataContract]
    public class Responce
    {
        string _message;
        string _error;
        string _data;
        bool _success;

        [DataMember]
        public string Message { get { return _message; } set { _message = value; } }

        [DataMember]
        public string Error { get { return _error; } set { _error = value; } } 
        [DataMember]
        public string Data { get { return _data; } set { _data = value; } }

        [DataMember]
        public bool Success { get { return _success; } set { _success = value; } }
        public Responce()
        {
            Message = "";
            Error = "";
            Data = null;
            Success = true;
        }
    }
    [DataContract]
    public class Responces
    {
        string _message;
        string _error;
        object _data;
        bool _success;

        [DataMember]
        public string Message { get { return _message; } set { _message = value; } }

        [DataMember]
        public string Error { get { return _error; } set { _error = value; } }
        [DataMember]
        public object Data { get { return _data; } set { _data = value; } }

        [DataMember]
        public bool Success { get { return _success; } set { _success = value; } }
        public Responces()
        {
            Message = "";
            Error = "";
            Data = null;
            Success = true;
        }
    }

    [DataContract]
   public class CustomerDocs
    {
        string _message;
        string _error;
        string _data;
        bool _success;

        [DataMember]
        public string Message { get { return _message; } set { _message = value; } }

        [DataMember]
        public string Error { get { return _error; } set { _error = value; } }
        [DataMember]
        public string Data { get { return _data; } set { _data = value; } }

        [DataMember]
        public bool Success { get { return _success; } set { _success = value; } }
        public CustomerDocs()
        {
            Message = "";
            Error = "";
            Data = null;
            Success = true;
        }
    }
}