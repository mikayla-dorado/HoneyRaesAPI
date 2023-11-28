using System.Text.Json.Serialization;
using HoneyRaesAPI.Models;
using HoneyRaesAPI.Models.DTOs;
using Microsoft.AspNetCore.Http.Json;

// List<HoneyRaesAPI.Models.Customer> customers = new List<HoneyRaesAPI.Models.Customer> {};
// List<HoneyRaesAPI.Models.Employee> employees = new List<HoneyRaesAPI.Models.Employee> {};
// List<HoneyRaesAPI.Models.ServiceTicket> serviceTickets = new List<HoneyRaesAPI.Models.ServiceTicket> {};


List<Customer> customers = new List<Customer>
{
    new Customer()
    {
        Id = 1,
        Name = "Amanda Dorado",
        Address = "123 Firefly Lane"
    },
    new Customer()
    {
        Id = 2,
        Name = "Zeke Dorado",
        Address = "123 Oden Lane"
    },
    new Customer()
    {
        Id = 3,
        Name = "Ely Dorado",
        Address = "123 Jackson Lane"
    }
};

List<Employee> employees = new List<Employee>
{
    new Employee()
    {
        Id = 1,
        Name = "Bart Simpson",
        Specialty = "Keyboard Repairs"
    },
    new Employee()
    {
        Id = 2,
        Name = "Jessica Simpson",
        Specialty = "Battery Replacement"
    }
};

List<ServiceTicket> serviceTickets = new List<ServiceTicket>
{
    new ServiceTicket()
    {
        Id = 1,
        CustomerId = 1,
        EmployeeId = 1,
        Description = "Dead Battery",
        Emergency = true,
        DateCompleted = new DateTime(2023, 11, 29)
    },
     new ServiceTicket()
    {
        Id = 2,
        CustomerId = 2,
        Description = "Cracked Screen",
        Emergency = false,
    },
     new ServiceTicket()
    {
        Id = 3,
        CustomerId = 3,
        EmployeeId = 3,
        Description = "Green Screen of Death",
        Emergency = true,
        DateCompleted = new DateTime(2023, 12, 29)
    },
     new ServiceTicket()
    {
        Id = 4,
        CustomerId = 4,
        Description = "Screen Doesn't Work",
        Emergency = true,
    },
     new ServiceTicket()
    {
        Id = 5,
        CustomerId = 5,
        Description = "Won't Charge",
        Emergency = false,
    },
};


var builder = WebApplication.CreateBuilder(args);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/servicetickets", () =>
{
    return serviceTickets.Select(t => new ServiceTicketDTO
    {
        Id = t.Id,
        CustomerId = t.CustomerId,
        EmployeeId = t.EmployeeId,
        Description = t.Description,
        Emergency = t.Emergency,
        DateCompleted = t.DateCompleted
    });
});

app.MapGet("/servicetickets/{id}", (int id) =>
{
    ServiceTicket serviceTicket = serviceTickets.FirstOrDefault(st => st.Id == id);
    return new ServiceTicketDTO
    {
        Id = serviceTicket.Id,
        CustomerId = serviceTicket.CustomerId,
        EmployeeId = serviceTicket.EmployeeId,
        Description = serviceTicket.Description,
        Emergency = serviceTicket.Emergency,
        DateCompleted = serviceTicket.DateCompleted
    };
});


app.MapGet("/employees", () =>
{
    return employees.Select(e => new EmployeeDTO
    {
        Id = e.Id,
        Name = e.Name,
        Specialty = e.Specialty
    });
});

app.MapGet("/employees/{id}", (int id) =>
{
    Employee employee = employees.FirstOrDefault(e => e.Id == id);
    return new EmployeeDTO
    {
        Id = employee.Id,
        Name = employee.Name,
        Specialty = employee.Specialty
    };
});

app.MapGet("/customers", () =>
{
    return customers.Select(c => new CustomerDTO
    {
        Id = c.Id,
        Name = c.Name,
        Address = c.Address
    });
});

app.MapGet("/customers/{id}", (int id) =>
{
    Customer customer = customers.FirstOrDefault(c => c.Id == id);
    return new CustomerDTO
    {
        Id = customer.Id,
        Name = customer.Name,
        Address = customer.Address
    };
});

app.Run();


// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateTime.Now.AddDays(index),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.MapGet("/hello", () =>
// {
//     return "hello";
// });


// record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }