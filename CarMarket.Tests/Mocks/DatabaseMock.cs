using CarMarket.Services.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Tests.Mocks
{
    public static class DatabaseMock
    {
       public static CarMarketDbContext Instance
       {
           get
           {
               var contextOptions = new DbContextOptionsBuilder<CarMarketDbContext>()
               .UseInMemoryDatabase("CarsDB" + DateTime.Now.Ticks.ToString())
               .Options;
       
               return new CarMarketDbContext(contextOptions, false);
           }       
       }

    }
}
