using System;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name) { }
        public virtual event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract GradeBookStatistic GetGradeBookStatistics();
    }
}