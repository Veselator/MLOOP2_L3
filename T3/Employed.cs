using System.Text.Json.Serialization;

namespace MLOOP2_L3.T3
{
    internal class Employed
    {
        public enum JobTitle
        {
            Worker,
            CEO,
            Manager
        }

        public enum Education
        {
            // Освіти нема (або церковно-приходська школа)
            None,

            // Шкільна освіта
            PrimarySchool,
            MiddleSchool,
            HighSchool,

            // Професійна освіта
            Prof,

            // Вища освіта - основні наукові степені
            PhD,
            DSc,
            DM,
            ThD,
            JSD
        }

        public JobTitle jobTitle { get; init; }
        public FullName fullName { get; init; }
        public decimal HourlyWage { get; init; } // USD
        public int HoursPerWeek { get; init; }

        [JsonIgnore]
        public decimal MounthlyWage => HoursPerWeek * HourlyWage;
        public DateTime DateOfHiring { get; init; }

        [JsonIgnore]
        public int ExperienceInDays => DateTimeDifference.GetDifferenceInDays(DateTime.Now, DateOfHiring);
        [JsonIgnore]
        public int ExperienceInYears => DateTimeDifference.GetDifferenceInYears(DateTime.Now, DateOfHiring);

        public DateTime DateOfBirth { get; init; }
        [JsonIgnore]
        public int Age => DateTimeDifference.GetDifferenceInYears(DateTime.Now, DateOfBirth);
        public List<Education> Educations { get; init; }

        [JsonIgnore]
        public bool DoesGraduetedHighEducation => 
            Educations.Contains(Education.PhD) ||
            Educations.Contains(Education.DSc) ||
            Educations.Contains(Education.DM) ||
            Educations.Contains(Education.ThD) ||
            Educations.Contains(Education.JSD);

        public override string ToString()
        {
            return $"{fullName.name} {fullName.surname} {fullName.patronymic}";
        }
    }
}
