using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using effiPeople.Api.Client.Model.Common;
using effiPeople.Api.Client.Model.Extensions;

namespace effiPeople.Api.Client.Model
{
    /// <summary>
    ///     Medida de lectura y consumo.
    /// </summary>
    public class Measure
    {       
        public Measure(string id, string usagePointId, MeasureType measureType, DateTime startDate, DateTime endDate, byte period, long consumption)
            : this(id, usagePointId, null, measureType, startDate, endDate, period, consumption)
        {

        }

        public Measure(string id, string usagePointId, string meterId, MeasureType measureType, DateTime startDate, DateTime endDate, byte period, long consumption)
        {
            Id = id;
            UsagePointId = usagePointId;
            MeterId = meterId;
            MeasureType = measureType;
            StartDateTime = startDate;
            EndDateTime = endDate;
            Period = period;
            Consumption = consumption;
        }

        public Measure()
        {
            Period = 1;
        }

        /// <summary>
        /// Identificador único de la medida.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Identificador del punto de suministro. Opcional si se especifica un contador.
        /// </summary>
        public string UsagePointId { get; set; }

        /// <summary>
        ///     Identificador del contador. Opcional si se especifica el punto de suministro
        /// </summary>
        public string MeterId { get; set; }

        /// <summary>
        /// Identificador del contrato al que está asociada la medida
        /// </summary>
        public string ContractId { get; set; }

        /// <summary>
        ///     Identificador de la factura donde se ha facturado esta medida
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        ///     Franja horaria entre 1 y 7
        /// </summary>
        public byte Period { get; set; }

        /// <summary>
        ///     Fecha de inicio de la medida en segundos desde el 1 de enero de 1970.
        /// </summary>
        [JsonProperty]
        protected long StartDate { get; set; }

        /// <summary>
        ///     Fecha final de la medida en segundos desde el 1 de enero de 1970.
        /// </summary>
        [JsonProperty]
        protected long EndDate { get; set; }

        /// <summary>
        ///     Lectura del contador inicial
        /// </summary>
        public long? StartReading { get; set; }

        /// <summary>
        ///     Lectura del contador final
        /// </summary>
        public long? EndReading { get; set; }

        /// <summary>
        ///     Consumo desde la última lectura.
        /// </summary>
        public long Consumption { get; set; }

        /// <summary>
        ///     Identificador de la tarifa aplicada. Opcional.
        /// </summary>
        public string TariffId { get; set; }

        /// <summary>
        ///     Coste total
        /// </summary>
        public double? Cost { get; set; }

        /// <summary>
        ///     Impuestos
        /// </summary>
        public double? Taxes { get; set; }

        /// <summary>
        ///     Coste unitario
        /// </summary>
        public double? UnitCost { get; set; }

        /// <summary>
        ///     Coste del consumo desde la última factura.
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        ///     Tipo de medida. Si no se especifica se considerará activa.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MeasureType MeasureType { get; set; }

        /// <summary>
        ///     Fecha inicial de la lectura
        /// </summary>
        [JsonIgnore]
        public DateTime StartDateTime
        {
            get { return StartDate.ToDateTimeFromEpochInSeconds(); }
            set { StartDate = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        ///     Fecha final de la lectura
        /// </summary>
        [JsonIgnore]
        public DateTime EndDateTime
        {
            get { return EndDate.ToDateTimeFromEpochInSeconds(); }
            set { EndDate = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        ///  Origen de la medida (Telemedida, etc...)
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Si la medida es provisional, es decir, que está a falta de confirmación
        /// </summary>
        public bool? IsProvisional { get; set; }



        /// <summary>
        ///     Duración en segundos
        /// </summary>
        public long Duration
        {
            get { return (long)(EndDateTime - StartDateTime).TotalSeconds; }
        }
    }
}