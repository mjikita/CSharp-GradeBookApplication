﻿using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var studentsInOrder = Students.OrderByDescending(s => s.AverageGrade).ToList();
            var grades = studentsInOrder.Select(s => s.AverageGrade).ToList();
            var gradeTreshold = (int)Math.Ceiling(Students.Count * 0.2);
            if (grades[gradeTreshold - 1] <= averageGrade)
                return 'A';
            if (grades[gradeTreshold * 2 - 1] <= averageGrade)
                return 'B';
            if (grades[gradeTreshold * 3 - 1] <= averageGrade)
                return 'C';
            if (grades[gradeTreshold * 4 - 1] <= averageGrade)
                return 'D';
            return 'F';
        }
    }
}