using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace Challenge_3_Student_Registry.Models
{
    public class StudentInfo
    {
        
        
        
        public int Id { get; set;}
        public string FirstName { get; set;}

        public string LastName { get; set;}

        
        public string Hobby { get; set;}

        public string Email { get; set;}

        public string SlackName { get; set;}
        
    }
}