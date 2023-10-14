using System;

using HomeWizard.Data;

using Skyline.DataMiner.Scripting;
using Skyline.Protocol;

/// <summary>
/// DataMiner QAction Class.
/// </summary>
public static class QAction
{
	/// <summary>
	/// The QAction entry point.
	/// </summary>
	/// <param name="protocol">Link with SLProtocol process.</param>
	public static void Run(SLProtocolExt protocol)
	{
		try
		{
			var json = Convert.ToString(protocol.Httpdata);
			var measurement = Measurement.Deserialize(json);

			UpdateRealtimeParameters(protocol, measurement);

		}
		catch (Exception ex)
		{
			protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
		}
	}

	private static void UpdateRealtimeParameters(SLProtocolExt protocol, Measurement m)
	{
		protocol.SetParameters(
			(Parameter.uniqueid, m.unique_id),
			(Parameter.model, m.meter_model),
			(Parameter.wifi_ssid, m.wifi_ssid),
			(Parameter.wifi_strength, m.wifi_strength),
			(Parameter.smrversion, m.smr_version),
			(Parameter.activetariff, m.active_tariff),
			(Parameter.activepower, m.active_power_w),
			(Parameter.activepoweraverage, m.active_power_average_w),
			(Parameter.monthlypowerpeak, m.montly_power_peak_w),
			(Parameter.monthlypowerpeaktime, m.GetMontlyPowerPeakTimestamp().ToOADate()),
			(Parameter.totalpowerimport, m.total_power_import_kwh),
			(Parameter.totalpowerimportt1, m.total_power_import_t1_kwh),
			(Parameter.totalpowerimportt2, m.total_power_import_t2_kwh),
			(Parameter.totalpowerexport, m.total_power_export_kwh),
			(Parameter.totalpowerexportt1, m.total_power_export_t1_kwh),
			(Parameter.totalpowerexportt2, m.total_power_export_t2_kwh)
		);

		var rows = new[]
		{
			new PhasestableQActionRow
			{
				Phasestablephase = "1",
				Phasestablevoltage = m.active_voltage_l1_v,
				Phasestablecurrent = m.active_current_l1_a,
				Phasestablepower = m.active_power_l1_w,
			},
			new PhasestableQActionRow
			{
				Phasestablephase = "2",
				Phasestablevoltage = m.active_voltage_l2_v,
				Phasestablecurrent = m.active_current_l2_a,
				Phasestablepower = m.active_power_l2_w,
			},
			new PhasestableQActionRow
			{
				Phasestablephase = "3",
				Phasestablevoltage = m.active_voltage_l3_v,
				Phasestablecurrent = m.active_current_l3_a,
				Phasestablepower = m.active_power_l3_w,
			},
		};

		protocol.phasestable.FillArray(rows);
	}
}
