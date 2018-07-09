using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StronglyTypedDatasets
{
    public class Student
    {

        private int iD;
        private string name;
        private string gender;
        private int totalMarks;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int TotalMarks { get => totalMarks; set => totalMarks = value; }
    }

}