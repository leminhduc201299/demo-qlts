using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Demo.QLTS.Core.Entities;
using Demo.QLTS.Core.Interfaces.Repository;
using Demo.QLTS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QLTS.Core.Services
{
    public class ImportService : BaseService<ImportDetail>, IImportService
    {
        IHostingEnvironment _environment;
        IImportRepository _importRepository;

        public ImportService(IHostingEnvironment environment, IBaseRepository<ImportDetail> baseRepository, IImportRepository importRepository) : base(baseRepository)
        {
            _environment = environment;
            _importRepository = importRepository;
        }

        /// <summary>
        /// Thực hiện thêm 1 bản ghi chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public async Task<ServiceResult> InsertImport(ImportDetail importDetail)
        {
            var serviceResult = new ServiceResult();

            if (!ValidateRequire(importDetail))
            {
                serviceResult.Success = false;
                serviceResult.UserMsg = "Bạn phải nhập đủ thông tin các trường";
                return serviceResult;
            }

            var validateDuplicate = await ValidateDuplicate(importDetail);
            if (!validateDuplicate)
            {
                serviceResult.Success = false;
                serviceResult.UserMsg = "Chi tiết xuất nhập khẩu bị trùng";
                return serviceResult;
            }

            var res = await _importRepository.InsertImport(importDetail);
            serviceResult.Data = res;

            return serviceResult;
        }

        /// <summary>
        /// Thực hiện validate require chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public bool ValidateRequire(ImportDetail importDetail)
        {
            if (String.IsNullOrEmpty(importDetail.so_phieu) || String.IsNullOrEmpty(importDetail.ngay_lap_phieu?.ToString()) || 
                String.IsNullOrEmpty(importDetail.ma_vt) || String.IsNullOrEmpty(importDetail.ten_vt) || String.IsNullOrEmpty(importDetail.dvt))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Thực hiện validate trung chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public async Task<bool> ValidateDuplicate(ImportDetail importDetail)
        {
            var res = await _importRepository.CheckDuplicateImport(importDetail.so_phieu, importDetail.ma_vt);

            return res;
        }

        /// <summary>
        /// Thực hiện tìm kiếm chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public async Task<List<ImportDetail>> SearchImport(string textSearch)
        {
            var res = await _importRepository.SearchImport(textSearch);

            return res;
        }

        /// <summary>
        /// Thực hiện xóa chi tiết xuất nhập khẩu
        /// </summary>
        /// </returns>
        public async Task<int> DeleteImport(string vote, string materialCode)
        {
            var res = await _importRepository.DeleteImport(vote, materialCode);

            return res;
        }
    }
}
