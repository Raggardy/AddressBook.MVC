#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressBook.MVC.Models.DataModels;
using AddressBook.MVC.Models.ViewModels;
using AutoMapper;
using AddressBook.MVC.Contracts;

namespace AddressBook.MVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PeopleController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var people = _mapper.Map<List<PersonVM>>(await _personRepository.GetAllAsync());
            return View(people);
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            var personVM = _mapper.Map<PersonVM>(person);
            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {            
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonVM personVM)
        {
            if (ModelState.IsValid)
            {
                var person = _mapper.Map<Person>(personVM);

                await _personRepository.CreateNewAsync(person);

                return RedirectToAction(nameof(Index));
            }
           
            return View(personVM);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {          

            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            var personVM = _mapper.Map<PersonVM>(person);
            return View(personVM);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonVM personVM)
        {
            if (id != personVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var person = _mapper.Map<Person>(personVM);
                    await _personRepository.UpdateAsync(person);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _personRepository.Exists(personVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }            
            return View(personVM);
        }

        

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
