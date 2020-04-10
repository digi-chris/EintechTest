using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EFCore.ModelBuilderExtensions;
using EFCore.ModelBuilderExtensions.Attributes;

namespace EintechTest.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }

        [SqlDefaultValue("SYSDATETIMEOFFSET()")]
        public DateTimeOffset DateAdded { get; set; }

        public Group Group { get; set; }
    }
}
