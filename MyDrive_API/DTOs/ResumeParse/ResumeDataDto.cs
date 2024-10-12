namespace MyDrive_API.DTOs.ResumeParse
{
    public class ResumeDataDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Skills { get; set; }

        public IEnumerable<WorkExperienceDto> workExperiences { get; set; }

        public IEnumerable<EducationDto> educations { get; set; }

        public IEnumerable<ProjectDto> projects { get; set; }
    }
}
