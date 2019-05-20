using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BROK5719.Annotations;
using BROK5719.Model;

namespace BROK5719.ViewModel
{
	public class Step2ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand CliclCommand { get; set; }
		private MainDotLiquid MainDotLiquid;
		public Step2ViewModel()
		{
			CliclCommand = new RelayCommand(x => GenerateHtml());
			MainDotLiquid = new MainDotLiquid();
		}

		private string template { get; set; } = @"<div>
  <div>{{ article.created_at | date: ""%e %B %Y, %H:%M"" }}</div>
  <div>{{ article.rubric | upcase }}</div>
  <div>{{ article.title }}</div>
  <div>{{ article.abstract }}</div>
  <div><a href=""{{ article.url }}"">Читать далее</a></div>
  <div><img src=""{{ article.image_url }}""></div>
</div>";
		public string Template
		{
			get { return template; }
			set
			{
				template = value;
				OnPropertyChanged(nameof(Template));
			}
		}

		private string teamplateName = "article";
		public string TemplateName
		{
			get { return teamplateName; }
			set
			{
				teamplateName = value;
				OnPropertyChanged(nameof(TemplateName));
			}
		}

		private string text { get; set; } = @"{
  ""created_at"": ""2019-03-06T06:06:00"",
  ""rubric"": ""Российский рынок"",
  ""title"": ""Прогнозы и комментарии. Падаем шесть сессий подряд"",
  ""abstact"": ""Несмотря на то, что российский рынок в общем и целом пока все еще продолжает консолидироваться в боковом формате, нельзя не отметить, что в это же время наблюдается медленное падение на протяжении уже шести сессий подряд. Пусть индекс МосБиржи за этот период прошел расстояние всего лишь в 1,1% вниз, но сам факт отсутствия желающих активно покупать настораживает. Покупательная активность инвесторов совсем невысокая."",
  ""url"": ""https://bcs-express.ru/novosti-i-analitika/prognozy-i-kommentarii-padaem-shest-sessii-podriad"",
  ""image_url"": ""https://bcs-express.ru/static/articlehead/4789.jpg""
}";
		public string Text
		{
			get { return text; }
			set
			{
				text = value;
				OnPropertyChanged(nameof(Text));
			}
		}

		private string html { get; set; }
		public string Html
		{
			get { return html; }
			set
			{
				html = value;
				OnPropertyChanged(nameof(Html));
			}
		}

		private void GenerateHtml()
		{
			Html = MainDotLiquid.RenderStep2(Template, TemplateName, Text);
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
