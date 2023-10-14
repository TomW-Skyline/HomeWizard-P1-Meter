namespace HomeWizard.Data
{
	using System;
	using System.Globalization;

	using Newtonsoft.Json;

	public class Measurement
	{
		public Measurement()
		{
			Timestamp = DateTime.Now;
		}

		public DateTime Timestamp { get; }

		public string unique_id { get; set; }

		public string meter_model { get; set; }

		public string wifi_ssid { get; set; }

		public string wifi_strength { get; set; }

		public int smr_version { get; set; }

		public int active_tariff { get; set; }

		public double active_power_w { get; set; }

		public double active_power_average_w { get; set; }

		public double montly_power_peak_w { get; set; }

		public string montly_power_peak_timestamp { get; set; }

		public double total_power_import_kwh { get; set; }

		public double total_power_import_t1_kwh { get; set; }

		public double total_power_import_t2_kwh { get; set; }

		public double total_power_export_kwh { get; set; }

		public double total_power_export_t1_kwh { get; set; }

		public double total_power_export_t2_kwh { get; set; }

		public double active_voltage_l1_v { get; set; }

		public double active_current_l1_a { get; set; }

		public double active_power_l1_w { get; set; }

		public double active_voltage_l2_v { get; set; }

		public double active_current_l2_a { get; set; }

		public double active_power_l2_w { get; set; }

		public double active_voltage_l3_v { get; set; }

		public double active_current_l3_a { get; set; }

		public double active_power_l3_w { get; set; }

		public static MeasurementDiff operator -(Measurement @new, Measurement old)
		{
			return new MeasurementDiff(old, @new);
		}

		public DateTime GetMontlyPowerPeakTimestamp()
		{
			return DateTime.ParseExact(montly_power_peak_timestamp, "yyMMddHHmmss", CultureInfo.InvariantCulture);
		}

		public static Measurement Deserialize(string json)
		{
			return JsonConvert.DeserializeObject<Measurement>(json);
		}

		public string Serialize()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}