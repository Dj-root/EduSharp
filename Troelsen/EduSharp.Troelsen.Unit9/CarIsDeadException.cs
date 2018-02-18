using System;

namespace EduSharp.Troelsen.Unit9
{
    public class CarIsDeadException : ApplicationException
    {
//        private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException()
        {
        }

        public CarIsDeadException(string message) : base(message)
        {
        }

        public CarIsDeadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CarIsDeadException(string message, string cause, DateTime time):base(message)
        {
//            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        protected CarIsDeadException (
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            :base(info, context) { }



        //        public override string Message
        //        {
        //            get { return string.Format("Car Error Message: {0}", messageDetails); }
        //        }
    }
}