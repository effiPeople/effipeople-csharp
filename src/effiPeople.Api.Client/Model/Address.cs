

namespace effiPeople.Api.Client.Model
{
    public class Address
    {
        /// <summary>
        /// Dirección
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Código postal
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Municipio
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Código INE del Municipio
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// Provincia
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Código INE de la provincia
        /// </summary>
        public string ProvinceCode { get; set; }

        /// <summary>
        /// País
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Código del país. Para España ES
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Referencia castastral
        /// </summary>
        public string ParcelNumber { get; set; }

        public Address()
        {
        }

        public Address(string street, string postalCode, string city, string province, string country)
        {
            Street = street;
            PostalCode = postalCode;
            City = city;
            Province = province;
            Country = country;
        }

        public override bool Equals(object obj)
        {
        
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var a = (Address)obj;


            return (City == a.City)
                 && (CityCode == a.CityCode)
                   && (Country == a.Country)
                   && (CountryCode == a.CountryCode)
                   && (PostalCode == a.PostalCode)
                   && (ParcelNumber == a.ParcelNumber)
                   && (Province == a.Province)
                   && (ProvinceCode == a.ProvinceCode)
                   && (Street == a.Street);
        }

        public override int GetHashCode()
        {
            return new { City, CityCode, Country, CountryCode, PostalCode, ParcelNumber, Province, ProvinceCode, Street }.GetHashCode();
        }
    }
}