using System;
using System.Runtime.Serialization;

[Serializable()]
public class BOException : Exception
{
    private String message;


    public BOException(string message)
       : base(message)
    {
        message = message;
    }

    public String getessage
    { get { return message; } }
}
