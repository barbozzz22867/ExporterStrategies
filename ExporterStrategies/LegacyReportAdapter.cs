using ExporterStrategies;

public sealed class LegacyReportAdapter : IReportExporter
{
    private readonly LegacyReportPrinter _printer;

    public LegacyReportAdapter(LegacyReportPrinter printer) =>
        _printer = printer ?? throw new ArgumentNullException(nameof(printer));

    public void Export(ReportDocument document)
    {
        // TODO 3: согласуем проверку с контрактом второго экспортёра
        ReportDocumentValidator.Validate(document);
        _printer.PrintReport(document.Title, document.Body);
    }
}