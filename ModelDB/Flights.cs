//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirlineProgram.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flights
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flights()
        {
            this.Tickets = new HashSet<Tickets>();
        }
    
        public int Flight_code { get; set; }
        public string Flight_name { get; set; }
        public Nullable<int> Airline_code { get; set; }
        public Nullable<int> Airplane_code { get; set; }
        public Nullable<int> Departure_airport { get; set; }
        public Nullable<int> Arrival_airport { get; set; }
        public string Departure_dateTime { get; set; }
        public string Arrival_dateTime { get; set; }
        public Nullable<int> Place { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual Airlines Airlines { get; set; }
        public virtual Airplanes Airplanes { get; set; }
        public virtual Airports Airports { get; set; }
        public virtual Airports Airports1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
