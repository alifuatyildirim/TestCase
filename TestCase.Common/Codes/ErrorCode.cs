using System.ComponentModel;

namespace TestCase.Common.Codes;

public enum ErrorCode
{
    [Description("Something went wrong.")]
    GenericError = 1000,
    
    [Description("{0}")]
    InvalidRequest = 1001,
    
    [Description("Invalid user Id.")]
    InvalidUserId = 1002, 
     
     [Description("The email address cannot be empty.")]
     EmptyEmail = 1011,
     
     [Description("The user id cannot be empty.")]
     EmptyUserId = 1012,
     
     [Description("The user name cannot be empty.")]
     EmptyName = 1013,
     
     [Description("Invalid email address.")]
     InvalidEmail = 1014,
}