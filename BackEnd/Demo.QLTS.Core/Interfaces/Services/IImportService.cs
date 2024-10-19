using Microsoft.AspNetCore.Http;
using Demo.QLTS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QLTS.Core.Interfaces.Services
{
    public interface IImportService : IBaseService<ImportDetail>
    {
        /// <summary>
        /// Thực hiện thêm 1 bản ghi chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public Task<ServiceResult> InsertImport(ImportDetail importDetail);

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
    }
}
