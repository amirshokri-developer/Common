using System.Diagnostics;
using Common.Logging.Serilog.Extensions;
using Serilog.Core;
using Serilog.Events;

namespace Common.Logging.Serilog.Enrichers;

internal class ActivityEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var activity = Activity.Current;

        if (activity == null) return;

        logEvent.AddPropertyIfAbsent(new LogEventProperty("SpanId", new ScalarValue(activity.GetSpanId())));
        logEvent.AddPropertyIfAbsent(new LogEventProperty("TraceId", new ScalarValue(activity.GetTraceId())));
        logEvent.AddPropertyIfAbsent(new LogEventProperty("ParentId", new ScalarValue(activity.GetParentId())));
    }
}
