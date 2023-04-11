using Application.Quiz.ReferenceItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases.InMemoryRepositories
{
    public class ReferenceListInMemoryRepository : InMemoryRepository<ReferenceItem>
    {
        protected override List<ReferenceItem> GetListItems()
        {
            return new List<ReferenceItem>()
            {
                new ReferenceItem("Category", "Math"),
                new ReferenceItem("Category", "Geo"),
                new ReferenceItem("Category", "IT"),
                new ReferenceItem("Category", "History"),
                new ReferenceItem("Category", "Biology"),
            };
        }
    }
}
