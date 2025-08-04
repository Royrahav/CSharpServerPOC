namespace MyServer.Application.DTOs.Configuration
{
    public class PatientSearchConfiguration
    {
        public bool FilterByPatientSite { get; set; }
        public string ChecksumSeparatorForDisplay { get; set; } = string.Empty;
        public string ChecksumSeparatorForSave { get; set; } = string.Empty;
        public bool UseSenderEpisodeForPatient { get; set; }
        public bool SearchPatientByHospitalization { get; set; }
        public int SearchPatientByHasOrdersDaysBack { get; set; }
        public string SearchPatientsByView { get; set; } = string.Empty;
        public bool PatientSearchFilterContains { get; set; }
        public bool ExecuteDemogWithEpisode { get; set; }
        public string ExecuteDemogPolicy { get; set; } = string.Empty;
        public bool ResourcesUsedRoDb { get; set; }
        public string PrimaryIdType { get; set; } = string.Empty;
        public bool RecordSearchOnAllPatientFields { get; set; }
        public bool IgnoreAssociationToSender { get; set; }
        public bool EnableQueriesRowsLimit { get; set; }
        public string CharactersToReplaceWithSpaceInSearch { get; set; } = string.Empty;
        public string PatientChecksumIdTypeSearchLogic { get; set; } = string.Empty;
        public int MaximumDigitsForPhone { get; set; }
        public string NamesDisplayOrder { get; set; } = string.Empty;
        public string WebEpisodeTypes { get; set; } = string.Empty;
        public int MinimumSearchLength { get; set; } = 2;
    }
}