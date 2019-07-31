using System;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual GradeBookStatistic GetGradeBookStatistics()
        {
            throw new NotImplementedException();
        }
    }
}