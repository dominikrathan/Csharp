using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UnreflectedSerializer {
	
	public class RootDescriptor<T>
	{

		public string Name;
		public delegate object GetPropertyDelegate(T t);

		public Dictionary<string, GetPropertyDelegate> properties = new Dictionary<string, GetPropertyDelegate>();
		public void Serialize(TextWriter writer, T instance)
		{
			writer.WriteLine(GetSerialized(instance));
		}

		public string GetSerialized(T instance)
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append(Name != null ? $"<{Name}>\n" : "\n");
			foreach (var d in properties)
			{
				stringBuilder.Append($"<{d.Key}>");
				stringBuilder.Append(d.Value(instance));
				stringBuilder.Append($"</{d.Key}>\n");
			}
			stringBuilder.Append((Name != null) ? $"</{Name}>\n" : "");

			return stringBuilder.ToString();
		}
	}

	class Address {
		public string Street { get; set; }
		public string City { get; set; }
	}

	class Country {
		public string Name { get; set; }
		public int AreaCode { get; set; }
	}

	class PhoneNumber {
		public Country Country { get; set; }
		public int Number { get; set; }
	}

	class Person {
		public string FirstName { get; set; }
		public string LastName { get; set; }	
		public Address HomeAddress { get; set; }
		public Address WorkAddress { get; set; }
		public Country CitizenOf { get; set; }
		public PhoneNumber MobilePhone { get; set; }
	}
	
	class Program {
		static void Main(string[] args) {
			RootDescriptor<Person> rootDesc = GetPersonDescriptor();
			
			var czechRepublic = new Country { Name = "Czech Republic", AreaCode = 420 };
			var person = new Person {
				FirstName = "Pavel",
				LastName = "Jezek",
				HomeAddress = new Address { Street = "Patkova", City = "Prague" },
				WorkAddress = new Address { Street = "Malostranske namesti", City = "Prague" },
				CitizenOf = czechRepublic,
				MobilePhone = new PhoneNumber { Country = czechRepublic, Number = 123456789 }
			};

			rootDesc.Serialize(Console.Out, person);
        }
		
		static RootDescriptor<Person> GetPersonDescriptor() {
			
			var personDescriptor = new RootDescriptor<Person>();
			personDescriptor.Name = nameof(Person);
			
			personDescriptor.properties.Add(nameof(Person.FirstName),person => person.FirstName);
			personDescriptor.properties.Add(nameof(Person.LastName),person => person.LastName);
			personDescriptor.properties.Add(nameof(Person.HomeAddress), person => new AddressProperty {Address = person.HomeAddress});
			personDescriptor.properties.Add(nameof(Person.WorkAddress), person => new AddressProperty {Address = person.WorkAddress});
			personDescriptor.properties.Add(nameof(Person.CitizenOf), person => new CountryProperty {Country = person.CitizenOf} );
			personDescriptor.properties.Add(nameof(Person.MobilePhone), person =>new PhoneNumberProperty {PhoneNumber = person.MobilePhone});
		
			return personDescriptor;
		}
		
		class AddressProperty 
		{
			public Address Address { get; set; }
		
			public override string ToString()
			{
				var addressDescriptor = GetAddressDescriptor();
				return addressDescriptor.GetSerialized(Address);
			}
		}

		class CountryProperty
		{
			public Country Country { get; set; }

			public override string ToString()
			{
				var countryDescriptor = GetCountryDescriptor();
				return countryDescriptor.GetSerialized(Country);
			}
		}

		class PhoneNumberProperty
		{
			public PhoneNumber PhoneNumber { get; set; }

			public override string ToString()
			{
				var phoneDescriptor = GetPhoneNumberDescriptor();
				return phoneDescriptor.GetSerialized(PhoneNumber);
			}
		}

		static RootDescriptor<Address> GetAddressDescriptor()
		{
			var addressDescriptor = new RootDescriptor<Address>();
		
			addressDescriptor.properties.Add(nameof(Address.City), address => address.City);
			addressDescriptor.properties.Add(nameof(Address.Street), address => address.Street);
			
			return addressDescriptor;
		}

		static RootDescriptor<Country> GetCountryDescriptor()
		{
			var countryDescriptor = new RootDescriptor<Country>();
			
			countryDescriptor.properties.Add(nameof(Country.Name), country => country.Name);
			countryDescriptor.properties.Add(nameof(Country.AreaCode), country => country.AreaCode.ToString());

			return countryDescriptor;
		}

		static RootDescriptor<PhoneNumber> GetPhoneNumberDescriptor()
		{
			var phoneNumberDescriptor = new RootDescriptor<PhoneNumber>();
			var countryDescriptor = GetCountryDescriptor();
			
			phoneNumberDescriptor.properties.Add(nameof(PhoneNumber.Country), number => countryDescriptor.GetSerialized(number.Country));
			phoneNumberDescriptor.properties.Add(nameof(PhoneNumber.Number),number => number.Number.ToString());

			return phoneNumberDescriptor;
		}
	}
}
