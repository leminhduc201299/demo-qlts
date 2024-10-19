using Demo.QLTS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QLTS.Core.Interfaces.Repository
{
    public interface IImportRepository : IBaseRepository<ImportDetail>
    {

        /// <summary>
        /// Thực hiện thêm 1 bản ghi chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public Task<int> InsertImport(ImportDetail importDetail);

        /// <summary>
        /// Thực hiện tìm kiếm chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public Task<List<ImportDetail>> SearchImport(string textSearch);

        /// <summary>
        /// Thực hiện xóa chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public Task<int> DeleteImport(string vote, string materialCode);

        /// <summary>
        /// Thực hiện check trùng chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public Task<bool> CheckDuplicateImport(string vote, string materialCode);
    }
}
