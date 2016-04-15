namespace org.ian.location.test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using configuration;
    
    class Program
    {
        readonly static string LocationClient = @"locationService";

        static void Main(string[] args)
        {
            double lat = 0.00D;
            double lng = 0.00D;
            ILocation location = Load(LocationClient);
            string data = location.Location(lng, lat);
            Console.WriteLine(data);
        }

        static ILocation Load(string moduleSectionConfigString)
        {
            SectionReader reader = new SectionReader(moduleSectionConfigString);
            string moduleString = reader.GetAttribute(null, @"type").Value;
            string[] moduleContext = moduleString.SplitAt(',');
            ILocation handler = null;
            if (moduleContext.Length > 1)
            {
                Assembly assembly = Assembly.Load(moduleContext[1]);
                object instance = assembly.CreateInstance(moduleContext[0], false);
                handler = instance as ILocation;
            }
            return handler;
        }
    }

    static class Helper
    {
        public static String[] SplitAt(this String source, params char[] args)
        {
            IEnumerable<string> split = from piece in source.Split(args)
                                        let trimmed = piece.Trim()
                                        where !String.IsNullOrWhiteSpace(trimmed)
                                        select trimmed;
            return split.ToArray();
        }
    }
}
