namespace Programmer.Services
{
    using Programmer.App.ViewModels.Academy;
    using Programmer.App.ViewModels.Courses;
    using Programmer.App.ViewModels.Exams;

    public interface IAcademyService
    {
        AcademyAllCoursesViewModel GetAllCourses(string userId);

        AdministrationAcademyAllCoursesViewModel GetAllCoursesForAdmin();

        AdministrationCourseInfoViewModel CourseInfo(int courseId);

        AdministrationCreateCourseInputModel GetSkillsForDropdowns();

        void CreateCourse(AdministrationCreateCourseInputModel inputModel);

        void CreateLecture(string name, int courseId);

        AdministrationCreateExamInputModel GetRequiredSkillName(int courseId);

        void CreateExam(AdministrationCreateExamInputModel inputModel);

        AdministrationCreateExamInputModel GetExamForEdit(int courseId);

        void EditExam(AdministrationCreateExamInputModel inputModel);

        void DeleteCourse(int courseId);
    }
}
