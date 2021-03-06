﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCar.Models;

namespace MvcCar.Controllers
{
    public class CarsController : Controller
    {
        private readonly MvcCarContext _context;

        public CarsController(MvcCarContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string carSize, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Car
                                            orderby m.Size
                                            select m.Size;

            var cars = from m in _context.Car
                         select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(carSize))
            {
               cars = cars.Where(x => x.Size == carSize);
            }

            var CarSizeVM = new CareSizeViewModel
            {
                Sizes = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Cars = await cars.ToListAsync()
            };

            return View(CarSizeVM);
        }

        public async Task<IActionResult> Sort(string sort)
        {
              if (sort == null) return RedirectToAction("Index");

            IQueryable<Car> query = _context.Car.AsQueryable();

                if (sort != null && sort.Trim().ToUpper() == "ASC")
                {
                    query = _context.Car.OrderBy(p => p.ReleaseDate);
                }

                if (sort != null && sort.Trim().ToUpper() == "DESC")
                {
                    query = _context.Car.OrderByDescending(p => p.ReleaseDate);
                }

                

            var SortCar = new CareSizeViewModel
            {
                
                Cars = await query.ToListAsync()

            };

            return View("Index",SortCar);
            
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Color,Price,Size")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Color,Price,Size")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
