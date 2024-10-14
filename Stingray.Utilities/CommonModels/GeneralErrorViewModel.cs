namespace StingRay.Utility.CommonModels
{
    public class GeneralErrorViewModel
    {
        public string ViewTitle { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public string SourceControllerName { get; set; }
        public string SourceActionName { get; set; }
        public string TargetControllerName { get; set; }
        public string TargetActionName { get; set; }
        public bool IsModal { get; set; }
    }
}
