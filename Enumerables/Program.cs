using System;
using System.Collections.Generic;

namespace BarsEdu
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entity> entities = new List<Entity>
            {
                new Entity { Id = 1, ParentId = 0, Name = "Root entity"},
                new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity"},
                new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity"},
                new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity"},
                new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity"},
            };
            
            var dict = GroupByParents(entities);
        }

        static Dictionary<int, List<Entity>> GroupByParents(List<Entity> entities)
        {
            var dict = new Dictionary<int, List<Entity>>();

            foreach (var entity in entities)
            {
                dict.TryAdd(entity.ParentId, new List<Entity>());
                dict[entity.ParentId].Add(entity);
            }
            
            return dict;
        }
    }
}