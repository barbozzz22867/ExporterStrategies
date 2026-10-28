namespace ExporterStrategies;

public sealed class ReportService
{
    private readonly IReportExporter _exporter;

    public ReportService(IReportExporter exporter)
    {
        _exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
    }

    public void PublishDailySummary(int totalJobs, int failedJobs)
    {
        var body = $"Всего задач: {totalJobs}\nОшибок: {failedJobs}";
        _exporter.Export(new ReportDocument("Сводка за день", body));
    }
}

internal static class ReportDocumentValidator
{
    public static void Validate(ReportDocument document)
    {
        if (document is null)
            throw new ArgumentNullException(nameof(document));

        if (string.IsNullOrWhiteSpace(document.Title))
            throw new ArgumentException("Заголовок отчёта пуст.", nameof(document));

        if (document.Body is null)
            throw new ArgumentException("Тело отчёта не задано.", nameof(document));
    }
}