using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int threshold = (int) Math.Ceiling(0.2 * Students.Count);
            var grades = Students.OrderByDescending(s => s.AverageGrade)
                                 .Select(e => e.AverageGrade)
                                 .ToList();

            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[threshold*2 - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[threshold * 3 - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[threshold * 4 - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
