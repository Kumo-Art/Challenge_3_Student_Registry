using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Challenge_3_Student_Registry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_3_Student_Registry.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //  ex http://localhost:5071/api ---- /api is base route
    public class StudentController : ControllerBase
    {

        private static List<StudentInfo> School = [
           new StudentInfo { Id = 1, FirstName = "Brandon", LastName = "Langehennig", Hobby = "Art", Email = "Brandonlangehennig67@gmail.com", SlackName = "Brandon Langehennig"  },
          new StudentInfo { Id = 2, FirstName = "Haylie", LastName = "Gilbert", Hobby = "Filmmaking", Email = "Hayliegilbert31@yahoo.com", SlackName = "Haylie Gilbert"  },
           new StudentInfo { Id = 3, FirstName = "James", LastName = "Munoz", Hobby = "Chess", Email = "Jamesmunoz27@gmail.com", SlackName = "James Munoz"  }
        ];

        private static int _nextId = 4;

        [HttpGet("getallstudents")] //  ex  http://localhost:5071/api/Student----------------/Student is our contoller and goes after api---------/getallstudents ------- /getallstudents is first sub route

        public ActionResult<List<StudentInfo>> GetAllStudents()
        {
            return Ok(School);
        }
        [HttpGet("getstudent/{id}")]  // ex http://localhost:5071/api/getstudent/{id number} -------/getstudent = subroute -------/ {id number} - follows first subroute to signify location in list

        public ActionResult<StudentInfo> GetById(int id)
        {

            StudentInfo student = School.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {

                return NotFound($"Error student {id} doesn't exist");


            }

            return Ok(student);
}


            [HttpGet("studentemail/{id}")]

           public ActionResult<StudentInfo> GetByEmail(int id)
           {
            
        }
            
        
          










        //Adds a new student
        [HttpPost("Create")]  //   ex http://localhost:5071/api/Student/Create  -------------/Create = subroute for adding a new entry to list

        public ActionResult<StudentInfo> Create([FromBody] StudentInfo incoming)
        {

            incoming.Id = _nextId;
            _nextId++;

            School.Add(incoming);


            return CreatedAtAction(
                 actionName: nameof(GetById),
                 routeValues: new { id = incoming.Id },
                 value: incoming
            );




        }

        [HttpPut("Update/{id}")]    //  ex http://localhost:5071/api/Student/Update -------------------- /Update this is for editing an existing entry in the list

        public ActionResult<bool> Update(int id, [FromBody] StudentInfo incoming)
        {
                                                      //crewMember is our parameter and we return the first result if the Ids match
            StudentInfo? student = School.FirstOrDefault(s => s.Id == id);

            if(student == null)
            {
                return NotFound($"No crew member with id {id}");
            }

            
            student.FirstName = incoming.FirstName;
            student.LastName = incoming.LastName;
            student.Hobby = incoming.Hobby;
            student.Email = incoming.Email;
            student.SlackName = incoming.SlackName;


            return Ok(true);

        }
        
        
        
        
        [HttpDelete("delete/{id}")]     //  ex http://localhost:5071/api/Student/delete -------------------------------------/delete is for deleting an existing entry
        
        
        public ActionResult<bool> Delete(int id)
        {

            StudentInfo? student = School.FirstOrDefault(s => s.Id == id);


            if (student == null)
            {

                return NotFound($"No student with id: {id}");

            }

            School.Remove(student);

            return Ok(true);

        }




    }
}