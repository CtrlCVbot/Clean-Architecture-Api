using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Port
{
    public sealed class PortInfo_Object
    {
        public long Idx { get; set; }
        public int? Type { get; set; }
        public string? Code { get; set; }
        public string? NameE { get; set; }
        public string? Name { get; set; }
        public string? CntryCode { get; set; }
        public string? CntryNameE { get; set; }
        public string? CntryName { get; set; }
        public string? CntintCode { get; set; }
        public string? CntintNameE { get; set; }
        public string? CntintName { get; set; }
        public int? UseYN { get; set; }
        public int? RegUserIdx { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? RegTime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpTime { get; set; }
        public int? UpUserIdx { get; set; }
    }
}
