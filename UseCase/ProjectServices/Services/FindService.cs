using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.ProjectServices.MediatR.Enums;
using FuzzySharp;

namespace UseCase.ProjectServices.Services
{
    public class FindService<T>
    {
        private IEnumerable<T> items = new List<T>();
        public List<T> ToList() => items.ToList();

        public void SetItems(IEnumerable<T> items)
        {
            this.items = items;
        }
        public IEnumerable<T> Find(string PropName, string PropValue, FindFlags findFlags)
        {
            if (findFlags.HasFlag(FindFlags.CaseInsensitive))
            {
                foreach (var item in items)
                {
                    if (item is null) continue;
                    foreach (var property in item.GetType().GetProperties()) 
                    {
                        if(property.Name == PropName) property.SetValue(item, PropValue.ToLower());
                    }
                }
            }

            if(findFlags.HasFlag(FindFlags.UseFuzzySearch))
            {
                List<string> properties = new();

                foreach (var item in items)
                {
                    if (item is null) continue;
                    foreach (var property in item.GetType().GetProperties())
                    {
                        if (property.Name == PropName && property.CanRead) properties.Add(property.GetValue(property).ToString());
                    }
                }

                var resultrs = Process.ExtractAll(PropValue, properties, cutoff: 70) //procent of similarity
                                      .Select(x=>x.Value).ToList();
                
                List<T> new_items = new List<T>();

                foreach(var item in items)
                {
                    if (item is null) continue;
                    foreach (var property in item.GetType().GetProperties())
                    {
                        if (property.Name == PropName && resultrs.Contains(property.GetValue(property).ToString()))
                        {
                            new_items.Add(item);
                        }
                    }
                }
            }

            return items;
        }
    }
}
