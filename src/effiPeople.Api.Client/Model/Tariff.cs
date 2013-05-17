using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using effiPeople.Api.Client.Model.Common;
using effiPeople.Api.Client.Model.Extensions;

namespace effiPeople.Api.Client.Model
{
    public class Tariff
    {
        private TariffPeriods _tariffPeriods = new TariffPeriods();

        /// <summary>
        ///     Identificador único de la tarifa
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Nombre comercial de la tarifa
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Equivalente de la tarifa de acceso.  Uno de estos valores: 2.0A, 2.0DHA, 2.0DHS, 2.1A, 2.1DHA, 2.1DHS, 3.0A
        /// </summary>
        public string TariffType { get; set; }

        /// <summary>
        ///     Shortcut al identificador único de la tarifa
        /// </summary>
        [JsonIgnore]
        public string TariffId
        {
            get { return Id; }
            set { Id = value; }
        }

        /// <summary>
        ///     Versión de la tarifa
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Fecha inicial de la tarifa. En segundos desde el 1 de enero de 1970
        /// </summary>
        public long Start { get; set; }

        /// <summary>
        ///     Fecha inicial de la tarifa
        /// </summary>
        [JsonIgnore]
        public DateTime StartDate
        {
            get { return Start.ToDateTimeFromEpochInSeconds(); }
            set { Start = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        ///     Fecha final de la tarifa. En segundos desde el 1 de enero de 1970
        /// </summary>
        public long? End { get; set; }

        /// <summary>
        ///     Fecha final de la tarifa
        /// </summary>
        [JsonIgnore]
        public DateTime? EndDate
        {
            get { return End.ToDateTimeFromEpochInSeconds(); }
            set { End = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        /// Datos de precios de hasta 7 periodos
        /// </summary>
        public TariffPeriods Periods
        {
            get { return _tariffPeriods; }
            set { _tariffPeriods = value; }
        }
    }

    public class TariffPeriods
    {
        /// <summary>
        ///     Precios del periodo horario 1
        /// </summary>
        public PeriodPrices P1 { get; set; }

        /// <summary>
        ///     Precios del periodo horario 2
        /// </summary>
        public PeriodPrices P2 { get; set; }

        /// <summary>
        ///     Precios del periodo horario 3
        /// </summary>
        public PeriodPrices P3 { get; set; }

        /// <summary>
        ///     Precios del periodo horario 4
        /// </summary>
        public PeriodPrices P4 { get; set; }

        /// <summary>
        ///     Precios del periodo horario 5
        /// </summary>
        public PeriodPrices P5 { get; set; }

        /// <summary>
        ///     Precios del periodo horario 6
        /// </summary>
        public PeriodPrices P6 { get; set; }

        /// <summary>
        ///     Precios del periodo horario 7
        /// </summary>
        public PeriodPrices P7 { get; set; }
    }
}
