//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DDACUkraineAirlines.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Booking
    {
        public int FlightID { get; set; }
        public string FlightName { get; set; }
        [Display (Name = "Depature City")]
        public string Dept_City { get; set; }
        [Display(Name = "Arrival City")]
        public string Arrival_City { get; set; }
        [Display(Name = "Depature Date")]
        public string Dept_Date { get; set; }
        [Display(Name = "Arrival Date")]
        public string Return_Date { get; set; }
        public Nullable<double> Price { get; set; }
        [Display(Name = "Seat Number")]
        public Nullable<int> SeatNumber { get; set; }
    }
}
