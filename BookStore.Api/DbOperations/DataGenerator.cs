using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.Api.DbOperations
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;




                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    });




                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Eric",
                        LastName = "Ries",
                        BirthDay = new DateTime(1978, 09, 22),
                        BookId = 1
                    },
                    new Author
                    {
                        Name = "Charlotte Perkins",
                        LastName = "Gilman",
                        BirthDay = new DateTime(1860, 07, 15),
                        BookId = 2
                    },
                    new Author
                    {
                        Name = "Frank",
                        LastName = "Herbert",
                        BirthDay = new DateTime(1920, 10, 08),
                        BookId = 1
                    });


                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 1,
                        PageCount = 54,
                        PublishDate = new DateTime(2001, 12, 21)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
