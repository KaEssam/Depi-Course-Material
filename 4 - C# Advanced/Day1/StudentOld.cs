using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
   public class StudentOld
    {
        private Dictionary<string, int> _grades = new Dictionary<string, int>();

        public void SetGrade(string name, int grade)
        {
            _grades[name] = grade;
        }

        public int GetGrade(string name)
        {
            return _grades.ContainsKey(name) ? _grades[name] : 0;
        }
        
    }
}
