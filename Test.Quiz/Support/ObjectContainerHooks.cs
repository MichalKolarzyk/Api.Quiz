using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Quiz.Support
{
    [Binding]
    public class ObjectContainerHooks
    {
        private IObjectContainer _container;

        public ObjectContainerHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ;
        }
    }
}
