using System;
using System.ComponentModel;

namespace ZwabyAdminApp
{
	class SimpleMultiplierViewModel : INotifyPropertyChanged
	{
		// The class defines three public properties of type double, named Multiplicand, Multiplier, and Product.
		// Each property is backed by a private field.The set and get accessors of the first two proper- ties are public, 
		// but the set accessor of the Product property is protected to prevent it from being set outside the class while still allowing a descendant class to change it.

		double multiplicand, multiplier, product;

		public event PropertyChangedEventHandler PropertyChanged;

		// The set accessor of each property begins by checking whether the property value is actually chang- ing
		// If so, it sets the backing field to that value and calls a method named OnPropertyChanged with that property name.

		public double Multiplicand
		{
			set
			{
				if (multiplicand != value)
				{
					multiplicand = value;
					OnPropertyChanged("Multiplicand");
					UpdateProduct();
				}
			}
			get
			{
				return multiplicand;
			}
		}

		public double Multiplier
		{
			set
			{
				if (multiplier != value)
				{
					multiplier = value;
					OnPropertyChanged("Multiplier");
					UpdateProduct();
				}
			}
			get
			{
				return multiplier;
			}
		}

		// The set accessors for both the Multiplicand and Multiplier properties conclude by calling the UpdateProduct method.
		// This is the method that performs the job of multiplying the values of the two properties and setting a new value 
		// for the Product property, which then fires its own PropertyChanged event.

		public double Product
		{
			protected set
			{
				if (product != value)
				{
					product = value;
					OnPropertyChanged("Product");
				}
			}
			get
			{
				return product;
			}
		}

		void UpdateProduct()
		{
			Product = Multiplicand * Multiplier;
		}
	
		// The INotifyPropertyChanged interface does not require an OnPropertyChanged method, but ViewModel classes often include one to cut down the code repetition. 
		// It’s usually defined as protected in case you need to derive one ViewModel from another and fire the event in the derived class. 

		 protected void OnPropertyChanged(string propertyName)
		 {
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		 }
	}
}
