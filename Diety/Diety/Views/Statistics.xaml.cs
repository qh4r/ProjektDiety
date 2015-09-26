using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diety.ViewModel;
using Diety.ViewModel.PropertyGroups;
using Telerik.Windows.Controls.ChartView;

namespace Diety.Views
{
	/// <summary>
	/// Interaction logic for Statistics.xaml
	/// </summary>
	public partial class Statistics : Page
	{
		#region Public Properties

		public StatisticsViewModel StatsViewModel { get; set; }

		#endregion

		#region C-tors

		public Statistics()
		{
			InitializeComponent();
			StatsViewModel = DataContext as StatisticsViewModel;
			if (StatsViewModel != null)
			{
				StatsViewModel.LoadData += ReloadChart;
			}
		}		

		#endregion

		#region Private Methods

		/// <summary>
		/// Reloads the chart.
		/// </summary>
		/// <param name="chartData">The chart data.</param>
		private void ReloadChart(IEnumerable<ChartData> chartData)
		{
			LineSeries series = (LineSeries) Chart.Series[0];

			series.CategoryBinding = new PropertyNameDataPointBinding() {PropertyName = "Date"};
			series.ValueBinding = new PropertyNameDataPointBinding() {PropertyName = "Value"};

			series.DataContext = chartData;
		}

		#endregion

	}
}
