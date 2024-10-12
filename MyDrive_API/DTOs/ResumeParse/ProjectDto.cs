namespace MyDrive_API.DTOs.ResumeParse
{
    public class ProjectDto
    {
        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }

        public IEnumerable<string> Techs { get; set; }
    }
}



