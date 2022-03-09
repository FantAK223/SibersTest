namespace ProjectEditor.Config.Sections
{
    public sealed class SerilogAdditionalParametersSection
    {
        public int RetainedFileCountLimit { get; set; }
        public string OutputTemplate { get; set; }
        public string BasePath { get; set; }

        public void Deconstruct(out string basePath, out string outputTemplate, out int retainedFileCountLimit)
        {
            basePath = BasePath;
            outputTemplate = OutputTemplate;
            retainedFileCountLimit = RetainedFileCountLimit;
        }

        public override string ToString() => $"Retained file count limit: '{RetainedFileCountLimit}', base path: '{BasePath}'";
    }
}