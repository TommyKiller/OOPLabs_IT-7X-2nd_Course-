﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
    public class Route : IEquatable<Route>, ICloneable
    {
        public RouteID ID { get; private set; }
        public List<Waypoint> Waypoints { get; private set; }
        public RouteTypes RouteType { get; private set; }

        public Route(RouteID id)
        {
            ID = id;
            Waypoints = new List<Waypoint>();
        }

        public object Clone()
        {
            Route route = this.MemberwiseClone() as Route;

            route.ID = this.ID.Clone() as RouteID;

            route.Waypoints = new List<Waypoint>();
            foreach (Waypoint wp in this.Waypoints)
            {
                route.Waypoints.Add(wp.Clone() as Waypoint);
            }

            return route;
        }

        public void RemoveWaypoint(Waypoint wp)
        {
            Waypoints.Remove(wp);

            RouteType = Waypoints.First() == Waypoints.Last() ? RouteTypes.Circular : RouteTypes.Direct;
        }

        public void AddWaypoint(Waypoint wp)
        {
            Waypoints.Add(wp);

            RouteType = Waypoints.First() == Waypoints.Last() ? RouteTypes.Circular : RouteTypes.Direct;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Route);
        }

        public bool Equals(Route other)
        {
            return (!ReferenceEquals(other, null)) && (ReferenceEquals(other, this) || ID == other.ID);
        }

        public static bool operator ==(Route left, Route right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Route left, Route right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return "Route " + ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
