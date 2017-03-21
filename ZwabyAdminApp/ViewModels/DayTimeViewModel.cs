using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ZwabyAdminApp
{
	public class DayTimeViewModel : INotifyPropertyChanged
	{
		// Public properties in ViewModels usually have private backing fields.

		DateTime dateTime = DateTime.Now;

		public event PropertyChangedEventHandler PropertyChanged;

		public DayTimeViewModel()
		{
			Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
		}

		bool OnTimerTick()
		{
			DateTime = DateTime.Now;
			return true;
		}

		// The only public property in this class is called DateTime of type DateTime, and it is associated with a private backing field named dateTime. 

		public DateTime DateTime
		{
			// The set accessor of the DateTime property is private to the class, and it’s updated every 15 milliseconds from the timer callback.
			// The set accessor is constructed in a very standard way for ViewModels: 

			private set
			{
				// It first checks whether the value being set to the property is different from the dateTime backing field.
				// If not, it sets that backing field from the incoming value and fires the PropertyChanged handler with the name of the property.

				if (dateTime != value)
				{
					dateTime = value;

					// Fire event
					PropertyChangedEventHandler handler = PropertyChanged;

					if (handler != null)
					{
						handler(this, new PropertyChangedEventArgs("DateTime"));
					}
				}
			}

			// The get accessor simply returns the dateTime backing field.

			get
			{
				return dateTime;
			}
		}
	}
}