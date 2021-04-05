using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backoffice.Data;
using Backoffice.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Backoffice.Services;

namespace Backoffice.Controllers
{
  [Route("users")]
  public class UserController : Controller
  {
    [HttpPost]
    [Route("")]
    [AllowAnonymous]
    public async Task<ActionResult<User>> Post([FromServices] DataContext context, [FromBody] User model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        context.Users.Add(model);
        await context.SaveChangesAsync();
        return model;
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Não foi possível criar usuário" });
      }
    }
  }
}