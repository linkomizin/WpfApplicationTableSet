namespace EFLibrary.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        public int Room_RoomId { get; set; }

        [StringLength(20)]
        public string Account { get; set; }

        public virtual People People { get; set; }

        public virtual Rooms Rooms { get; set; }
    }
}
