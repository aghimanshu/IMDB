using IMDBApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.MoviesData
{
    public interface IActor
    {
        List<Actor> GetActors();
        Actor GetActor(int id);
        Actor AddActor(Actor actor);
        Actor EditActor(Actor actor);
        Actor DeleteActor(Actor actor);
    }
}
