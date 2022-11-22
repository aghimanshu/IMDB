using IMDBApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.MoviesData
{
    public interface IProducer
    {
        List<Producer> GetProducers();
        Producer GetProducer(int id);
        Producer AddProducer(Producer producer);
        Producer EditProducer(Producer producer);
        Producer DeleteProducer(Producer producer);

    }
}
