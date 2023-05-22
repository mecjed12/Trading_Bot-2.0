using DataBase.DataContext;
using DataBase.Helper;
using MarketDataService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketDataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly IHistoricalDataService _dataHistoricalDataService;

        public DataController(DataBaseContext dataBaseContext, IHistoricalDataService dataHistoricalDataService)
        {
            _dataBaseContext = dataBaseContext;
            _dataHistoricalDataService = dataHistoricalDataService;
        }

        // GET: api/<DataController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataController>
        [HttpPost("collectdata")]
        public async Task<IActionResult> CollectHistoricalData()
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _dataHistoricalDataService.ScrapTheHistoricalData(true);
                return Ok(ResponseHandler.GetApiResponse(responseType, "Collected Complete"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost("collectdataAndSaveAsCsv")]
        public async Task<IActionResult> SaveHistoricalDataAsCsv()
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _dataHistoricalDataService.CreateAndSaveCsvData();
                return Ok(ResponseHandler.GetApiResponse(responseType, "Successfully Create CsvFile"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<DataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataController>/5
        [HttpDelete("deleteHistoricalDataSet/{id}")]
        public async Task<IActionResult> DeleteHistoricalDataSet(int id)
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _dataHistoricalDataService.DeleteHistoricalDataSetAsync(id);
                return Ok(ResponseHandler.GetApiResponse(responseType, "Delete the dataset successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
