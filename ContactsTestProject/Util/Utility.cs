using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsTestProject.Util
{
    /// <summary>
    /// Utility class that provides misc static functions
    /// </summary>
    class Utility
    {
        /// <summary>
        /// Calculate Person Age from his Birth date
        /// </summary>
        /// <param name="birthDate">Birth date</param>
        /// <returns>Age in Years</returns>
        public static int CalculateAge(DateTime birthDate)
        {
            var now = DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || 
                    (now.Month == birthDate.Month && now.Day < birthDate.Day)) 
                age--;
            return age;
        }
    }
}
