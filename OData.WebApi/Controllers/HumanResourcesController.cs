using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using OData.WebApi.Models;

namespace OData.WebApi.Controllers
{
    //EF-OData-Circeler Dependecy
    [ApiController]
    [Route("[controller]")]
    public class HumanResourcesController : ControllerBase
    {
        private HumanResourcesContext _humanResourcesContext;

        public HumanResourcesController(HumanResourcesContext humanResourcesContext)
        {
            _humanResourcesContext = humanResourcesContext;
        }

        [HttpGet("Get")]
        [EnableQuery]
        public ActionResult Get()
        {
            //Postman Example Request Query
            //https://localhost:7116/HumanResources/Get?select=countryId,countryName
            //https://localhost:7116/HumanResources/Get?filter=regionId eq 2
            //https://localhost:7116/HumanResources/Get?filter=regionId eq 2&select=countryId,countryName,regionId
            //https://localhost:7116/HumanResources/Get?orderby=regionId desc
            //https://localhost:7116/HumanResources/Get?filter=countryId in ("EG","IL")
            //https://localhost:7116/HumanResources/Get?filter=countryId in ("EG","IL")&select=countryId,countryName


            //IEnumerable<Country>
            /*using (var context = new HumanResourcesContext())
            {
                return context.Countries.AsQueryable();
            }*/

            //ActionResult
            return Ok(_humanResourcesContext.Countries.AsQueryable());
        }

        [HttpGet("GetRegionWithLocation")]
        [EnableQuery]
        public ActionResult GetRegionWithLocation()
        {
            //Postman Example Request Query
            //https://localhost:7116/HumanResources/GetRegionWithLocation
            //https://localhost:7116/HumanResources/GetRegionWithLocation?filter=regionId in (3,4)
            //https://localhost:7116/HumanResources/GetRegionWithLocation?filter=regionId in (3,4)
            //https://localhost:7116/HumanResources/GetRegionWithLocation?filter=region/regionId eq 2
            //https://localhost:7116/HumanResources/GetRegionWithLocation?filter=region/regionName eq 'Americas'
            //https://localhost:7116/HumanResources/GetRegionWithLocation?filter=length(countryName) eq 5

            return Ok(_humanResourcesContext.Countries.Include(i => i.Region).AsQueryable());
        }
    }
}