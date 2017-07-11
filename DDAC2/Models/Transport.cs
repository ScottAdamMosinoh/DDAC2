using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDAC2.Models
{
    public class Transport
    {
        public int TransportID { get; set; }
        [ForeignKey("Ship")]
        public int ShipID { get; set; }
        public Ship Ship { get; set; }

        [ForeignKey("Container")]
        public int ContainerID { get; set; }
        public Container Container { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [ForeignKey("Shipyard")]
        public int ArrivalShipyardID { get; set; }
        public virtual ShipYard Shipyard { get; set; }

        [ForeignKey("Shipyard2")]
        public int DepartureShipyardID { get; set; }
        public virtual ShipYard Shipyard2 { get; set; }
    }
}