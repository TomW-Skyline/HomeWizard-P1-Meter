namespace HomeWizard.Data
{
	using System;

	public class MeasurementDiff
	{
		public MeasurementDiff(Measurement old, Measurement @new)
		{
			Old = old ?? throw new ArgumentNullException(nameof(old));
			New = @new ?? throw new ArgumentNullException(nameof(@new));
		}

		public Measurement Old { get; }

		public Measurement New { get; }

		public TimeSpan TimeSpan => New.Timestamp - Old.Timestamp;

		public double total_power_import_kwh => New.total_power_import_kwh - Old.total_power_import_kwh;

		public double total_power_import_t1_kwh => New.total_power_import_t1_kwh - Old.total_power_import_t1_kwh;

		public double total_power_import_t2_kwh => New.total_power_import_t2_kwh - Old.total_power_import_t2_kwh;

		public double total_power_export_kwh => New.total_power_export_kwh - Old.total_power_export_kwh;

		public double total_power_export_t1_kwh => New.total_power_export_t1_kwh - Old.total_power_export_t1_kwh;

		public double total_power_export_t2_kwh => New.total_power_export_t2_kwh - Old.total_power_export_t2_kwh;
	}
}