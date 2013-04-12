using System.Collections.Generic;

namespace effiPeople.Api.Client.Model
{
    /// <summary>
    /// Punto de suministro
    /// </summary>
    public class UsagePoint 
    {
        /// <summary>
        /// 
        /// </summary>
        public UsagePoint()
        {
            Address = new Address();
            Meters = new List<Meter>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public UsagePoint(string id) : this()
        {
            this.Id = id;
        }

        /// <summary>
        /// Identificador único del punto de suministro. Normalmente el CUPS
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Dirección del punto de suministro
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Contadores asociados al punto de suministro.
        /// </summary>
        public List<Meter> Meters { get; set; }
    }

    
}