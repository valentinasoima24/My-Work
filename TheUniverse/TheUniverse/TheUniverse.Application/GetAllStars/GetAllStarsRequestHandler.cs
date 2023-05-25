﻿using System.Collections.Generic;
using RemoteLearning.TheUniverse.Domain;
using RemoteLearning.TheUniverse.Infrastructure;

namespace RemoteLearning.TheUniverse.Application.GetAllStars
{
    public class GetAllStarsRequestHandler : IRequestHandler
    {
        public object Execute(object request)
        {
            List<StarInfo> starsInfo = new List<StarInfo>();

            IEnumerable<Galaxy> galaxies = Universe.Instance.EnumerateGalaxies();

            foreach (Galaxy galaxy in galaxies)
            {
                IEnumerable<string> stars = galaxy.EnumerateStars();

                foreach (string star in stars)
                {
                    StarInfo starInfo = new StarInfo
                    {
                        GalaxyName = galaxy.Name,
                        StarName = star
                    };

                    starsInfo.Add(starInfo);
                }
            }

            return starsInfo;
        }
    }
}