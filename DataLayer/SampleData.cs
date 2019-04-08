using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if(!context.Directories.Any())
            {
                context.Directories.Add(new Entites.Directory() { Title = "First Directory", Html = "<b>Directory 1 content</b>" });
                context.Directories.Add(new Entites.Directory() { Title = "Second Directory", Html = "<b>Directory 2 content</b>" });
                context.Directories.Add(new Entites.Directory() { Title = "Third Directory", Html = "<b>Directory 3 content</b>" });
                context.Directories.Add(new Entites.Directory() { Title = "Four Directory", Html = "<b>Directory 4 content</b>" });
                context.Directories.Add(new Entites.Directory() { Title = "Five Directory", Html = "<b>Directory 5 content</b>" });

                context.SaveChanges();

                context.Materials.Add(new Entites.Material() { Title = "1 Material", Html = "<i>Material content 1</i>", DirectoryId = 1 });
                context.Materials.Add(new Entites.Material() { Title = "2 Material", Html = "<i>Material content 2</i>", DirectoryId = 2 });
                context.Materials.Add(new Entites.Material() { Title = "3 Material", Html = "<i>Material content 3</i>", DirectoryId = 3 });
                context.Materials.Add(new Entites.Material() { Title = "4 Material", Html = "<i>Material content 4</i>", DirectoryId = 5 });
                context.Materials.Add(new Entites.Material() { Title = "5 Material", Html = "<i>Material content 5</i>", DirectoryId = 2 });

                context.SaveChanges();
            }
        }
    }
}
