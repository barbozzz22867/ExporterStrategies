using ExporterStrategies;

public sealed class TextFileReportExporter : IReportExporter
{
    private readonly string _path;

    public TextFileReportExporter(string path)
    {
        // TODO 4: пустая строка не считается допустимым именем файла
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Путь к файлу не задан.", nameof(path));

        _path = path;
    }

    public void Export(ReportDocument document)
    {
        // TODO 5: проверяем документ
        ReportDocumentValidator.Validate(document);

        var directory = Path.GetDirectoryName(Path.GetFullPath(_path));
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        // TODO 6: пишем в том же формате, что и LegacyReportPrinter
        File.WriteAllText(_path,
            $"=== {document.Title} ==={Environment.NewLine}" +
            $"{document.Body}{Environment.NewLine}" +
            $"=== END OF REPORT ===");
    }
}