using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAPI.Demo.Data;
using ReactAPI.Demo.Data.Entities;

namespace ReactAPI.Demo.Controllers;

[ApiController]
[Route("[controller]")]

public class ContactsController:ControllerBase
{
    private readonly ReactJSDemoContext _reactContext;
    public ContactsController(ReactJSDemoContext reactContext)
    {
        _reactContext = reactContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sql = await _reactContext.Contacts.ToListAsync();
        return Ok(sql);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Contacts newContacts)
    {
        _reactContext.Contacts.Add(newContacts);
        await _reactContext.SaveChangesAsync();
        return Ok(newContacts);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var contactById = await _reactContext.Contacts.FindAsync(id);
        return Ok(contactById);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Contacts contactToUpdate)
    {
        _reactContext.Contacts.Update(contactToUpdate);
        await _reactContext.SaveChangesAsync();
        return Ok(contactToUpdate);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var  contactToDelete = await _reactContext.Contacts.FirstAsync();
        if(contactToDelete == null)
        {
            return NotFound();
        }
        _reactContext.Contacts.Remove(contactToDelete);
        await _reactContext.SaveChangesAsync();
        return Ok();
    }
}
