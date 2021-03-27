using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicoVehicle.BLL;
using UnicoVehicle.DTO;

namespace UnicoVehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostBuyingDetailController : Controller
    {
        private readonly IPostBuyingDetailBLL _postBuyingDetailBLL;
        bool _status;

        public PostBuyingDetailController(IPostBuyingDetailBLL postBuyingDetailBLL)
        {
            _postBuyingDetailBLL = postBuyingDetailBLL;
        }

        [HttpGet("{Id}")]
        public PostBuyingDetail GetPostBuyingDetailbyId(int id)
        {
            PostBuyingDetail postBuyingDetail = _postBuyingDetailBLL.GetbyId(id);
            return postBuyingDetail;
        }

        [HttpPost]
        public bool InsertPostBuyingDetail([FromBody] PostBuyingDetail postBuyingDetail)
        {
            _status = _postBuyingDetailBLL.InsertPostBuyingDetail(postBuyingDetail);
            return _status;
        }

        [HttpPut("{Id}")]
        public bool UpdatePostBuyingDetail([FromBody] PostBuyingDetail postBuyingDetail, int id)
        {
            _status = _postBuyingDetailBLL.UpdatePostBuyingDetail(postBuyingDetail, id);
            return _status;
        }
    }
}
