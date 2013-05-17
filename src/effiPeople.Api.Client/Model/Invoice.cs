using System;
using Newtonsoft.Json;
using effiPeople.Api.Client.Model.Extensions;

namespace effiPeople.Api.Client.Model
{
    public class Invoice
    {
        /// <summary>
        ///     Número de factura
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        ///     Identificador del cliente.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        ///     Identificador del contrato del cliente.
        /// </summary>
        public string ContractId { get; set; }

        /// <summary>
        ///     Identificador del punto de suministro.
        /// </summary>
        public string UsagePointId { get; set; }

        /// <summary>
        ///     CNAE
        /// </summary>
        public string ActivityCode { get; set; }

        /// <summary>
        ///     Identificador de la tarifa aplicada. Opcional ya que estará en el contrato. Sirve como comprobación.
        /// </summary>
        public string TariffId { get; set; }

        /// <summary>
        ///     Potencia contratada en Watios. Opcional ya que estará en el contrato. Sirve como comprobación.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        ///     Consumo total de energía activa
        /// </summary>
        public long ActiveEnergyConsumption { get; set; }

        /// <summary>
        ///     Consumo total de energía reactiva
        /// </summary>
        public long ReactiveEnergyConsumption { get; set; }

        /// <summary>
        ///     Si las medidas de esta factura son estimadas.
        /// </summary>
        public bool IsConsumptionEstimated { get; set; }

        /// <summary>
        ///     Coste de energía activa
        /// </summary>
        public double ActiveEnergyCost { get; set; }

        /// <summary>
        ///     Coste de energía activa
        /// </summary>
        public double ReactiveEnergyCost { get; set; }

        /// <summary>
        ///     Coste de potencia
        /// </summary>
        public double PowerCost { get; set; }

        /// <summary>
        ///     Coste de servicios añadidos
        /// </summary>
        public double ServicesCost { get; set; }

        /// <summary>
        ///     Coste de alquileres como equipos de medida
        /// </summary>
        public double RentalsCost { get; set; }

        /// <summary>
        ///     Coste de otros conceptos
        /// </summary>
        public double OtherCost { get; set; }

        /// <summary>
        ///     Total sin incluir impuestos
        /// </summary>
        public double Subtotal { get; set; }

        /// <summary>
        ///     Impuestos
        /// </summary>
        public double OtherTaxes { get; set; }

        /// <summary>
        ///     Código de la moneda de la factura según ISO 4217. Si no se indica será EUR (Euro)
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        ///     Fecha de la factura en segundos desde el 1 de enero de 1970
        /// </summary>
        public long InvoiceDate { get; set; }

        /// <summary>
        ///     Fecha inicial del contrato
        /// </summary>
        [JsonIgnore]
        public DateTime Date
        {
            get { return InvoiceDate.ToDateTimeFromEpochInSeconds(); }
            set { InvoiceDate = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        ///     Día inicial del periodo facturado de inicial del periodo de energía facturado
        /// </summary>
        public long PeriodStart { get; set; }

        /// <summary>
        ///     Fecha inicial del contrato
        /// </summary>
        [JsonIgnore]
        public DateTime PeriodStartDate
        {
            get { return PeriodStart.ToDateTimeFromEpochInSeconds(); }
            set { PeriodStart = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        ///     Día final del periodo facturado y no incluído.
        /// </summary>
        /// <
        public long PeriodEnd { get; set; }

        /// <summary>
        ///     Fecha inicial del contrato
        /// </summary>
        [JsonIgnore]
        public DateTime PeriodEndDate
        {
            get { return PeriodEnd.ToDateTimeFromEpochInSeconds(); }
            set { PeriodEnd = value.ToEpochTimeInSeconds(); }
        }

        /// <summary>
        ///     IVA
        /// </summary>
        public double Vat { get; set; }

        /// <summary>
        ///     Otros impuestos, como el impuesto eléctrico
        /// </summary>
        public double TotalTaxes { get; set; }

        /// <summary>
        ///     Importe total de la factura incluídos impuestos
        /// </summary>
        public double Total { get; set; }
    }
}