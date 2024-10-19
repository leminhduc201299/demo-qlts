using Microsoft.Extensions.Options;
using Demo.QLTS.Core.Entities;
using Demo.QLTS.Core.Interfaces.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QLTS.Infrastructure.Repository
{
    public class ImportRepository : BaseRepository<ImportDetail>, IImportRepository
    {
        public ImportRepository(IOptions<DemoQLTSDatabaseSettings> demoQLTSDatabaseSettings) : base(demoQLTSDatabaseSettings)
        {

        }

        /// <summary>
        /// Thực hiện thêm 1 bản ghi chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public async Task<int> InsertImport(ImportDetail importDetail)
        {
            var param = new Dictionary<string, object>()
            {
                { "$so_phieu", importDetail.so_phieu },
                { "$ngay_lap_phieu", importDetail.ngay_lap_phieu },
                { "$ma_vt", importDetail.ma_vt },
                { "$ten_vt", importDetail.ten_vt },
                { "$dvt", importDetail.dvt },
                { "$sl_nhap", importDetail.sl_nhap },
                { "$sl_xuat", importDetail.sl_xuat }
            };
            var res = await ExecuteUsingStoredProcedure("them_nhapkhau", param);

            return res;
        }

        /// <summary>
        /// Thực hiện tìm kiếm chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public async Task<List<ImportDetail>> SearchImport(string textSearch)
        {
            var param = new Dictionary<string, object>()
            {
                { "$text_search", textSearch }
            };

            var res = await QueryUsingStoredProcedure<ImportDetail>("timkiem_nhapkhau", param);

            return res;
        }

        /// <summary>
        /// Thực hiện xóa chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public async Task<int> DeleteImport(string vote, string materialCode)
        {
            var param = new Dictionary<string, object>()
            {
                { "$so_phieu", vote },
                { "$ma_vt", materialCode }
            };

            var res = await ExecuteUsingStoredProcedure("xoa_nhapkhau", param);

            return res;
        }

        /// <summary>
        /// Thực hiện check trùng chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public async Task<bool> CheckDuplicateImport(string vote, string materialCode)
        {
            var param = new Dictionary<string, object>()
            {
                { "$so_phieu", vote },
                { "$ma_vt", materialCode }
            };

            var res = await QueryUsingStoredProcedure<ImportDetail>("checktrung_nhapkhau", param);

            if (res != null && res.Count > 0)
            {
                return false;
            };

            return true;
        }
    }
}
