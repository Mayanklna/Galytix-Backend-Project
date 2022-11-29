using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


public class CsvData
{
    public string country { get; set; }
    public string variableId { get; set; }
    public string variableName { get; set; }
    public string lineOfBusiness { get; set; }
    public string Y2000 { get; set; }
    public string Y2001 { get; set; }
    public string Y2002 { get; set; }
    public string Y2003 { get; set; }
    public string Y2004 { get; set; }
    public string Y2005 { get; set; }
    public string Y2006 { get; set; }
    public string Y2007 { get; set; }
    public string Y2008 { get; set; }
    public string Y2009 { get; set; }
    public string Y2010 { get; set; }
    public string Y2011 { get; set; }
    public string Y2012 { get; set; }
    public string Y2013 { get; set; }
    public string Y2014 { get; set; }
    public string Y2015 { get; set; }
}
public class InputData
{
    public string country { get; set; }
    public string[] lob { get; set; }
}


namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ServerController : ControllerBase
    {

        public string GetDataFromDB(IEnumerable<CsvData> records, InputData Data)
        {
            IDictionary<string, int> returnData = new Dictionary<string, int>();
            return "data";
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok("pong");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("avg")]
        public async Task<IActionResult> GetData(InputData Data) {
            try
            {
                if (Data == null)
                {
                    return BadRequest(); 
                }
                using (var reader = new StreamReader("./Data/gwpByCountry.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<CsvData>();
                    var returnDataFromDB = GetDataFromDB(records, Data);
                    return CreatedAtAction("ReturnData", returnDataFromDB);
                }
                
            }

            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }

        }
    }
}
