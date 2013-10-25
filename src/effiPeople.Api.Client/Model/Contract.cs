using System;
using Newtonsoft.Json;
using effiPeople.Api.Client.Model.Common;
using effiPeople.Api.Client.Model.Extensions;

namespace effiPeople.Api.Client.Model
{
    /// <summary>
    /// Contrato de un cliente
    /// </summary>
    public class Contract
    {
        public Contract()
        {
        }

        /// <summary>
        /// Identificador del contrato
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador del cliente
        /// </summary>
        public string CustomerId { get; set; }
        
        [JsonProperty]
        protected long Start { get; set; }

        /// <summary>
        /// Fecha inicial del contrato
        /// </summary>
        [JsonIgnore]
        public DateTime StartDate
        {
            get { return Start.ToDateTimeFromEpochInSeconds(); }
            set { Start = value.ToEpochTimeInSeconds(); }
        }

        [JsonProperty]
        protected long? End { get; set; }

        /// <summary>
        /// Fecha final del contrato, si existe
        /// </summary>
        public DateTime? EndDate
        {
            get { return End.ToDateTimeFromEpochInSeconds(); }
            set { End = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        /// Identificador de la tarifa
        /// </summary>
        public string TariffId { get; set; }

        /// <summary>
        /// Potencia contratada en watios
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Versión del contrato
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Código CNAE
        /// </summary>
        public string ActivityCode { get; set; }

        /// <summary>
        /// CUPS
        /// </summary>
        public string UsagePointId { get; set; }

        /// <summary>
        /// Tipo de cliente. Opcional
        /// </summary>
        public CustomerType? CustomerType { get; set; }

        /// <summary>
        ///     Dirección
        /// </summary>
        public Address Address { get; set; }
    }
}