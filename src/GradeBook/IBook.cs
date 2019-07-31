namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        GradeBookStatistic GetGradeBookStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}