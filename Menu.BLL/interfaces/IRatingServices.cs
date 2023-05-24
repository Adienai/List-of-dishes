using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.BLL.interfaces
{
    internal class IRatingServices
    {
        public Task<RatingDto> CreateAsync(RatingDto entity);
        public Task<RatingDto> DeleteAsync(int id);
        public Task<RatingDto> UpdateAsync(RatingDto entity);
        public Task<IEnumerable<RatingDto>> GetAsync();
        public Task<RatingDto> GetAsync(int id);
    }
}
