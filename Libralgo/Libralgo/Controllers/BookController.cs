using AutoMapper;
using Libralgo.Business.Abstract;
using Libralgo.Business.Concrete;
using Libralgo.Dto.BookDtos;
using Libralgo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Libralgo.Controllers
{
    public class BookController(IMapper mapper, IBookService bookService, IPublisherService publisherService, IAuthorService authorService, ICategoryService categoryService, ILibraryService libraryService) : Controller
    {
        [Route("/admin/books")]
        [HttpGet]
        public IActionResult Index()
        {
            var books = bookService.TGetAllDto<BookListDto>();

            return View(books);
        }


        [Route("/admin/books/create")]
        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            await FillSelectionsAsync();
            return View("AddBook", new BookAddDto());
        }

        [HttpPost("/admin/books/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(BookAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                await FillSelectionsAsync();
                return View(dto);
            }

            var book = mapper.Map<Book>(dto);

            book.Authors = authorService.TGetAll()
            .Where(a => dto.AuthorIds.Contains(a.Id))
            .ToList();

            book.Categories = categoryService.TGetAll()
                .Where(c => dto.CategoryIds.Contains(c.Id))
                .ToList();

            bookService.TCreate(book);

            return RedirectToAction("Index");
        }

        private async Task FillSelectionsAsync()
        {
            ViewBag.Publishers = new SelectList(
                publisherService.TGetAll()
                    .OrderBy(p => p.PublisherName),
                "Id",
                "PublisherName"
            );

            ViewBag.Authors = new MultiSelectList(
                authorService.TGetAll()
                    .OrderBy(a => a.NameSurname),
                "Id",
                "NameSurname"
            );

            ViewBag.Categories = categoryService.TGetAll()
                .OrderBy(c => c.CategoryName)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                }).ToList();

            ViewBag.Libraries = new SelectList(
                libraryService.TGetAll()
                    .OrderBy(l => l.LibraryName),
                "LibraryId",
                "LibraryName"
            );
        }
    }
}
