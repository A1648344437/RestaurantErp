using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantErp.Dto;
using RestaurantErp.Model;
using RestaurantErp.Model.Table;
using RestaurantErp.Service;

namespace RestaurantErp.Controllers
{
    /// <summary>
    /// 商品信息
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("LimitRequests")]//就是这里 允许跨域
    public class GoodsController : ControllerBase
    {
        private readonly IHostingEnvironment env;
        private readonly GoodsServer _goodsServer;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="goodsServer"></param>
        /// <param name="env"></param>
        public GoodsController(GoodsServer goodsServer, IHostingEnvironment env)
        {
            _goodsServer = goodsServer;
            this.env = env;
        }

        /// <summary>
        /// 获取常用商品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OftenGoods")]
        public IList<OftenGoodsDto> GetOftenGoodsList()
        {
            return _goodsServer.GetOftenGoodsList();
        }

        /// <summary>
        /// 获取所有商品信息 收银页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IList<GoodsListDto> Get()
        {
            IList<GoodsListDto> list = _goodsServer.GetGoodsList();
            return list;
        }

        /// <summary>
        /// 获取所有商品信息（后台商品管理）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllGoods")]
        public PagingInfo GetAllGoods(int pageSize,int pageIndex,string goodsType)
        {           
            PagingInfo result = _goodsServer.GetGoodsListAll(pageSize, pageIndex, goodsType);
            return result;
        }

        /// <summary>
        /// 根据Id获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public Goods Get(int id)
        {
            Goods goods = _goodsServer.GetGoodsById(id);
            return goods;
        }

        /// <summary>
        /// 添加一个商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post([FromBody] Goods goods)
        {
            if (goods != null)
            {
                goods.AddTime = DateTime.Now;
            }
            else
            {
                return false;
            }
            return _goodsServer.Insert(goods);
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateGoods")]
        public bool UpdateGoods([FromBody] Goods goods)
        {
            return _goodsServer.Update(goods);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("PostVue")]
        public bool PostVue()
        {
            return true;
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            return _goodsServer.Delete(id);
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [Route("upload")]
        [HttpPost]
        public async Task<string> Upload()
        {
            var date = Request;
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);
            string webRootPath = env.WebRootPath;
            string contentRootPath = env.ContentRootPath;

            var urls = string.Empty;

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string fileExt = formFile.FileName.Substring(formFile.FileName.LastIndexOf('.')); //文件扩展名
                    long fileSize = formFile.Length; //获得文件大小，以字节为单位
                    string newFileName = System.Guid.NewGuid().ToString().Replace("-", ""); //随机生成新的文件名

                    var relativePath = Path.Combine("Upload", DateTime.Now.ToString("yyyyMMdd"));
                    var absolutePath = Path.Combine(webRootPath, relativePath);

                    if (!Directory.Exists(absolutePath))
                    {
                        Directory.CreateDirectory(absolutePath);
                    }

                    using (var stream = new FileStream(Path.Combine(absolutePath, newFileName + fileExt), FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        //var state = fileService.Upload(newFileName, Path.Combine(relativePath, newFileName + fileExt),formFile.ContentType, "0");
                        //var serverName = _config.GetSection("ServerUrl").Value;

                        //urls += $"{serverName}/fss/file/get?id={newFileName}|";
                        urls += (Path.Combine(relativePath, (newFileName + fileExt)) + "|");
                    }
                }
            }

            return urls.TrimEnd('|');
        }
    }
}
