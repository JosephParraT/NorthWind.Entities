using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.ConsoleApp.Services
{
    internal class ProductService(IUserActionWriter writer)
    {
        public ProductService(IUserActionWriter writer)
        {
            Writer = writer;
        }

        public IUserActionWriter Writer { get; }

        public void add(string user, string ProdutName)
        {
            UserAction Action = new UserAction(user, $"Created:{productName}");
            writer.Write(Action);
        }
    }
}
