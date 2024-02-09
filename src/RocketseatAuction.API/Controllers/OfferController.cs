using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Comunication.Requests;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

public class OfferController : RocketseatAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult CreateOffer(
        [FromRoute] int itemId, 
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUserCase userCase
        )
    {
        var id = userCase.Execute(itemId, request);
        return Created(string.Empty, id);
    }
}
