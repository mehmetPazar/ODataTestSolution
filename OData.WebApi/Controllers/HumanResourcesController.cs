using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OData.WebApi.Models;

namespace OData.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanResourcesController : ControllerBase
    {
        private HumanResourcesContext humanResourcesContext;

        public HumanResourcesController(HumanResourcesContext humanResourcesContext)
        {
            this.humanResourcesContext = humanResourcesContext;
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
            return Ok(humanResourcesContext.Countries.AsQueryable());
        }
    }
}