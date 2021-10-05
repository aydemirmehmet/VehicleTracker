using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.IO;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries.Utilities;

namespace VehicleTrackerApi.Helper
{
    public static class GeoShapeJsonParser
    {
        public static Geometry ParseGeoShapes( GeoJsonResultItem entity)
        {
            var data = JsonConvert.SerializeObject(entity);
            var reader = new GeoJsonReader();
            FeatureCollection featureCollection = reader.Read<FeatureCollection>(data);
            if (featureCollection == null) return null;
            Geometry geometry = featureCollection[0].Geometry;


            return geometry;
        }

        public static IEnumerable<Geometry> Extract(IFeature feature)
        {
            var extract = new List<Geometry>();

            new GeometryExtracter<Point>(extract).Filter(feature.Geometry);
            new GeometryExtracter<MultiPoint>(extract).Filter(feature.Geometry);
            new GeometryExtracter<LineString>(extract).Filter(feature.Geometry);
            new GeometryExtracter<MultiLineString>(extract).Filter(feature.Geometry);
            new GeometryExtracter<LinearRing>(extract).Filter(feature.Geometry);
            new GeometryExtracter<Polygon>(extract).Filter(feature.Geometry);
            new GeometryExtracter<MultiPolygon>(extract).Filter(feature.Geometry);

            return extract;
        }
   
    }
}
