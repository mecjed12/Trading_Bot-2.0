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
        private readonly IHistoricalDataService _dataHistoricalDataService;
        private readonly ITickerDayDataService _tickerDayDataService;
        private readonly ITickerHourDataService _tickerHourDataService;

        public DataController(IHistoricalDataService dataHistoricalDataService,ITickerDayDataService tickerDataService,ITickerHourDataService tickerHourDataService)
        {
            _dataHistoricalDataService = dataHistoricalDataService;
            _tickerDayDataService = tickerDataService;
            _tickerHourDataService = tickerHourDataService;
        }

        // GET: api/<DataController>
        [HttpPost("collectTickerDaydata")]
        public async Task<IActionResult> CollectTickerDayData()
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _tickerDayDataService.CollectingTickerDayDataAsync();
                return Ok(ResponseHandler.GetApiResponse(responseType, "Collect Successfully"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost("collectTickerHourdata")]
        public async Task<IActionResult> CollectTickerHourData()
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _tickerHourDataService.CollectingTickerHourDataAsync();
                return Ok(ResponseHandler.GetApiResponse(responseType, "Collect Successfully"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<DataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataController>
        [HttpPost("collectHistoricaldata")]
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

        [HttpDelete("deleteTickerDayDataset/{id}")]
        public async Task<IActionResult> DeleteTickerDayDataset(int id)
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _tickerDayDataService.DeleteTickerDayDataSetAsync(id);
                return Ok(ResponseHandler.GetApiResponse(responseType, "Delete the dataset successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete("deleteTickerHourDataSet/{id}")]
        public async Task<IActionResult> DeleteTickerHourDataSet(int id)
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _tickerHourDataService.DeleteTickerHourDataSetAsync(id);
                return Ok(ResponseHandler.GetApiResponse(responseType, "Delete the dataset successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
