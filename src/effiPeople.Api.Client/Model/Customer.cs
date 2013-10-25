

namespace effiPeople.Api.Client.Model
{
    /// <summary>
    /// Un cliente de una compañía eléctrica
    /// </summary>
    public class Customer
    {
        public Customer()
        {
            Address = new Address();
        }

        public Customer(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Identificador único del cliente para la compañía eléctrica
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador fiscal (DNI, CIF.., etc)
        /// </summary>
        public string FiscalId { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Primer apellido
        /// </summary>
        public string FirstSurname { get; set; }

        /// <summary>
        /// Segundo apellido
        /// </summary>
        public string SecondSurname { get; set; }

        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Código ISO 639-1 del idioma por defecto en el que se le enviarán los informes al cliente
        /// </summary>
        /// <example>ca</example>
        public string DefaultLanguage { get; set; }

        /// <summary>
        /// Dirección principal del cliente
        /// </summary>
        public Address Address { get; set; }
    }
}