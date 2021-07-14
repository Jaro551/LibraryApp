using LibraryAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAppMVC.Data
{
    public class LibraryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var authors = new List<Author>
            {
                new Author{FirstName="Andrzej", LastName="Sapkowski", DateOfBirth=DateTime.Parse("1948-06-21")},
                new Author{FirstName="J.K", LastName="Rowling", DateOfBirth=DateTime.Parse("1965-07-31")},
                new Author{FirstName="Aleksander", LastName="Fredro", DateOfBirth=DateTime.Parse("1793-06-20")},
                new Author{FirstName="J.R.R.", LastName="Tolkien", DateOfBirth=DateTime.Parse("1892-01-03")},
                new Author{FirstName="Henryk", LastName="Sienkiewicz", DateOfBirth=DateTime.Parse("1846-05-05")},
                new Author{FirstName="Suzanne", LastName="Collins", DateOfBirth=DateTime.Parse("1846-05-05")}
            };

            authors.ForEach(item => context.Authors.Add(item));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book{Title="Harry Potter i Zakon Feniksa", AuthorID = 2, ReleaseDate=DateTime.Parse("2003-06-21")},
                new Book{Title="Harry Potter i Kamień Filozoficzny", AuthorID = 2, ReleaseDate=DateTime.Parse("1997-06-26")},
                new Book{Title="Harry Potter i Więzień Azkabanu", AuthorID = 2, ReleaseDate=DateTime.Parse("1999-07-08")},
                new Book{Title="Potop", AuthorID = 5, ReleaseDate=DateTime.Parse("1895-03-26")},
                new Book{Title="Władca Pierścienia: Drużyna Pierścienia", AuthorID = 4, ReleaseDate=DateTime.Parse("1954-07-29")},
                new Book{Title="Władca Pierścienia: Dwie Wieże", AuthorID = 4, ReleaseDate=DateTime.Parse("1954-11-11")},
                new Book{Title="Władca Pierścienia: Powrót Króla", AuthorID = 4, ReleaseDate=DateTime.Parse("1955-10-20")},
                new Book{Title="Sezon burz", AuthorID = 1, ReleaseDate=DateTime.Parse("2013-11-06")},
                new Book{Title="Igrzyska śmierci: W pierścieniu ognia", AuthorID = 6, ReleaseDate=DateTime.Parse("2009-09-01")},
                new Book{Title="Igrzyska śmierci: Kosogłos", AuthorID = 6, ReleaseDate=DateTime.Parse("2010-08-24")},
            };
            books.ForEach(item => context.Books.Add(item));
            context.SaveChanges();
        }
    }
}