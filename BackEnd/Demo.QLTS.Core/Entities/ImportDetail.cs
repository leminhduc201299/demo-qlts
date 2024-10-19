using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QLTS.Core.Entities
{
    public class ImportDetail
    {
        public string so_phieu { get; set; }

        public DateTime? ngay_lap_phieu { get; set; }

        public string ma_vt { get; set; }

        public string ten_vt { get; set; }

        public string dvt { get; set; }

        public float sl_nhap { get; set; }

        public float sl_xuat { get; set; }
    }
}
