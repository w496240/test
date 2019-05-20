using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BROK5719.View;

namespace BROK5719.ViewModel
{
	public class MainViewModel
	{
		public ICommand Step1Command { get; set; }
		public ICommand Step2Command { get; set; }

		public MainViewModel()
		{
			Step1Command = new RelayCommand(x => Step1VShow());
			Step2Command = new RelayCommand(x => Step2VShow());
		}

		private void Step1VShow()
		{
			Step1 step1 = new Step1();
			step1.ShowDialog();
		}

		private void Step2VShow()
		{
			Step2 step2 = new Step2();
			step2.ShowDialog();
		}
	}
}
