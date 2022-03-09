using ProjectEditor.Config.Sections;
using System;

namespace ProjectEditor.Config
{
    public class ProjectEditorConfiguration
    {
        public const string AppCodeSuffix = "project-editor";

        public ConnectionStringSection ConnectionString { get; set; }
        public ApplicationSection Application { get; set; }
        public SerilogAdditionalParametersSection SerilogAdditionalParameters { get; set; }

        public override string ToString()
        {
            return $"Application: {Application}" + Environment.NewLine +
                   $"Connection: {ConnectionString}" + Environment.NewLine +
                   $"Serilog: {SerilogAdditionalParameters}";
        }
    }
}